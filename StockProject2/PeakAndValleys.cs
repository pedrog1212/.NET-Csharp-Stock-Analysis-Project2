using System;

namespace StockProject2
{
    //child class of Candlestick that includes peak and valley analysis data
    public class PeakAndValleys : Candlestick
    {
        //true if the candlestick is identified as a peak
        public bool isPeak { get; set; }

        //true if the candlestick is identified as a valley
        public bool isValley { get; set; }

        //number of candlesticks to the left used for comparison in peak/valley detection
        public int leftMargin { get; set; }

        //number of candlesticks to the right used for comparison in peak/valley detection
        public int rightMargin { get; set; }

        //constructor to initialize base candlestick and margin values
        public PeakAndValleys(DateTime date, decimal open, decimal high, decimal low, decimal close, ulong volume)
            : base(date, open, high, low, close, volume) //initialize base candlestick
        {
            isPeak = false;
            isValley = false;
            leftMargin = 0;
            rightMargin = 0;
        }
    }
}
