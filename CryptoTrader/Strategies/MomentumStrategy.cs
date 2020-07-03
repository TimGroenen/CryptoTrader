using Binance.Net.Objects.Spot.MarketData;
using CryptoTrader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Strategies
{
    class MomentumStrategy : IStrategy
    {
        public bool ShouldBuy(List<IndicatorKline> candles)
        {
            if (candles.Count < 5) return false;

            bool firstPositive = candles[candles.Count - 1].Close > candles[candles.Count - 1].Open;
            bool secondPositive = candles[candles.Count - 2].Close > candles[candles.Count - 2].Open;
            return (firstPositive && secondPositive) || (candles[candles.Count - 1].Close - candles[candles.Count - 2].Open > (candles[candles.Count - 2].Close / 10000) * 4);
        }

        public bool ShouldSell(List<IndicatorKline> candles)
        {
            if (candles.Count < 5) return false;

            return candles[candles.Count - 2].Close - candles[candles.Count - 1].Close > (candles[candles.Count - 2].Close / 5000);
        }
    }
}
