using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects.Spot;
using Binance.Net.Objects.Spot.MarketData;
using Binance.Net.Objects.Spot.MarketStream;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;

namespace CryptoTrader
{
    public partial class Form1 : Form
    {
        BinanceSocketClient client;
        List<BinanceKline> candleSticks;
        CallResult<UpdateSubscription> candleSubscription;

        public Form1()
        {
            InitializeComponent();
            client = new BinanceSocketClient();

            candleSticks = new List<BinanceKline>();

            candleChart.Series[0].Points.Clear();
            candleChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
        }

        private void startWebsocketButton_Click(object sender, EventArgs e)
        {
            BinanceClient.SetDefaultOptions(new BinanceClientOptions()
            {
                ApiCredentials = new ApiCredentials(apiKeyText.Text, apiSecretText.Text),
            });
            BinanceSocketClient.SetDefaultOptions(new BinanceSocketClientOptions()
            {
                ApiCredentials = new ApiCredentials(apiKeyText.Text, apiSecretText.Text),
            });

            candleSubscription = client.SubscribeToKlineUpdates("ethbtc", KlineInterval.OneMinute, update => {
                AddValue(update.Data.ToKline());
            });
        }

        private void stopWebsocketButton_Click(object sender, EventArgs e)
        {
            client.UnsubscribeAll();
        }

        //Delegate because addvalue is accessed from a different thread
        delegate void AddValueCallback(BinanceKline k);

        private void AddValue(BinanceKline k) 
        {
            if (candleChart.InvokeRequired) {
                AddValueCallback d = new AddValueCallback(AddValue);
                this.Invoke(d, k);
            }
            else
            {
                if (candleSticks.Count > 0 && candleSticks.Last().OpenTime == k.OpenTime)
                {
                    //Same as last candle, update values
                    candleSticks[candleSticks.Count - 1] = k;
                    candleChart.Series[0].Points.RemoveAt(candleChart.Series[0].Points.Count - 1);
                    candleChart.Series[0].Points.AddXY(k.OpenTime.ToShortTimeString(), k.High, k.Low, k.Open, k.Close);

                } else {
                    //New candle
                    candleSticks.Add(k);
                    candleChart.Series[0].Points.AddXY(k.OpenTime.ToShortTimeString(), k.High, k.Low, k.Open, k.Close);
                }

                candleChart.ChartAreas[0].RecalculateAxesScale();
            }
        }
    }
}
