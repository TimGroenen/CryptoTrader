using System;
using System.Collections.Generic;
using System.Drawing;
using CryptoTraderLibrary.Interfaces;
using CryptoTraderLibrary.Models;
using CryptoTraderLibrary.Trades;

namespace CryptoTrader.Trading
{
    public class UIConnection : IUIConnection
    {
        TradingView tradeView;

        public UIConnection(TradingView tradeView) {
            this.tradeView = tradeView;
        }

        public void AddCandles(List<IndicatorKline> pastCandles)
        {
            tradeView.AddCandles(pastCandles);
        }

        public void AddValue(IndicatorKline k, bool newCandle)
        {
            tradeView.AddValue(k, newCandle);
        }

        public void PlaceMarker(DateTime openTime, decimal close, Color color)
        {
            tradeView.PlaceMarker(openTime, close, color);
        }

        public void ShowMessage(string text)
        {
            tradeView.ShowMessage(text);        
        }

        public void UpdateUIText(decimal currentBalance, decimal currentAltBalance, Transaction t)
        {
            tradeView.UpdateUIText(currentBalance, currentAltBalance, t);
        }
    }
}
