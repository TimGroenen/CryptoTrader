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

            //Check if volume of past candles is going up
            if (!(candles[candles.Count - 1].Volume > candles[candles.Count - 2].Volume && candles[candles.Count - 2].Volume > candles[candles.Count - 3].Volume)) return false;

            //Short MA crosses Long MA upward
            return candles[candles.Count - 1].ShortMovingAverage.Value > candles[candles.Count - 1].LongMovingAverage.Value
                && candles[candles.Count - 2].ShortMovingAverage.Value < candles[candles.Count - 2].LongMovingAverage.Value;
        }

        public bool ShouldSell(List<IndicatorKline> candles)
        {
            if (candles.Count < 2) return false;

            //Short MA crosses Long MA downward
            return candles[candles.Count - 1].ShortMovingAverage.Value < candles[candles.Count - 1].LongMovingAverage.Value
                && candles[candles.Count - 2].ShortMovingAverage.Value > candles[candles.Count - 2].LongMovingAverage.Value;
        }
    }
}
