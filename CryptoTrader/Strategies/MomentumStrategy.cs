using Binance.Net.Objects.Spot.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Strategies
{
    class MomentumStrategy : IStrategy
    {
        public bool ShouldBuy(List<BinanceKline> candles)
        {
            if (candles.Count < 5) return false;

            return (candles[candles.Count - 1].Close - candles[candles.Count - 2].Open > (candles[candles.Count - 2].Close / 10000) * 4)&& candles[candles.Count - 2].Open < candles[candles.Count - 2].Close;
        }

        public bool ShouldSell(List<BinanceKline> candles)
        {
            if (candles.Count < 5) return false;

            return candles[candles.Count - 2].Close - candles[candles.Count - 1].Close > (candles[candles.Count - 2].Close / 10000);
        }
    }
}
