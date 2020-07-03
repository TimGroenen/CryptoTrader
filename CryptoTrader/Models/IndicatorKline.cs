using Binance.Net.Objects.Spot.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Models
{
    public class IndicatorKline
    {
        //IndicatorKline
        public DateTime OpenTime { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public DateTime CloseTime { get; set; }
        public decimal QuoteAssetVolume { get; set; }
        public int TradeCount { get; set; }
        public decimal TakerBuyBaseAssetVolume { get; set; }
        public decimal TakerBuyQuoteAssetVolume { get; set; }

        //Moving average
        public decimal ShortMovingAverage { get; set; }
        public decimal LongMovingAverage { get; set; }

        private int shortMA = 25;
        private int longMA = 100;

        public IndicatorKline(BinanceKline kline, List<IndicatorKline> pastKlines, int shortMA, int longMA) {
            OpenTime = kline.OpenTime;
            Open = kline.Open;
            High = kline.High;
            Low = kline.Low;
            Close = kline.Close;
            Volume = kline.Volume;
            CloseTime = kline.CloseTime;
            QuoteAssetVolume = kline.QuoteAssetVolume;
            TradeCount = kline.TradeCount;
            TakerBuyBaseAssetVolume = kline.TakerBuyBaseAssetVolume;
            TakerBuyQuoteAssetVolume = kline.TakerBuyQuoteAssetVolume;

            this.shortMA = shortMA;
            this.longMA = longMA;

            ShortMovingAverage = CalculateMA(shortMA, pastKlines);
            LongMovingAverage = CalculateMA(longMA, pastKlines);
        }

        private decimal CalculateMA(int maLength, List<IndicatorKline> pastKlines) {
            if (maLength > pastKlines.Count) return -1;

            decimal priceSum = Close;
            for (int x = 1; x <= maLength; x++) {
                priceSum += pastKlines[pastKlines.Count - x].Close;
            }

            return priceSum / (maLength + 1);
        }
    }
}
