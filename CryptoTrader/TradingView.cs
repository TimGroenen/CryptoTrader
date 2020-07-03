using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Binance.Net.Objects.Spot.MarketData;
using CryptoTrader.Models;
using CryptoTrader.Strategies;
using CryptoTrader.Trades;

namespace CryptoTrader
{
    public partial class TradingView : Form
    {
        private TradeManager tradeManager;
        private List<Transaction> transactions;
        private int numTrades = 0;
        private decimal avgProfit = 0;
        private decimal totalProfit = 0;

        public TradingView()
        {
            InitializeComponent();
            candleChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            transactions = new List<Transaction>();
            BackTestDate.MaxDate = DateTime.Now;
        }

        private void startWebsocketButton_Click(object sender, EventArgs e)
        {
            tradeManager = new TradeManager(this, new TradeManagerConfig(TrainingStartBalanceNum.Value, BuySizePercentage.Value, (int)ShortMANum.Value, (int)LongMANum.Value), new MomentumStrategy());
            candleChart.Series[0].Points.Clear();
            candleChart.Series[1].Points.Clear();
            candleChart.Series[2].Points.Clear();
            candleChart.Series[3].Points.Clear();
            tradeManager.StartLiveTrading(apiKeyText.Text, apiSecretText.Text);
        }

        private void stopWebsocketButton_Click(object sender, EventArgs e)
        {
            if (tradeManager == null) { 
                ShowMessage("No socket active");
                return;
            }

            tradeManager.StopLiveTrading();
        }

        //Delegate because addvalue is accessed from a different thread
        delegate void AddValueCallback(IndicatorKline k, bool updateValue);

        public void AddValue(IndicatorKline k, bool updateValue)
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
                    candleChart.Series["Price"].Points.RemoveAt(candleChart.Series["Price"].Points.Count - 1);
                    candleChart.Series["Price"].Points.AddXY(k.OpenTime, k.High, k.Low, k.Open, k.Close);

                    if (k.ShortMovingAverage > 0 && candleChart.Series["ShortMA"].Points.Count > 0) { 
                        candleChart.Series["ShortMA"].Points.RemoveAt(candleChart.Series["ShortMA"].Points.Count - 1);
                        candleChart.Series["ShortMA"].Points.AddXY(k.OpenTime, k.ShortMovingAverage);

                        if (k.LongMovingAverage > 0 && candleChart.Series["LongMA"].Points.Count > 0)
                        {
                            candleChart.Series["LongMA"].Points.RemoveAt(candleChart.Series["LongMA"].Points.Count - 1);
                            candleChart.Series["LongMA"].Points.AddXY(k.OpenTime, k.LongMovingAverage);
                        }
                    }
                } else {
                    //New candle
                    candleChart.Series["Price"].Points.AddXY(k.OpenTime, k.High, k.Low, k.Open, k.Close);

                    if (k.ShortMovingAverage > 0)
                    {
                        candleChart.Series["ShortMA"].Points.AddXY(k.OpenTime, k.ShortMovingAverage);

                        if (k.LongMovingAverage > 0)
                        {
                            candleChart.Series["LongMA"].Points.AddXY(k.OpenTime, k.LongMovingAverage);
                        }
                    }

                    //Remove candles
                    if (candleChart.Series[0].Points.Count > 100)
                    {
                        if (candleChart.Series["Transaction"].Points.Count > 0 && candleChart.Series["Transaction"].Points[0].XValue < candleChart.Series["Price"].Points[0].XValue)
                        {
                            candleChart.Series["Transaction"].Points.RemoveAt(0);
                        }
                        if (candleChart.Series["ShortMA"].Points.Count > 100) {
                            candleChart.Series["ShortMA"].Points.RemoveAt(0);
                        }
                        if (candleChart.Series["LongMA"].Points.Count > 100) {
                            candleChart.Series["LongMA"].Points.RemoveAt(0);
                        }
                        candleChart.Series["Price"].Points.RemoveAt(0);
                    }
                }

                candleChart.ChartAreas[0].RecalculateAxesScale();
            }
        }

        delegate void AddCandlesCallback(List<IndicatorKline> candles);

        public void AddCandles(List<IndicatorKline> candles) {
            if (candleChart.InvokeRequired) {
                AddCandlesCallback d = new AddCandlesCallback(AddCandles);
                this.Invoke(d, candles);
            } else {
                foreach (IndicatorKline k in candles)
                {
                    candleChart.Series["Price"].Points.AddXY(k.OpenTime, k.High, k.Low, k.Open, k.Close);

                    if (candleChart.Series["Price"].Points.Count > 100)
                    {
                        if (candleChart.Series["Transaction"].Points.Count > 0 && candleChart.Series["Transaction"].Points[0].XValue < candleChart.Series["Price"].Points[0].XValue)
                        {
                            candleChart.Series["Transaction"].Points.RemoveAt(0);
                        }
                        if (candleChart.Series["ShortMA"].Points.Count > 100)
                        {
                            candleChart.Series["ShortMA"].Points.RemoveAt(0);
                        }
                        if (candleChart.Series["LongMA"].Points.Count > 100)
                        {
                            candleChart.Series["LongMA"].Points.RemoveAt(0);
                        }
                        candleChart.Series["Price"].Points.RemoveAt(0);
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

        delegate void UpdateUITextCallback(decimal currentBalance, decimal currentAltBalance, Transaction t);

        public void UpdateUIText(decimal currentBalance, decimal currentAltBalance, Transaction t)
        {
            if (candleChart.InvokeRequired)
            {
                UpdateUITextCallback d = new UpdateUITextCallback(UpdateUIText);
                this.Invoke(d, currentBalance, currentAltBalance, t);
            } else { 
                CurrentBalanceLabel.Text = "Current Balance: " + currentBalance;
                CurrentAltBalanceLabel.Text = "Current Alt Balance: " + currentAltBalance;

                if (t != null) {
                    transactions.Add(t);
                    numTrades++;
                    totalProfit += t.Profit;
                    avgProfit = totalProfit / numTrades;

                    TotalTradesLabel.Text = "Total trades: " + numTrades;
                    TotalProfitLabel.Text = "Total profit: " + Math.Round((((currentBalance - TrainingStartBalanceNum.Value) / TrainingStartBalanceNum.Value) * 100), 2);
                    AverageProfitLabel.Text = "Average profit: " + avgProfit;
                    HodlProfitLabel.Text = "HODL profit: " + Math.Round((((transactions[transactions.Count - 1].SellPrice - transactions[0].BuyPrice) / transactions[0].BuyPrice) * 100), 2);
                }
            }
        }

        public void ShowMessage(string text) {
            MessageBox.Show(text);
        }

        private void BackTestButton_Click(object sender, EventArgs e)
        {
            tradeManager = new TradeManager(this, new TradeManagerConfig(TrainingStartBalanceNum.Value, BuySizePercentage.Value, (int)ShortMANum.Value, (int)LongMANum.Value), new MomentumStrategy());
            candleChart.Series[0].Points.Clear();
            candleChart.Series[1].Points.Clear();
            candleChart.Series[2].Points.Clear();
            candleChart.Series[3].Points.Clear();
            tradeManager.StartBackTesting(apiKeyText.Text, apiSecretText.Text, BackTestDate.Value);
        }
    }
}
