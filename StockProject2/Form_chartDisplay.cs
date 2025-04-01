using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockProject2
{
    public partial class Form_chartDisplay : Form
    {
        //bool to check whether the form is valid and allowed to be displayed
        public bool isValid { get; private set; } = false;

        //dictionary to cache peak and valley lists for different margin values
        public Dictionary<int, List<PeakAndValleys>> peakValleyDict = new Dictionary<int, List<PeakAndValleys>>();

        //number of neighboring candlesticks to check on both sides to determine if a candlestick is a peak or valley
        public int margin;

        //lists to store the total candlestick data of a chosen file
        public List<Candlestick> candlesticks;

        //lists to store the just the candlestick data from a start to end date from the total candlestick data
        public List<Candlestick> filteredData;

        //list to store all the candlesticks which are either peaks or valleys
        public List<PeakAndValleys> peakAndValleyCandlesticks;

        //binding source for data binding the chart
        BindingSource bindingSource = new BindingSource();

        //variable to hold the path to a file as a string
        private string filePath;

        //default constructor
        public Form_chartDisplay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the Form_chartDisplay window and loads the stock chart for the selected file and date range.
        /// it reads candlestick data from the file, filters it by date, calculates peaks and valleys for a given margin,
        /// and sets up the chart display along with wave selection combo boxes. if no valid data exists for the range,
        /// an error popup is shown instead and the chart is not rendered.
        /// </summary>
        /// <param name="path">full file path to the CSV file containing candlestick data</param>
        /// <param name="start">start date for the range to filter the data</param>
        /// <param name="end">end date for the range to filter the data</param>
        public Form_chartDisplay(string path, DateTime start, DateTime end)
        {
            //initialize components
            InitializeComponent();

            //read the total candlestick data from the chosen file and hold it in a list of candlesticks
            candlesticks = TechnicalAnalizer.ReadFromCSVFile(path);

            //store the just the candlestick data from a start to end date from the total candlestick data in a list of candlesticks
            filteredData = TechnicalAnalizer.filterData(candlesticks, start, end);

            //number of neighboring candlesticks to check on both sides to determine if a candlestick is a peak or valley
            margin = hScrollBar_margin.Value;

            //fill the dictionary 
            peakValleyDict = TechnicalAnalizer.assignPeaksAndValleysDict(filteredData);

            //only assign if dictionary has this margin
            if (peakValleyDict.ContainsKey(margin))
            {
                //list of PeakAndValley objects which hold all the candlesticks which are peaks or valleys, retrieved from dictionary or computed
                peakAndValleyCandlesticks = peakValleyDict[margin];
            }
            else
            {
                //make the list empty to avoid null
                peakAndValleyCandlesticks = new List<PeakAndValleys>(); 
            }

            //fill the filePath variable with a string file path
            filePath = path;

            //make the caption of the form the same as the path to the displayed file
            this.Text = path;

            //values for the the start and end for the filtered data
            dateTimePicker_start.Value = start;
            dateTimePicker_end.Value = end;

            //if the dates for the filtered list are empty call a the incorrectDatesWarning() method to show a error popup
            if (filteredData.Count == 0)
            {
                //display a warning message since there are no values 
                incorrectDatesWarning();
                return;
            }
            else
            {
                //if the code reaches the else the form is valid
                isValid = true;

                //display the candlesticks in filtered list on the chart
                displayChart();

                //function to fill the wave comboboxes with waves
                populateWaveComboBoxes();
            }
        }


        /// <summary>
        /// Function that controls what happens when the update button is clicked
        /// </summary>
        /// <param name="sender">the control that triggered the event (button)</param>
        /// <param name="e">event data associated with the click</param>
        private void button_update_Click(object sender, EventArgs e)
        {
            //fill the filePath variable with a string file path
            this.Text = filePath;

            //store the just the candlestick data from a start to end date from the total candlestick data in a list of candlesticks
            filteredData = TechnicalAnalizer.filterData(candlesticks, dateTimePicker_start.Value, dateTimePicker_end.Value);

            //list of PeakAndValley objects which hold all the candlesticks which are peaks or valleys, retrieved from dictionary or computed
            peakValleyDict = TechnicalAnalizer.assignPeaksAndValleysDict(filteredData);

            //only assign if dictionary has this margin
            if (peakValleyDict.ContainsKey(margin))
            {
                //list of PeakAndValley objects which hold all the candlesticks which are peaks or valleys, retrieved from dictionary or computed
                peakAndValleyCandlesticks = peakValleyDict[margin];
            }
            else
            {
                //make the list empty to avoid null
                peakAndValleyCandlesticks = new List<PeakAndValleys>();
            }

            //if the dates for the filtered list are empty call a the incorrectDatesWarning() method to show a error popup
            if (filteredData.Count == 0)
            {
                //function for displaying an error
                incorrectDatesWarning();
            }
            else
            {
                //display the candlesticks in filtered list on the chart
                displayChart();

                //function to fill the wave comboboxes with waves
                populateWaveComboBoxes();

                //call the clear waves function
                clearWaveAnnotations();

                //force the redrawing of the chart after adding annotations
                chart_candlestick.Invalidate(); 
                chart_candlestick.Update();
            }
        }

        /// <summary>
        /// Function that controls what happens when the horizontal scroll bar is moved
        /// </summary>
        /// <param name="sender">the control that triggered the event (button)</param>
        /// <param name="e">event data associated with the click</param>
        private void hScrollBar_margin_Scroll(object sender, ScrollEventArgs e)
        {
            //make the margin equal to the value of the scroll bar
            margin = hScrollBar_margin.Value;

            //make the text of label_margin the number value of the scroll bar
            label_margin.Text = margin.ToString();

            //if the dictionary contains a list at the current margin display it
            if (peakValleyDict.ContainsKey(margin))
            {
                //fill a list of PeakAndValley objects using the dictionary
                peakAndValleyCandlesticks = peakValleyDict[margin];

                //re-annotate peaks/valleys and update wave comboboxes
                annotatePeakAndValleys();
                populateWaveComboBoxes();
            }
            else
            {
                //clear chart annotations and comboboxes if no data for this margin
                clearPeakValleyAnnotations();
                comboBox_wavesUp.Items.Clear();
                comboBox_wavesDown.Items.Clear();
            }

            //force the chart to redraw and show updates
            chart_candlestick.Invalidate();
            chart_candlestick.Update();
        }

        /// <summary>
        /// Function that controls what happens when the value of the comboBox_wavesUp is changed
        /// </summary>
        /// <param name="sender">the control that triggered the event (button)</param>
        /// <param name="e">event data associated with the click</param>
        private void comboBox_wavesUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //call the function to draw the chosen wave on the chart
            drawWave(comboBox_wavesUp.SelectedItem.ToString(), Color.Green, true);
        }

        /// <summary>
        /// Function that controls what happens when the value of the comboBox_wavesDown is changed
        /// </summary>
        /// <param name="sender">the control that triggered the event (button)</param>
        /// <param name="e">event data associated with the click</param>
        private void comboBox_wavesDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //call the function to draw the chosen wave on the chart
            drawWave(comboBox_wavesDown.SelectedItem.ToString(), Color.Red, false); ;
        }

        /// <summary>
        /// Function that controls what happens when the value of the button_clearPV is clicked
        /// </summary>
        /// <param name="sender">the control that triggered the event (button)</param>
        /// <param name="e">event data associated with the click</param>
        private void button_clearPV_Click(object sender, EventArgs e)
        {
            //call the function to clear all peak and valley annotations
            clearPeakValleyAnnotations();
        }

        /// <summary>
        /// Function that controls what happens when the value of the button_clearWaves is clicked
        /// </summary>
        /// <param name="sender">the control that triggered the event (button)</param>
        /// <param name="e">event data associated with the click</param>
        private void button_clearWaves_Click(object sender, EventArgs e)
        {
            //restore X indexing so peak/valley annotations match up correctly
            chart_candlestick.Series["Series_CandleStick"].IsXValueIndexed = true;
            //call the function to clear all the wave annotations on the chart
            clearWaveAnnotations();
        }

        /// <summary>
        /// Displays the chart with the current filtered candlestick data 
        /// and the needed peak and valley annotations.
        /// </summary>
        private void displayChart()
        {
            //clear the binding sorce
            bindingSource.ResetBindings(false);

            //call the normalize function to make the chart look better
            normalizeChart();

            //bind the binding source to the chart
            bindingSource.DataSource = filteredData;

            //bind the binding source to the chart
            chart_candlestick.DataSource = bindingSource;
            chart_candlestick.DataBind();

            //call the function to put all the annotations for each peak and valley
            annotatePeakAndValleys();
        }

        /// <summary>
        /// Sets the max and min of chart's Y-Axis to be slightly larger/smaller than the max/min values.
        /// </summary>
        private void normalizeChart()
        {
            //get the lowest and highest prices from the filtered data for Y-axis scaling
            decimal minValue = filteredData.Min(candle => candle.Low);
            decimal maxValue = filteredData.Max(candle => candle.High);

            //calculate padding to add space above and below the candlestick range
            decimal padding = (maxValue - minValue) * 0.2m;

            //adjust the min and max values by subtracting and adding padding
            minValue -= padding;
            maxValue += padding;

            //round the adjusted values to 2 decimal places for a cleaner display
            minValue = Math.Round(minValue, 2);
            maxValue = Math.Round(maxValue, 2);

            //apply the adjusted min and max values to the chart's Y-axis
            chart_candlestick.ChartAreas["ChartArea_CandleStick"].AxisY.Minimum = (double)minValue;
            chart_candlestick.ChartAreas["ChartArea_CandleStick"].AxisY.Maximum = (double)maxValue;
        }

        /// <summary>
        /// Populates the wave combo boxes with valid up and down waves.
        /// </summary>
        private void populateWaveComboBoxes()
        {
            //populate the string lists of upWaves and downWaves with their respective waves
            var (upWaves, downWaves) = TechnicalAnalizer.getUpAndDownWaveDates(peakAndValleyCandlesticks, filteredData);

            //clear the comboboxes
            comboBox_wavesUp.Items.Clear();
            comboBox_wavesDown.Items.Clear();

            //populate the comboboxes
            comboBox_wavesUp.Items.AddRange(upWaves.ToArray());
            comboBox_wavesDown.Items.AddRange(downWaves.ToArray());
        }

        /// <summary>
        /// Draws a line annotation on the chart for the selected wave.
        /// </summary>
        private void drawWave(string waveText, Color color, bool isUpWave)
        {
            //return early if no wave is selected
            if (string.IsNullOrEmpty(waveText)) return;

            //split the wave string into start and end dates
            string[] dates = waveText.Split(new[] { " - " }, StringSplitOptions.None);
            DateTime startDate = DateTime.Parse(dates[0].Trim());
            DateTime endDate = DateTime.Parse(dates[1].Trim());

            //initialize index positions
            int startIndex = -1;
            int endIndex = -1;

            //find index positions in the filtered candlesticks list
            for (int i = 0; i < filteredData.Count; i++)
            {
                if (filteredData[i].Date == startDate)
                    startIndex = i;
                if (filteredData[i].Date == endDate)
                    endIndex = i;
            }

            //return if either index is invalid
            if (startIndex == -1 || endIndex == -1) return;

            //initialize peak and valley references
            PeakAndValleys peakAtStart = null;
            PeakAndValleys valleyAtStart = null;
            PeakAndValleys peakAtEnd = null;
            PeakAndValleys valleyAtEnd = null;

            //search for each possible role for both dates
            foreach (PeakAndValleys pv in peakAndValleyCandlesticks)
            {
                if (pv.Date == startDate)
                {
                    if (pv.isPeak) peakAtStart = pv;
                    if (pv.isValley) valleyAtStart = pv;
                }
                else if (pv.Date == endDate)
                {
                    if (pv.isPeak) peakAtEnd = pv;
                    if (pv.isValley) valleyAtEnd = pv;
                }
            }

            //determine wave endpoints based on direction
            PeakAndValleys startPoint = null;
            PeakAndValleys endPoint = null;

            if (isUpWave)
            {
                //up wave goes from valley to peak
                startPoint = valleyAtStart ?? valleyAtEnd;
                endPoint = peakAtEnd ?? peakAtStart;
            }
            else
            {
                //down wave goes from peak to valley
                startPoint = peakAtStart ?? peakAtEnd;
                endPoint = valleyAtEnd ?? valleyAtStart;
            }

            //return if proper roles not found
            if (startPoint == null || endPoint == null) return;

            //get OADate and price for drawing
            double startX = startPoint.Date.ToOADate();
            double startY = (double)(isUpWave ? startPoint.Low : startPoint.High);
            double endX = endPoint.Date.ToOADate();
            double endY = (double)(isUpWave ? endPoint.High : endPoint.Low);

            DataPoint startPt = new DataPoint(startX, startY);
            DataPoint endPt = new DataPoint(endX, endY);

            //generate unique name with wave type
            string waveTag = isUpWave ? "Up" : "Down";
            string seriesName = $"WaveAnchorSeries_{startIndex}_{endIndex}_{waveTag}";
            if (!chart_candlestick.Series.IsUniqueName(seriesName)) return;

            //create a temporary point series to anchor the annotation
            Series tempSeries = new Series(seriesName)
            {
                ChartType = SeriesChartType.Point,
                ChartArea = "ChartArea_CandleStick",
                IsXValueIndexed = false
            };
            tempSeries.Points.Add(startPt);
            tempSeries.Points.Add(endPt);
            chart_candlestick.Series.Add(tempSeries);

            //ensure the chart uses actual date values
            chart_candlestick.Series["Series_CandleStick"].IsXValueIndexed = false;

            //create the wave annotation
            LineAnnotation waveAnnotation = new LineAnnotation
            {
                LineColor = color,
                LineWidth = 2,
                LineDashStyle = ChartDashStyle.Dash,
                ToolTip = $"{startPoint.Date.ToShortDateString()} to {endPoint.Date.ToShortDateString()}",
                Visible = true,
                AxisX = chart_candlestick.ChartAreas["ChartArea_CandleStick"].AxisX,
                AxisY = chart_candlestick.ChartAreas["ChartArea_CandleStick"].AxisY,
                IsSizeAlwaysRelative = false,
                Name = $"wave_{startIndex}_{endIndex}_{waveTag}"
            };
            waveAnnotation.SetAnchor(tempSeries.Points[0], tempSeries.Points[1]);

            //add annotation to chart
            chart_candlestick.Annotations.Add(waveAnnotation);

            //force the chart to redraw and show the new annotations
            chart_candlestick.Invalidate();
        }

        /// <summary>
        /// Adds red "▼" for peaks and green "▲" for valleys on the candlestick chart,
        /// or both for a candlestick thats both a peak and valley.
        /// </summary>
        private void annotatePeakAndValleys()
        {
            //clear all existing annotations from the chart
            clearPeakValleyAnnotations();

            //get the candlestick chart area where annotations will be placed
            ChartArea chart = chart_candlestick.ChartAreas["ChartArea_CandleStick"];

            ////calculate an offset based on the Y-axis range
            double yMin = chart.AxisY.Minimum;
            double yMax = chart.AxisY.Maximum;
            double offset = (yMax - yMin) * 0.08; // 8% of range

            //loop through each peak or valley in the list
            foreach (var pv in peakAndValleyCandlesticks)
            {
                //find the index of the candlestick in the filtered data using the date
                int index = filteredData.FindIndex(c => c.Date == pv.Date);
                if (index == -1) continue;

                //get the matching data point from the candlestick series
                DataPoint dataPoint = chart_candlestick.Series["Series_CandleStick"].Points[index];

                //choose the symbol and color based on whether it's a peak or valley
                string symbol = pv.isPeak ? "▼" : "▲";
                Color color = pv.isPeak ? Color.Red : Color.Green;

                //apply vertical offset
                double anchorY = pv.isPeak ? (double)pv.High + offset: (double)pv.Low - offset;

                //create the annotation if the candlestick is both a peak and valley, else just make a regular peak or valley annotation
                if (pv.isPeak && pv.isValley)
                {
                    anchorY = (double)pv.High + offset;
                    //create the peak annotation
                    TextAnnotation annotation = new TextAnnotation
                    {
                        Text = "▼",
                        ForeColor = Color.Red,
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        Name = $"peak_{index}",
                        Alignment = ContentAlignment.MiddleCenter,
                        AnchorAlignment = ContentAlignment.MiddleCenter,
                        ClipToChartArea = chart.Name,
                        AnchorX = index + 1,
                        AnchorY = anchorY,
                        AnchorDataPoint = dataPoint
                    };

                    //set the anchorY to be for a valley annotation 
                    anchorY = (double)pv.Low - offset;

                    //create the valley annotation
                    TextAnnotation annotation2 = new TextAnnotation
                    {
                        Text = "▲",
                        ForeColor = Color.Green,
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        Name = $"valley_{index}",
                        Alignment = ContentAlignment.MiddleCenter,
                        AnchorAlignment = ContentAlignment.MiddleCenter,
                        ClipToChartArea = chart.Name,
                        AnchorX = index + 1,
                        AnchorY = anchorY,
                        AnchorDataPoint = dataPoint
                    };

                    //add the annotation to the chart
                    chart_candlestick.Annotations.Add(annotation);
                    chart_candlestick.Annotations.Add(annotation2);
                }
                else
                {
                    //create the annotation
                    TextAnnotation annotation = new TextAnnotation
                    {
                        Text = symbol,
                        ForeColor = color,
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        Name = pv.isPeak ? $"peak_{index}" : $"valley_{index}",
                        Alignment = ContentAlignment.MiddleCenter,
                        AnchorAlignment = ContentAlignment.MiddleCenter,
                        ClipToChartArea = chart.Name,
                        AnchorX = index + 1,
                        AnchorY = anchorY,
                        AnchorDataPoint = dataPoint
                    };

                    //add the annotation to the chart
                    chart_candlestick.Annotations.Add(annotation);
                }
            }

            //force the chart to redraw and show the new annotations
            chart_candlestick.Invalidate();
            chart_candlestick.Update();
        }

        /// <summary>
        /// Removes all annotations related to peaks and valleys from the chart.
        /// </summary>
        private void clearPeakValleyAnnotations()
        {
            //get all annotations whose name starts with "peak_" or "valley_"
            var annotationsToRemove = chart_candlestick.Annotations
                .Where(a => a.Name.StartsWith("peak_") || a.Name.StartsWith("valley_"))
                .ToList();

            //loop through each annotation and remove it from the chart
            foreach (var annotation in annotationsToRemove)
            {
                chart_candlestick.Annotations.Remove(annotation);
            }

            //force the chart to redraw and reflect changes
            chart_candlestick.Invalidate();
            chart_candlestick.Update();
        }

        /// <summary>
        /// Removes all wave line annotations from the chart (those starting with "wave_").
        /// </summary>
        private void clearWaveAnnotations()
        {
            try
            {
                //make the waves up combo box show empty if there is a value in it
                comboBox_wavesUp.SelectedIndex = -1;
            }
            catch { }

            try
            {
                //make the waves down combo box show empty if there is a value in it
                comboBox_wavesDown.SelectedIndex = -1;
            }
            catch { }

            //get all annotations whose name starts with "wave_"
            var waveAnnotations = chart_candlestick.Annotations
                .Where(a => a.Name.StartsWith("wave_"))
                .ToList();

            //remove each wave annotation from the chart
            foreach (var annotation in waveAnnotations)
            {
                chart_candlestick.Annotations.Remove(annotation);
            }

            //get all wave anchor series (e.g., "WaveAnchorSeries_9_11")
            var anchorSeries = chart_candlestick.Series
                .Where(s => s.Name.StartsWith("WaveAnchorSeries_"))
                .ToList();

            //remove all wave anchor series
            foreach (var series in anchorSeries)
            {
                chart_candlestick.Series.Remove(series);
            }

            //set the main candlestick series to use X-value indexing again
            chart_candlestick.Series["Series_CandleStick"].IsXValueIndexed = true;

            //force the chart to redraw with updates
            chart_candlestick.Invalidate();
            chart_candlestick.Update();
        }

        /// <summary>
        /// Function to show a warning message if user choses dates that
        /// have no corresponding values in the filtered data list
        /// </summary>
        private void incorrectDatesWarning()
        {
            //create and display a warning message box with a file-specific message
            DialogResult result = MessageBox.Show(
                $"The selected file '{filePath}' has no values between these dates. Change the file or the dates",
                "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            //set the form title to show loading error
            this.Text = "Error Loading File";
        }
    }
}
