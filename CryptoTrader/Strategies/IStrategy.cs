using Binance.Net.Objects.Spot.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Strategies
{
    public interface IStrategy
    {
        bool ShouldBuy(List<BinanceKline> candles);

        bool ShouldSell(List<BinanceKline> candles);
    }
}
