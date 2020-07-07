using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects.Spot;
using Binance.Net.Objects.Spot.MarketData;
using Binance.Net.Objects.Spot.SpotData;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoTraderLibrary.Models;
using CryptoTraderLibrary.Interfaces;
using CryptoTraderLibrary.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace CryptoTraderLibrary.Trades
{
    //Manages the trades and updates the UI
    public class TradeManager
    {
        private readonly BinanceSocketClient websocketClient;
        private readonly BinanceClient apiClient;
        private List<IndicatorKline> backTestData;
        private List<IndicatorKline> candles;
        private readonly IUIConnection tradeView;
        private CallResult<UpdateSubscription> candleSubscription;
        private TradeManagerConfig config;
        private decimal currentBalance = 0;
        private decimal currentAltBalance = 0;
        private bool isBuying = true;
        private IStrategy strategy;
        private List<BinanceOrder> transactionLog;
        private string pair = "ETHBTC";
        private KlineInterval interval;

        public TradeManager(IUIConnection tradeView, TradeManagerConfig config, IStrategy strategy) {
            this.tradeView = tradeView;
            this.websocketClient = new BinanceSocketClient();
            this.apiClient = new BinanceClient();
            this.candles = new List<IndicatorKline>();
            this.backTestData = new List<IndicatorKline>();
            this.config = config;
            currentBalance = config.BalanceStart;
            transactionLog = new List<BinanceOrder>();
            this.strategy = strategy;
            this.interval = config.interval;
        }

        public void StartBackTesting(string key, string secret, DateTime startDate, DateTime endTime) {
            //Configure settings
            SetKeys(key, secret);

            //Create new task to handle the backtesting otherwise the UI hangs
            Task backtestTask = Task.Run(() => {
                DateTime currentTime = startDate;
                int lastIndex = 0;

                while (currentTime < endTime) {
                    //Get past candles to calculate indicators
                    Task<WebCallResult<IEnumerable<BinanceKline>>> t = apiClient.GetKlinesAsync(pair, interval, currentTime, null, 1000, default);
                    List<BinanceKline> result = t.GetAwaiter().GetResult().Data.ToList();

                    if (t.Result.Success)
                    {
                        List<IndicatorKline> data = new List<IndicatorKline>();

                        for (int i = 0; i < result.Count - 1; i++)
                        {
                            if (i == 0 && candles.Count > 0)
                            {
                                data.Add(new IndicatorKline(result[i], candles, config.ShortMA, config.LongMA));
                            }
                            else
                            {
                                data.Add(new IndicatorKline(result[i], data, config.ShortMA, config.LongMA));
                            }
                        }

                        backTestData.AddRange(CandleGranulation.AverageOpenToClose(data, 3, config));

                        foreach (IndicatorKline k in backTestData.GetRange(lastIndex, backTestData.Count - (lastIndex + 1)))
                        {
                            //Update UI and candleList
                            UpdateData(k);

                            //Check for and execute trade
                            ExecuteTrade();
                            UpdateUIText(currentBalance, currentAltBalance, null);
                        }
                    }
                    else
                    {
                        tradeView.ShowMessage(t.Result.Error.Message);
                    }

                    lastIndex = backTestData.Count - 1;
                    currentTime = result[result.Count - 1].OpenTime;
                }
            });
        }

        public void StartLiveTrading(string key, string secret) {
            //Configure settings
            SetKeys(key, secret);

            //Get past candles to calculate indicators
            Task<WebCallResult<IEnumerable<BinanceKline>>> task = apiClient.GetKlinesAsync(pair, interval, null, null, 500, default);
            IEnumerable<IndicatorKline> result = new List<IndicatorKline>();

            Task continueation = task.ContinueWith(t => {
                if (t.Result.Success)
                {
                    List<IndicatorKline> data = new List<IndicatorKline>();

                    foreach (BinanceKline bk in t.Result.Data.ToList())
                    {
                        data.Add(new IndicatorKline(bk, data, config.ShortMA, config.LongMA));
                    }

                    AddPastCandles(data);

                    //Place marker to signify startpoint
                    PlaceMarker(candles[candles.Count - 1].OpenTime, candles[candles.Count - 1].Close, Color.Blue);
                } else {
                    tradeView.ShowMessage(t.Result.Error.Message);
                }
            });

            task.Wait();

            //Start subscription
            candleSubscription = websocketClient.SubscribeToKlineUpdates(pair, interval, update => {
                //Update UI and candleList
                UpdateData(new IndicatorKline(update.Data.ToKline(), candles, config.ShortMA, config.LongMA));

                //Check for and execute trade, update ui
                ExecuteTrade();
                UpdateUIText(currentBalance, currentAltBalance, null);
            });
        }

        private void ExecuteTrade() {
            BinanceOrder order = null;

            //Decide if a new trade has to be made
            if (isBuying)
            {
                //Look for buy
                if (strategy.ShouldBuy(candles))
                {
                    //Create order at last price
                    order = new BinanceOrder
                    {
                        Side = OrderSide.Buy,
                        Type = OrderType.Market,
                        Symbol = pair,
                        Quantity = currentBalance * (config.PercentageBuy / 100),
                        Price = candles[candles.Count - 1].Close,
                    };

                    //Update currentBalance
                    currentBalance -= order.Quantity;
                    currentAltBalance += Math.Round(order.Quantity / order.Price, 8) * 0.999M;
                }
            }
            else
            {
                //Look for sell
                if (strategy.ShouldSell(candles))
                {
                    //Create order at last price
                    order = new BinanceOrder
                    {
                        Side = OrderSide.Sell,
                        Type = OrderType.Market,
                        Symbol = pair,
                        Quantity = currentAltBalance,
                        Price = candles[candles.Count - 1].Close,
                    };

                    //Update currentBalance
                    currentBalance += Math.Round(order.Quantity * order.Price, 8) * 0.999M;
                    currentAltBalance -= order.Quantity;
                }
            }

            if (order != null)
            {
                //Execute order
                transactionLog.Add(order);

                if (order.Side == OrderSide.Buy)
                {
                    PlaceMarker(candles[candles.Count - 1].OpenTime, order.Price, Color.Lime);
                }
                else
                {
                    PlaceMarker(candles[candles.Count - 1].OpenTime, order.Price, Color.Red);

                    //Update transactions
                    UpdateUIText(currentBalance, currentAltBalance, new Transaction(
                        transactionLog[transactionLog.Count - 2].Price, 
                        transactionLog[transactionLog.Count - 1].Price, 
                        transactionLog[transactionLog.Count - 2].Quantity
                    ));
                }

                isBuying = !isBuying;
            }
        }

        public void StopLiveTrading() {
            //Sell open position (market price? or limit?)

            //Unsubscribe websockets
            websocketClient.Unsubscribe(candleSubscription.Data);
        }

        private void SetKeys(string key, string secret) {
            BinanceClient.SetDefaultOptions(new BinanceClientOptions()
            {
                ApiCredentials = new ApiCredentials(key, secret),
            });
            BinanceSocketClient.SetDefaultOptions(new BinanceSocketClientOptions()
            {
                ApiCredentials = new ApiCredentials(key, secret),
            });
        }

        private void UpdateData(IndicatorKline k) {
            if (candles.Count > 0 && candles[candles.Count - 1].OpenTime == k.OpenTime) {
                candles[candles.Count - 1] = k;
                tradeView.AddValue(k, true);
            } else {
                candles.Add(k);
                tradeView.AddValue(k, false);
            }
        }

        private void AddPastCandles(List<IndicatorKline> pastCandles) {
            candles.AddRange(pastCandles);
            tradeView.AddCandles(pastCandles);
        }

        private void PlaceMarker(DateTime openTime, decimal close, Color color) {
            tradeView.PlaceMarker(openTime, close, color);
        }

        private void UpdateUIText(decimal currentBalance, decimal currentAltBalance, Transaction t) {
            tradeView.UpdateUIText(currentBalance, currentAltBalance, t);
        }
    }
}
