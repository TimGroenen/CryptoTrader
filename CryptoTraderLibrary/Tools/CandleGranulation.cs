using Binance.Net.Objects.Spot.MarketData;
using CryptoTraderLibrary.Models;
using CryptoTraderLibrary.Trades;
using System;
using System.Collections.Generic;

namespace CryptoTraderLibrary.Tools
{
    static class CandleGranulation
    {
        private const decimal minDiff = (decimal)0.000001;

        //Increase the number of candles to simulate websocket speed
        //Average from open to close with x amount of steps
        public static List<IndicatorKline> AverageOpenToClose(List<IndicatorKline> input, int steps, TradeManagerConfig config) 
        {
            List<IndicatorKline> output = new List<IndicatorKline>();

            foreach (IndicatorKline candle in input) 
            {
                //Calculate difference between open and close
                decimal diff = candle.Close - candle.Open;
                decimal step = diff / (decimal)steps;

                //Skip candles that do not pass the min difference
                if ((diff < minDiff && diff > 0) || (diff > minDiff * -1 && diff < 0)) {
                    output.Add(candle);
                    continue;
                }

                for (int i = 0; i < steps; i++) {
                    BinanceKline newKline = new BinanceKline
                    {
                        //Set open and close
                        Open = candle.Open,
                        Close = i == 0 ? candle.Open + step : output[output.Count - 1].Close + step,

                        //Divide volumes by steps
                        Volume = candle.Volume / steps,
                        QuoteAssetVolume = candle.QuoteAssetVolume / steps,
                        TakerBuyQuoteAssetVolume = candle.TakerBuyQuoteAssetVolume / steps,
                        TakerBuyBaseAssetVolume = candle.TakerBuyBaseAssetVolume / steps,
                        TradeCount = candle.TradeCount / steps,

                        //Take time data and highs and lows from original kline
                        OpenTime = candle.OpenTime,
                        CloseTime = candle.CloseTime,
                        High = candle.High,
                        Low = candle.Low
                    };

                    output.Add(new IndicatorKline(newKline, output, config.ShortMA, config.LongMA));
                }
            }

            return output;
        }

        //Converts one candle to 3 candles open-low -> low-high -> high-close or open-high -> high-low -> low - close randomly
        //Only if high or low are higher and lower than open and close
        public static List<IndicatorKline> IncludeHighsAndLows(List<IndicatorKline> input, TradeManagerConfig config) {
            List<IndicatorKline> output = new List<IndicatorKline>();
            Random r = new Random();

            foreach (IndicatorKline candle in input) {
                if (r.NextDouble() >= 0.50) {
                    //open-low
                    BinanceKline openLow = new BinanceKline
                    {
                        //Set open and close
                        Open = candle.Open,
                        Close = candle.Low,

                        //Divide volumes by steps
                        Volume = candle.Volume / 3,
                        QuoteAssetVolume = candle.QuoteAssetVolume / 3,
                        TakerBuyQuoteAssetVolume = candle.TakerBuyQuoteAssetVolume / 3,
                        TakerBuyBaseAssetVolume = candle.TakerBuyBaseAssetVolume / 3,
                        TradeCount = candle.TradeCount / 3,

                        //Take time data and highs and lows from original kline
                        OpenTime = candle.OpenTime,
                        CloseTime = candle.CloseTime,
                        High = candle.Open,
                        Low = candle.Low
                    };

                    output.Add(new IndicatorKline(openLow, output, config.ShortMA, config.LongMA));

                    //low-high
                    BinanceKline lowHigh = new BinanceKline
                    {
                        //Set open and close
                        Open = candle.Open,
                        Close = candle.High,

                        //Divide volumes by steps
                        Volume = candle.Volume / 3,
                        QuoteAssetVolume = candle.QuoteAssetVolume / 3,
                        TakerBuyQuoteAssetVolume = candle.TakerBuyQuoteAssetVolume / 3,
                        TakerBuyBaseAssetVolume = candle.TakerBuyBaseAssetVolume / 3,
                        TradeCount = candle.TradeCount / 3,

                        //Take time data and highs and lows from original kline
                        OpenTime = candle.OpenTime,
                        CloseTime = candle.CloseTime,
                        High = candle.High,
                        Low = candle.Low
                    };

                    output.Add(new IndicatorKline(lowHigh, output, config.ShortMA, config.LongMA));

                    //high-close
                    BinanceKline highClose = new BinanceKline
                    {
                        //Set open and close
                        Open = candle.Open,
                        Close = candle.Close,

                        //Divide volumes by steps
                        Volume = candle.Volume / 3,
                        QuoteAssetVolume = candle.QuoteAssetVolume / 3,
                        TakerBuyQuoteAssetVolume = candle.TakerBuyQuoteAssetVolume / 3,
                        TakerBuyBaseAssetVolume = candle.TakerBuyBaseAssetVolume / 3,
                        TradeCount = candle.TradeCount / 3,

                        //Take time data and highs and lows from original kline
                        OpenTime = candle.OpenTime,
                        CloseTime = candle.CloseTime,
                        High = candle.High,
                        Low = candle.Low
                    };

                    output.Add(new IndicatorKline(highClose, output, config.ShortMA, config.LongMA));
                } else {
                    //open-high
                    BinanceKline openHigh = new BinanceKline
                    {
                        //Set open and close
                        Open = candle.Open,
                        Close = candle.High,

                        //Divide volumes by steps
                        Volume = candle.Volume / 3,
                        QuoteAssetVolume = candle.QuoteAssetVolume / 3,
                        TakerBuyQuoteAssetVolume = candle.TakerBuyQuoteAssetVolume / 3,
                        TakerBuyBaseAssetVolume = candle.TakerBuyBaseAssetVolume / 3,
                        TradeCount = candle.TradeCount / 3,

                        //Take time data and highs and lows from original kline
                        OpenTime = candle.OpenTime,
                        CloseTime = candle.CloseTime,
                        High = candle.High,
                        Low = candle.Open
                    };

                    output.Add(new IndicatorKline(openHigh, output, config.ShortMA, config.LongMA));

                    //high - low
                    BinanceKline highLow = new BinanceKline
                    {
                        //Set open and close
                        Open = candle.Open,
                        Close = candle.Low,

                        //Divide volumes by steps
                        Volume = candle.Volume / 3,
                        QuoteAssetVolume = candle.QuoteAssetVolume / 3,
                        TakerBuyQuoteAssetVolume = candle.TakerBuyQuoteAssetVolume / 3,
                        TakerBuyBaseAssetVolume = candle.TakerBuyBaseAssetVolume / 3,
                        TradeCount = candle.TradeCount / 3,

                        //Take time data and highs and lows from original kline
                        OpenTime = candle.OpenTime,
                        CloseTime = candle.CloseTime,
                        High = candle.High,
                        Low = candle.Low
                    };

                    output.Add(new IndicatorKline(highLow, output, config.ShortMA, config.LongMA));

                    //low - close
                    BinanceKline lowClose = new BinanceKline
                    {
                        //Set open and close
                        Open = candle.Open,
                        Close = candle.Close,

                        //Divide volumes by steps
                        Volume = candle.Volume / 3,
                        QuoteAssetVolume = candle.QuoteAssetVolume / 3,
                        TakerBuyQuoteAssetVolume = candle.TakerBuyQuoteAssetVolume / 3,
                        TakerBuyBaseAssetVolume = candle.TakerBuyBaseAssetVolume / 3,
                        TradeCount = candle.TradeCount / 3,

                        //Take time data and highs and lows from original kline
                        OpenTime = candle.OpenTime,
                        CloseTime = candle.CloseTime,
                        High = candle.High,
                        Low = candle.Low
                    };

                    output.Add(new IndicatorKline(lowClose, output, config.ShortMA, config.LongMA));
                }
            }

            return output;
        }
    }
}
