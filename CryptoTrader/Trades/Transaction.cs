using Binance.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Trades
{
    public class Transaction
    {
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Amount { get; set; }
        public decimal Profit { get; }


        public Transaction(decimal buyPrice, decimal sellPrice, decimal amount) {
            this.BuyPrice = buyPrice;
            this.SellPrice = sellPrice;
            this.Amount = amount;
            this.Profit = (sellPrice - buyPrice) * amount;
        }
    }
}
