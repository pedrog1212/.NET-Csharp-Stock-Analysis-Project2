using System;

namespace StockProject2
{
    //class representing a single candlestick data point in stock trading.
    public class Candlestick
    {
        //date of the candlestick.
        public DateTime Date { get; set; }

        //opening price of the stock for the given date.
        public decimal Open { get; set; }

        //highest price reached during the given date.
        public decimal High { get; set; }

        //lowest price reached during the given date.
        public decimal Low { get; set; }

        //closing price of the stock for the given date.
        public decimal Close { get; set; }

        //trading volume of the stock for the given date.
        public ulong Volume { get; set; }

        //constructor to initialize the Candlestick object with the required data.
        public Candlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, ulong volume)
        {
            //validate that the low price is not greater than the high price.
            if (low > high)
                throw new ArgumentException("Low price cannot be greater than high price.");

            //validate that the open price is within the high-low range.
            if (open < low || open > high)
                throw new ArgumentException("Open price must be within high-low range.");

            //validate that the close price is within the high-low range.
            if (close < low || close > high)
                throw new ArgumentException("Close price must be within high-low range.");

            //assign values to the properties.
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }
    }
}
