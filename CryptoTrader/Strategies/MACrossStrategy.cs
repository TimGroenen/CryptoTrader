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

            if (candles.Count > 5 && candles[candles.Count - 5].LongMovingAverage.Value > 0) {
                //Don't buy when price is going sideways
                bool sideways = true;

                //Check last five candles
                for (int i = 1; i < 6; i++) {
                    decimal percentageChange = ((candles[candles.Count - (i + 1)].Close - candles[candles.Count - i].Close) / candles[candles.Count - i].Close) * 100;
                    if (!(percentageChange < 0.25M && percentageChange > -0.25M)) sideways = false;
                }

                if (sideways) return false;
            }

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
