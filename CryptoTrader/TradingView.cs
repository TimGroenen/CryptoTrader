using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Binance.Net.Objects.Spot.MarketData;
using CryptoTrader.Trades;

namespace CryptoTrader
{
    public partial class TradingView : Form
    {
        private TradeManager tradeManager;

        public TradingView()
        {
            InitializeComponent();
            tradeManager = new TradeManager(this);
            candleChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            candleChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
        }

        private void startWebsocketButton_Click(object sender, EventArgs e)
        {
            candleChart.Series[0].Points.Clear();
            tradeManager.StartTrading(apiKeyText.Text, apiSecretText.Text);
        }

        private void stopWebsocketButton_Click(object sender, EventArgs e)
        {
            tradeManager.StopTrading();
        }

        //Delegate because addvalue is accessed from a different thread
        delegate void AddValueCallback(BinanceKline k, bool updateValue);

        public void AddValue(BinanceKline k, bool updateValue)
        {
            if (candleChart.InvokeRequired) {
                AddValueCallback d = new AddValueCallback(AddValue);
                this.Invoke(d, k, updateValue);
            }
            else
            {
                if (updateValue)
                {
                    //Same as last candle, update values
                    candleChart.Series[0].Points.RemoveAt(candleChart.Series[0].Points.Count - 1);
                    candleChart.Series[0].Points.AddXY(k.OpenTime, k.High, k.Low, k.Open, k.Close);

                } else {
                    //New candle
                    candleChart.Series[0].Points.AddXY(k.OpenTime, k.High, k.Low, k.Open, k.Close);

                    if (candleChart.Series[0].Points.Count > 50)
                    {
                        if (candleChart.Series["Transaction"].Points.Count > 0 && candleChart.Series["Transaction"].Points[0].XValue == candleChart.Series["Price"].Points[0].XValue)
                        {
                            candleChart.Series["Transaction"].Points.RemoveAt(0);
                        }
                        candleChart.Series[0].Points.RemoveAt(0);
                    }
                }

                candleChart.ChartAreas[0].RecalculateAxesScale();
            }
        }

        delegate void AddCandlesCallback(List<BinanceKline> candles);

        public void AddCandles(List<BinanceKline> candles) {
            if (candleChart.InvokeRequired) {
                AddCandlesCallback d = new AddCandlesCallback(AddCandles);
                this.Invoke(d, candles);
            } else {
                foreach (BinanceKline k in candles)
                {
                    candleChart.Series[0].Points.AddXY(k.OpenTime, k.High, k.Low, k.Open, k.Close);

                    if (candleChart.Series[0].Points.Count > 100)
                    {
                        if (candleChart.Series["Transaction"].Points.Count > 0 && candleChart.Series["Transaction"].Points[0].XValue == candleChart.Series["Price"].Points[0].XValue)
                        {
                            candleChart.Series["Transaction"].Points.RemoveAt(0);
                        }
                        candleChart.Series[0].Points.RemoveAt(0);
                    }
                }
                candleChart.ChartAreas[0].RecalculateAxesScale();
            }
        }

        delegate void PlaceMarkerCallback(DateTime openTime, decimal close, Color color);

        public void PlaceMarker(DateTime openTime, decimal close, Color color) {
            if (candleChart.InvokeRequired) {
                PlaceMarkerCallback d = new PlaceMarkerCallback(PlaceMarker);
                this.Invoke(d, openTime, close, color);
            } else {
                candleChart.Series["Transaction"].Points.AddXY(openTime, close);
                candleChart.Series["Transaction"].Points[candleChart.Series["Transaction"].Points.Count - 1].Color = color;
                candleChart.Series["Transaction"].Points[candleChart.Series["Transaction"].Points.Count - 1].Label = "@ " + close;
            }
        }

        public void ShowMessage(string text) {
            MessageBox.Show(text);
        }
    }
}
