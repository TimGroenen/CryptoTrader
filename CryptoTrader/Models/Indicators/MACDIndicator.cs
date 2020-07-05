using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CryptoTrader.Models.Indicators
{
    public class MACDIndicator
    {
        public EMAIndicator EMA12;
        public EMAIndicator EMA26;
        public decimal Value;
        public decimal Signal;
        public decimal Histo;

        public MACDIndicator(IndicatorKline thisKline, List<IndicatorKline> pastKlines) {
            //Calculate a 12 - period EMA of the price for the chosen time period.
            EMA12 = new EMAIndicator(thisKline, pastKlines, 12, false);

            //Calculate a 26 - period EMA of the price for the chosen time period.
            EMA26 = new EMAIndicator(thisKline, pastKlines, 26, false);

            //Subtract the 26 - period EMA from the 12 - period EMA.
            Value = EMA12.Value - EMA26.Value;

            //Calculate a nine - period EMA of the result obtained from step 3.
            Signal = CalculateDiffEMA(thisKline, pastKlines);

            Histo = Value - Signal;
        }

        private decimal CalculateDiffEMA(IndicatorKline thisKline, List<IndicatorKline> pastKlines) {
            int maLength = 9;
            decimal multiplier = 2 / ((decimal)maLength + 1);

            if (pastKlines.Count <= 0) return 0;

            if (pastKlines[pastKlines.Count - 1].MACD.Signal < 0)
            {
                //Calculate first SMA
                if (maLength > pastKlines.Count) return 0;

                decimal priceSum = Value;
                for (int x = 1; x <= maLength; x++)
                {
                    priceSum += pastKlines[pastKlines.Count - x].MACD.Value;
                }

                return priceSum / ((decimal)maLength + 1);
            }
            else
            {
                //Calculate EMA
                return ((Value - pastKlines[pastKlines.Count - 1].MACD.Signal) * multiplier) + pastKlines[pastKlines.Count - 1].MACD.Signal;
            }
        }
    }
}
