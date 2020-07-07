using System.Collections.Generic;

namespace CryptoTraderLibrary.Models.Indicators
{
    public class EMAIndicator
    {
        public decimal Multiplier { get; set; }
        public int MALength { get; set; }
        public decimal Value { get; set; }

        public EMAIndicator(IndicatorKline thisKline, List<IndicatorKline> pastKlines, int maLength, bool shortMA) {
            MALength = maLength;
            Multiplier = 2 / ((decimal)MALength + 1);

            if (pastKlines.Count <= 0)
            {
                Value = -1;
                return;
            }

            if ((pastKlines[pastKlines.Count - 1].ShortMovingAverage.Value < 0 && shortMA) || (!shortMA && pastKlines[pastKlines.Count - 1].LongMovingAverage.Value < 0))
            {
                //Calculate first SMA
                if (MALength > pastKlines.Count) { 
                    Value = -1; 
                    return; 
                }

                decimal priceSum = thisKline.Close;
                for (int x = 1; x <= MALength; x++)
                {
                    priceSum += pastKlines[pastKlines.Count - x].Close;
                }

                Value = priceSum / (MALength + 1);
            } else {
                if (shortMA)
                {
                    //Calculate Short EMA
                    Value = ((thisKline.Close - pastKlines[pastKlines.Count - 1].ShortMovingAverage.Value) * Multiplier) + pastKlines[pastKlines.Count - 1].ShortMovingAverage.Value;
                }
                else
                {
                    //Calculate Long EMA
                    Value = ((thisKline.Close - pastKlines[pastKlines.Count - 1].LongMovingAverage.Value) * Multiplier) + pastKlines[pastKlines.Count - 1].LongMovingAverage.Value;
                }
            }
        }
    }
}
