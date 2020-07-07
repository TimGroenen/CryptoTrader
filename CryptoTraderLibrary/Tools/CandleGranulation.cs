using Binance.Net.Objects.Spot.MarketData;
using CryptoTraderLibrary.Models;
using CryptoTraderLibrary.Trades;
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
    }
}
