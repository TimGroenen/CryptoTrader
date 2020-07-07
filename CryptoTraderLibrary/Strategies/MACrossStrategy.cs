using CryptoTraderLibrary.Models;
using CryptoTraderLibrary.Interfaces;
using System.Collections.Generic;

namespace CryptoTraderLibrary.Strategies
{
    public class MACrossStrategy : IStrategy
    {
        //This strategy uses the short and long moving average and buys or sells when the moving averages cross
        public bool ShouldBuy(List<IndicatorKline> candles)
        {
            if (candles.Count < 5) return false;

            //Short MA crosses Long MA upward
            return candles[candles.Count - 1].ShortMovingAverage.Value > candles[candles.Count - 1].LongMovingAverage.Value
                && candles[candles.Count - 2].ShortMovingAverage.Value < candles[candles.Count - 2].LongMovingAverage.Value;
        }

        public bool ShouldSell(List<IndicatorKline> candles)
        {
            if (candles.Count < 5) return false;

            //Short MA crosses Long MA downward
            return candles[candles.Count - 1].ShortMovingAverage.Value < candles[candles.Count - 1].LongMovingAverage.Value
                && candles[candles.Count - 2].ShortMovingAverage.Value > candles[candles.Count - 2].LongMovingAverage.Value;
        }
    }
}
