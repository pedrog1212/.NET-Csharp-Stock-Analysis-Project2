using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject2
{
    /// <summary>
    /// Class that holds all the functions technically necessary for analyzing the stock data
    /// </summary>
    public class TechnicalAnalizer
    {
        /// <summary>
        /// Reads candlestick data from a CSV file and returns a list of Candlestick objects.
        /// The CSV file must have columns in this order: Date, Open, High, Low, Close, Volume.
        /// The method automatically adjusts for descending date order in the file.
        /// </summary>
        /// <param name="path">The file path of the CSV to read.</param>
        /// <returns>A list of Candlestick objects parsed from the CSV file.</returns>
        public static List<Candlestick> ReadFromCSVFile(string path)
        {
            //clear existing data
            List<Candlestick> candlestickData = new List<Candlestick>();

            //make a StreamReader to open the file
            StreamReader reader = new StreamReader(File.OpenRead(path));

            //read header line and ignore it
            reader.ReadLine();

            //loop through each line of the file, until we get to the end of the file
            while (!reader.EndOfStream)
            {
                //here is where we can access each line as its read in
                var line = reader.ReadLine();

                //specify the delimiters to split the string
                char[] delimiters = { ',', '"' };

                //split the line into the values it holds
                var values = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                //convert values to correct data types
                DateTime date = Convert.ToDateTime(values[0], CultureInfo.InvariantCulture);
                decimal open = Convert.ToDecimal(values[1]);
                decimal high = Convert.ToDecimal(values[2]);
                decimal low = Convert.ToDecimal(values[3]);
                decimal close = Convert.ToDecimal(values[4]);
                ulong volume = Convert.ToUInt64(values[5]
                    );

                //create Candlestick object using the constructor
                Candlestick candlestick = new Candlestick(date, open, high, low, close, volume);

                //store the values in a list,m
                candlestickData.Add(candlestick);
            }
            //close the file
            reader.Close();
            //reverse the data so it displayed from the start date to end date if it is in descending order
            if (candlestickData[0].Date > candlestickData[1].Date)
                candlestickData.Reverse();

            //return the list of candlestick objects
            return candlestickData;
        }

        /// <summary>
        /// Filters the data received from the ReadFromCSVFile function
        /// to only include data between the picked dates of start and end
        /// dateTimePickers. Also checks if the file picked has data between
        /// the start and end date, and if it doesn't an error box is shown
        /// prompting the user to cancel or choose a different file
        /// </summary>
        /// <param name="start">The start date of the filter range.</param>
        /// <param name="end">The end date of the filter range.</param>
        public static List<Candlestick> filterData(List<Candlestick> candlesticks, DateTime start, DateTime end)
        {
            //use Select while ensuring the start date is included
            List<Candlestick> filteredData = candlesticks
                .Where(candle => candle.Date >= start && candle.Date <= end)
                .Select(candle => new Candlestick(candle.Date, candle.Open, candle.High, candle.Low, candle.Close, candle.Volume)) // Create new objects
                .ToList();

            //return the filtered list of candlestick objects
            return filteredData;
        }

        /// <summary>
        /// Finds peaks and valleys using increasing margin values and stores them in a dictionary.
        /// each margin value corresponds to a list of PeakAndValleys objects.
        /// </summary>
        /// <param name="filteredCandlesticks">list of filtered candlestick data</param>
        /// <returns>dictionary where key = margin and value = list of PeakAndValleys</returns>
        public static Dictionary<int, List<PeakAndValleys>> assignPeaksAndValleysDict(List<Candlestick> filteredCandlesticks)
        {
            //create the dictionary to store results for each margin
            var dictPVList = new Dictionary<int, List<PeakAndValleys>>();

            //start with margin = 1
            int margin = 1;

            //loop indefinitely until no peaks or valleys are found for a margin
            while (true)
            {
                //create a new list to store peaks and valleys for this margin
                var peaksAndValleysList = new List<PeakAndValleys>();

                //flag to check if we found any peaks or valleys at this margin
                bool foundAny = false;

                //loop through all candles, skipping the margin on both sides
                for (int i = margin; i < filteredCandlesticks.Count - margin; i++)
                {
                    var current = filteredCandlesticks[i];

                    //assume current is both peak and valley until proven otherwise
                    bool isPeak = true;
                    bool isValley = true;

                    //loop through the margin to compare neighbors on both sides
                    for (int j = 1; j <= margin; j++)
                    {
                        var left = filteredCandlesticks[i - j];
                        var right = filteredCandlesticks[i + j];

                        if (current.High <= left.High || current.High <= right.High)
                            isPeak = false;

                        if (current.Low >= left.Low || current.Low >= right.Low)
                            isValley = false;
                    }

                    if (!isPeak && !isValley)
                        continue;

                    foundAny = true;

                    //if peak, create peak object
                    if (isPeak)
                    {
                        int leftMargin = 0, rightMargin = 0;

                        //look left for the first higher candle
                        for (int l = i - 1; l >= 0; l--)
                        {
                            leftMargin++;
                            if (filteredCandlesticks[l].High > current.High)
                                break;
                        }

                        //look right for the first higher candle
                        for (int r = i + 1; r < filteredCandlesticks.Count; r++)
                        {
                            rightMargin++;
                            if (filteredCandlesticks[r].High > current.High)
                                break;
                        }

                        //create a new peak PeakAndValleys object using the current candlestick's data
                        var peak = new PeakAndValleys(
                            current.Date,
                            current.Open,
                            current.High,
                            current.Low,
                            current.Close,
                            current.Volume)
                        {
                            isPeak = true,
                            isValley = false,
                            leftMargin = leftMargin,
                            rightMargin = rightMargin
                        };

                        peaksAndValleysList.Add(peak);
                    }

                    //if valley, create valley object
                    if (isValley)
                    {
                        int leftMargin = 0, rightMargin = 0;

                        //look left for the first lower candle
                        for (int l = i - 1; l >= 0; l--)
                        {
                            leftMargin++;
                            if (filteredCandlesticks[l].Low < current.Low)
                                break;
                        }

                        //look right for the first lower candle
                        for (int r = i + 1; r < filteredCandlesticks.Count; r++)
                        {
                            rightMargin++;
                            if (filteredCandlesticks[r].Low < current.Low)
                                break;
                        }

                        //create a new valley PeakAndValleys object using the current candlestick's data
                        var valley = new PeakAndValleys(
                            current.Date,
                            current.Open,
                            current.High,
                            current.Low,
                            current.Close,
                            current.Volume)
                        {
                            isPeak = false,
                            isValley = true,
                            leftMargin = leftMargin,
                            rightMargin = rightMargin
                        };

                        peaksAndValleysList.Add(valley);
                    }
                }

                //if no peaks or valleys were found for this margin, exit the loop early
                if (!foundAny)
                    break;

                //store the list of peaks and valleys found for this margin level into the dictionary and increase the margin
                dictPVList[margin] = peaksAndValleysList;
                margin++;
            }

            //return the dictionary containing margin-wise lists of peaks and valleys
            return dictPVList;
        }

        /// <summary>
        /// Goes through the list of peaks and valleys and identifies valid up and down waves.
        /// An up wave is a segment from a valley to a peak with no lower low in between.
        /// A down wave is a segment from a peak to a valley with no higher high in between.
        /// </summary>
        /// <param name="peaksAndValleys">The list of candlesticks marked as peaks or valleys.</param>
        /// <param name="filteredCandlesticks">The list of candlesticks displayed in the chart.</param>
        /// <returns>
        /// A tuple containing two lists:
        /// - The first list holds valid up waves in the format "startDate - endDate".
        /// - The second list holds valid down waves in the same format.
        /// </returns>
        public static (List<string> upWaves, List<string> downWaves) getUpAndDownWaveDates(List<PeakAndValleys> peaksAndValleys, List<Candlestick> filteredCandlesticks)
        {
            //create lists to store wave date ranges as strings
            List<string> upWaves = new List<string>();
            List<string> downWaves = new List<string>();

            //iterate over each starting point (peak or valley)
            for (int i = 0; i < peaksAndValleys.Count; i++)
            {
                var start = peaksAndValleys[i];
                DateTime startDate = start.Date;

                //search for the index of the start date in the filtered candlesticks
                int startIndex = -1;
                for (int s = 0; s < filteredCandlesticks.Count; s++)
                {
                    //if the index is found assign it to startIndex
                    if (filteredCandlesticks[s].Date == startDate)
                    {
                        startIndex = s;
                        break;
                    }
                }

                //if not found, skip this iteration
                if (startIndex == -1) continue;

                //attempt to find valid wave pairings with future peaks/valleys
                for (int j = i + 1; j < peaksAndValleys.Count; j++)
                {
                    var end = peaksAndValleys[j];
                    DateTime endDate = end.Date;

                    //🚫 skip wave if dates are equal (same-day wave is invalid)
                    if (startDate == endDate) continue;

                    //search for the index of the end date in the filtered candlesticks
                    int endIndex = -1;
                    for (int e = 0; e < filteredCandlesticks.Count; e++)
                    {
                        //if the index is found assign it to endIndex
                        if (filteredCandlesticks[e].Date == endDate)
                        {
                            endIndex = e;
                            break;
                        }
                    }

                    //if end index not found, skip
                    if (endIndex == -1) continue;

                    //check for valid up wave (valley to peak)
                    if (start.isValley && end.isPeak)
                    {
                        bool startReachesEnd = startIndex + start.rightMargin >= endIndex;
                        bool endReachesStart = endIndex - end.leftMargin <= startIndex;

                        if (startReachesEnd && endReachesStart)
                        {
                            upWaves.Add($"{startDate:MM/dd/yyyy} - {endDate:MM/dd/yyyy}");
                        }
                    }
                    //check for valid down wave (peak to valley)
                    else if (start.isPeak && end.isValley)
                    {
                        bool startReachesEnd = startIndex + start.rightMargin >= endIndex;
                        bool endReachesStart = endIndex - end.leftMargin <= startIndex;

                        if (startReachesEnd && endReachesStart)
                        {
                            downWaves.Add($"{startDate:MM/dd/yyyy} - {endDate:MM/dd/yyyy}");
                        }
                    }
                }
            }

            //return both wave lists as a tuple
            return (upWaves, downWaves);
        }

    }
}
