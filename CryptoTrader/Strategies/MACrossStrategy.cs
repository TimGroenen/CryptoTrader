using CryptoTrader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Strategies
{
    public class MACrossStrategy : IStrategy
    {
        //This strategy uses the short and long moving average and buys or sells when the moving averages cross
        public bool ShouldBuy(List<IndicatorKline> candles)
        {
            if (candles.Count < 2) return false;

            //Short MA crosses Long MA upward
            return candles[candles.Count - 1].ShortMovingAverage > candles[candles.Count - 1].LongMovingAverage
                && candles[candles.Count - 2].ShortMovingAverage < candles[candles.Count - 2].LongMovingAverage;
        }

        public bool ShouldSell(List<IndicatorKline> candles)
        {
            if (candles.Count < 2) return false;

            //Short MA crosses Long MA downward
            return candles[candles.Count - 1].ShortMovingAverage < candles[candles.Count - 1].LongMovingAverage
                && candles[candles.Count - 2].ShortMovingAverage > candles[candles.Count - 2].LongMovingAverage;
        }
    }
}
