using CryptoTraderLibrary.Models;
using System.Collections.Generic;

namespace CryptoTraderLibrary.Interfaces
{
    public interface IStrategy
    {
        bool ShouldBuy(List<IndicatorKline> candles);

        bool ShouldSell(List<IndicatorKline> candles);
    }
}
