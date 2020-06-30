using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects.Spot;
using Binance.Net.Objects.Spot.MarketData;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrader.Trades
{
    //Manages the trades and updates the UI
    public class TradeManager
    {
        private readonly BinanceSocketClient websocketClient;
        private readonly BinanceClient apiClient;
        private List<BinanceKline> candles;
        private readonly TradingView tradeView;
        private CallResult<UpdateSubscription> candleSubscription;

        public TradeManager(TradingView tradeView) {
            this.tradeView = tradeView;
            this.websocketClient = new BinanceSocketClient();
            this.apiClient = new BinanceClient();
            this.candles = new List<BinanceKline>();
        }

        public void StartTrading(string key, string secret) {
            //Configure settings
            SetKeys(key, secret);

            //Get past candles to calculate indicators
            Task<WebCallResult<IEnumerable<BinanceKline>>> task = apiClient.GetKlinesAsync("ETHBTC", KlineInterval.OneMinute, null, null, 100, default);
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
            candleSubscription = websocketClient.SubscribeToKlineUpdates("ETHBTC", KlineInterval.OneMinute, update => {
                //Decide if a new trade has to be made

                //Execute trade

                //Log trade

                //Update UI
                UpdateCandleChart(update.Data.ToKline());
            });
        }

        public void StopTrading() {
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

        private void UpdateCandleChart(BinanceKline k) {
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
    }
}
