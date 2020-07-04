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
        private decimal shortMultiplier;
        private decimal longMultiplier;

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
            shortMultiplier = 2 / ((decimal)shortMA + 1);
            this.longMA = longMA;
            longMultiplier = 2 / ((decimal)longMA + 1);

            ShortMovingAverage = CalculateShortEMA(pastKlines);
            LongMovingAverage = CalculateLongEMA(pastKlines);
        }

        private decimal CalculateShortEMA(List<IndicatorKline> pastKlines) {
            if (pastKlines.Count <= 0) return -1;

            if (pastKlines[pastKlines.Count - 1].ShortMovingAverage < 0)
            {
                //Calculate first SMA
                if (shortMA > pastKlines.Count) return -1;

                decimal priceSum = Close;
                for (int x = 1; x <= shortMA; x++)
                {
                    priceSum += pastKlines[pastKlines.Count - x].Close;
                }

                return priceSum / (shortMA + 1);
            } else {
                //Calculate EMA
                return ((Close - pastKlines[pastKlines.Count - 1].ShortMovingAverage) * shortMultiplier) + pastKlines[pastKlines.Count - 1].ShortMovingAverage;
            }
        }
        private decimal CalculateLongEMA(List<IndicatorKline> pastKlines)
        {
            if (pastKlines.Count <= 0) return -1;

            if (pastKlines[pastKlines.Count - 1].LongMovingAverage < 0)
            {
                //Calculate first SMA
                if (longMA > pastKlines.Count) return -1;

                decimal priceSum = Close;
                for (int x = 1; x <= longMA; x++)
                {
                    priceSum += pastKlines[pastKlines.Count - x].Close;
                }

                return priceSum / (longMA + 1);
            }
            else
            {
                //Calculate EMA
                return ((Close - pastKlines[pastKlines.Count - 1].LongMovingAverage) * longMultiplier) + pastKlines[pastKlines.Count - 1].LongMovingAverage;
            }
        }

    }
}
