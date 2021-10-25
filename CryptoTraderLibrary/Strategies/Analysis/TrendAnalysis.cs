using CryptoTraderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTraderLibrary.Strategies.Analysis
{
    public static class TrendAnalysis
    {
        public static TrendType GetCurrentTrend(List<IndicatorKline> pastKlines, int timeFrame) {
            //Calculate pricechange average over timeframe
            decimal pricechange = ((pastKlines[pastKlines.Count - 1].Close - pastKlines[pastKlines.Count - timeFrame].Open) / pastKlines[pastKlines.Count - timeFrame].Open) * 100;

            if (pricechange > 0.75M) {
                return TrendType.UP;
            } else if (pricechange < -0.75M) {
                return TrendType.DOWN;
            }
            return TrendType.SIDE;
        }
    }
}
