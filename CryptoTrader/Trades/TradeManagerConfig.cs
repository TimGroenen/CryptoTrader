using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Trades
{
    public class TradeManagerConfig
    {
        public decimal BalanceStart { get; set; }
        public decimal PercentageBuy { get; set; }

        public TradeManagerConfig(decimal balanceStart, decimal percentageBuy) {
            this.BalanceStart = balanceStart;
            this.PercentageBuy = percentageBuy;
        }
    }
}
