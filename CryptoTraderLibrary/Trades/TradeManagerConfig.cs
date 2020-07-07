using Binance.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTraderLibrary.Trades
{
    public class TradeManagerConfig
    {
        public decimal BalanceStart { get; set; }
        public decimal PercentageBuy { get; set; }
        public int ShortMA { get; set; }
        public int LongMA { get; set; }
        public KlineInterval interval { get; set; }

        public TradeManagerConfig(decimal balanceStart, decimal percentageBuy, int shortMA, int longMA, KlineInterval interval) {
            this.BalanceStart = balanceStart;
            this.PercentageBuy = percentageBuy;
            ShortMA = shortMA;
            LongMA = longMA;
            this.interval = interval;
        }
    }
}
