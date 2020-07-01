using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects.Spot;
using Binance.Net.Objects.Spot.MarketData;
using Binance.Net.Objects.Spot.SpotData;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoTrader.Strategies;
using CryptoTrader.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTrader.Trades
{
    //Manages the trades and updates the UI
    public class TradeManager
    {
        private readonly BinanceSocketClient websocketClient;
        private readonly BinanceClient apiClient;
        private List<BinanceKline> backTestData;
        private List<BinanceKline> candles;
        private readonly TradingView tradeView;
        private CallResult<UpdateSubscription> candleSubscription;
        private TradeManagerConfig config;
        private decimal currentBalance = 0;
        private decimal currentAltBalance = 0;
        private bool isBuying = true;
        private IStrategy strategy;
        private List<BinanceOrder> transactionLog;
        private string pair = "ETHBTC";

        public TradeManager(TradingView tradeView, TradeManagerConfig config, IStrategy strategy) {
            this.tradeView = tradeView;
            this.websocketClient = new BinanceSocketClient();
            this.apiClient = new BinanceClient();
            this.candles = new List<BinanceKline>();
            this.backTestData = new List<BinanceKline>();
            this.config = config;
            currentBalance = config.BalanceStart;
            transactionLog = new List<BinanceOrder>();
            this.strategy = strategy;
        }

        public void StartBackTesting(string key, string secret, DateTime startDate) {
            //Configure settings
            SetKeys(key, secret);

            //Get past candles to calculate indicators
            Task<WebCallResult<IEnumerable<BinanceKline>>> task = apiClient.GetKlinesAsync(pair, KlineInterval.OneMinute, startDate, null, 1000, default);
            IEnumerable<BinanceKline> result = new List<BinanceKline>();

            Task continueation = task.ContinueWith(t => {
                if (t.Result.Success)
                {
                    backTestData.AddRange(CandleGranulation.AverageOpenToClose(t.Result.Data.ToList(), 3));

                    foreach (BinanceKline k in backTestData)
                    {
                        //Update UI and candleList
                        UpdateData(k);

                        //Check for and execute trade
                        ExecuteTrade();
                        UpdateUIText(currentBalance, currentAltBalance, null);
                        Thread.Sleep(15);
                    }
                }
                else
                {
                    tradeView.ShowMessage(t.Result.Error.Message);
                }
            });

            task.Wait();
        }

        public void StartLiveTrading(string key, string secret) {
            //Configure settings
            SetKeys(key, secret);

            //Get past candles to calculate indicators
            Task<WebCallResult<IEnumerable<BinanceKline>>> task = apiClient.GetKlinesAsync(pair, KlineInterval.OneMinute, null, null, 100, default);
            IEnumerable<BinanceKline> result = new List<BinanceKline>();

            Task continueation = task.ContinueWith(t => {
                if (t.Result.Success)
                {
                    AddPastCandles(task.Result.Data.ToList());

                    //Place marker to signify startpoint
                    PlaceMarker(candles[candles.Count - 1].OpenTime, candles[candles.Count - 1].Close, Color.Blue);
                } else {
                    tradeView.ShowMessage(t.Result.Error.Message);
                }
            });

            task.Wait();

            //Start subscription
            candleSubscription = websocketClient.SubscribeToKlineUpdates(pair, KlineInterval.OneMinute, update => {
                //Update UI and candleList
                UpdateData(update.Data.ToKline());

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
                    currentAltBalance = (order.Quantity - (order.Quantity * (decimal)0.005)) / order.Price;
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
                    currentBalance += (order.Quantity - (order.Quantity * (decimal)0.005)) * order.Price;
                    currentAltBalance = 0;
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

        private void UpdateData(BinanceKline k) {
            if (candles.Count > 0 && candles[candles.Count - 1].OpenTime == k.OpenTime) {
                candles[candles.Count - 1] = k;
                tradeView.AddValue(k, true);
            } else {
                candles.Add(k);
                tradeView.AddValue(k, false);
            }
        }

        private void AddPastCandles(List<BinanceKline> pastCandles) {
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
