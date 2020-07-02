using Binance.Net.Objects.Spot.MarketData;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.Tools
{
    static class CandleGranulation
    {
        private const decimal minDiff = (decimal)0.000001;

        //Increase the number of candles to simulate websocket speed
        //Average from open to close with x amount of steps
        public static List<BinanceKline> AverageOpenToClose(List<BinanceKline> input, int steps) 
        {
            List<BinanceKline> output = new List<BinanceKline>();

            foreach (BinanceKline candle in input) 
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
                    BinanceKline newKline = new BinanceKline();

                    //Set open and close
                    newKline.Open = candle.Open;
                    newKline.Close = i == 0 ? candle.Open + step : output[output.Count - 1].Close + step;

                    //Divide volumes by steps
                    newKline.Volume = candle.Volume / steps;
                    newKline.QuoteAssetVolume = candle.QuoteAssetVolume / steps;
                    newKline.TakerBuyQuoteAssetVolume = candle.TakerBuyQuoteAssetVolume / steps;
                    newKline.TakerBuyBaseAssetVolume = candle.TakerBuyBaseAssetVolume / steps;
                    newKline.TradeCount = candle.TradeCount / steps;

                    //Take time data and highs and lows from original kline
                    newKline.OpenTime = candle.OpenTime;
                    newKline.CloseTime = candle.CloseTime;
                    newKline.High = candle.High;
                    newKline.Low = candle.Low;

                    output.Add(newKline);
                }
            }

            return output;
        }        
    }
}
