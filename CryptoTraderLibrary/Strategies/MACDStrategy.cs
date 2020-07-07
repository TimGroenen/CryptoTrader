using CryptoTraderLibrary.Interfaces;
using CryptoTraderLibrary.Models;
using System.Collections.Generic;

namespace CryptoTraderLibrary.Strategies
{
    public class MACDStrategy : IStrategy
    {
        public bool ShouldBuy(List<IndicatorKline> candles)
        {
            if (candles.Count <= 1) return false;

            return (candles[candles.Count - 1].MACD.Signal <= candles[candles.Count - 1].MACD.Value) 
                && (candles[candles.Count - 2].MACD.Signal > candles[candles.Count - 2].MACD.Value);
        }

        public bool ShouldSell(List<IndicatorKline> candles)
        {
            if (candles.Count <= 1) return false;

            return (candles[candles.Count - 1].MACD.Signal >= candles[candles.Count - 1].MACD.Value) 
                && (candles[candles.Count - 2].MACD.Signal < candles[candles.Count - 2].MACD.Value);
        }
    }
}
