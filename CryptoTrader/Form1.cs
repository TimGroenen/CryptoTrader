using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects.Spot;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;

namespace CryptoTrader
{
    public partial class Form1 : Form
    {
        BinanceSocketClient client;
        CallResult<UpdateSubscription> candleSubscription;

        public Form1()
        {
            InitializeComponent();
            client = new BinanceSocketClient();
            candleChart.Series[0].ChartType = SeriesChartType.Candlestick;
            candleChart.Series[0]["PriceUpColor"] = "Green"; // <<== use text indexer for series
            candleChart.Series[0]["PriceDownColor"] = "Red"; // <<== use text indexer for series
            candleChart.Series[0].Points.Clear();

            // Set automatic zooming
            candleChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            candleChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            // Set automatic scrolling 
            candleChart.ChartAreas[0].CursorX.AutoScroll = true;
            candleChart.ChartAreas[0].CursorY.AutoScroll = true;

            // Allow user selection for Zoom
            candleChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            candleChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        }

        private void startWebsocketButton_Click(object sender, EventArgs e)
        {
            candleSubscription = client.SubscribeToKlineUpdates("ethbtc", KlineInterval.OneMinute, update => {
                AddValue(update.Data.OpenTime, update.Data.High, update.Data.Low, update.Data.Open, update.Data.Close);
            });
        }

        private void stopWebsocketButton_Click(object sender, EventArgs e)
        {
            client.UnsubscribeAll();
        }

        //Delegate because addvalue is accessed from a different thread
        delegate void AddValueCallback(DateTime openTime, decimal high, decimal low, decimal open, decimal close);

        private void AddValue(DateTime openTime, decimal high, decimal low, decimal open, decimal close) 
        {
            if (candleChart.InvokeRequired) {
                AddValueCallback d = new AddValueCallback(AddValue);
                this.Invoke(d, new object[] { openTime, high, low, open, close });
            }
            else
            {
                candleChart.Series[0].Points.AddXY(openTime, high, low, open, close);
                candleChart.ChartAreas[0].RecalculateAxesScale();
            }
        }
    }
}
