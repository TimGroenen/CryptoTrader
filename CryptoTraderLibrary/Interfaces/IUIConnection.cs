using CryptoTraderLibrary.Models;
using CryptoTraderLibrary.Trades;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace CryptoTraderLibrary.Interfaces
{
    public interface IUIConnection
    {
        //Connect the trading algorithm back to the UI
        void ShowMessage(string text);

        void AddValue(IndicatorKline k, bool newCandle);

        void AddCandles(List<IndicatorKline> pastCandles);

        void PlaceMarker(DateTime openTime, decimal close, Color color);

        void UpdateUIText(decimal currentBalance, decimal currentAltBalance, Transaction t);
    }
}