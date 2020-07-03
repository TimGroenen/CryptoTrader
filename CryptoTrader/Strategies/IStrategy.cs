using Binance.Net.Objects.Spot.MarketData;
using CryptoTrader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Strategies
{
    public interface IStrategy
    {
        bool ShouldBuy(List<IndicatorKline> candles);

        bool ShouldSell(List<IndicatorKline> candles);
    }
}
