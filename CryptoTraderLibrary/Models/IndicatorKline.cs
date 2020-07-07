using Binance.Net.Objects.Spot.MarketData;
using CryptoTraderLibrary.Models.Indicators;
using System;
using System.Collections.Generic;

namespace CryptoTraderLibrary.Models
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
        public EMAIndicator ShortMovingAverage { get; set; }
        public EMAIndicator LongMovingAverage { get; set; }

        //MACD
        public MACDIndicator MACD { get; set; }

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

            //Calculate moving averages
            ShortMovingAverage = new EMAIndicator(this, pastKlines, shortMA, true);
            LongMovingAverage = new EMAIndicator(this, pastKlines, longMA, false);

            //Calculate MACD
            MACD = new MACDIndicator(this, pastKlines);
        }
    }
}
