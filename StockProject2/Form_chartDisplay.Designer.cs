namespace StockProject2
{
    partial class Form_chartDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.button_update = new System.Windows.Forms.Button();
            this.chart_candlestick = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.hScrollBar_margin = new System.Windows.Forms.HScrollBar();
            this.label_margin = new System.Windows.Forms.Label();
            this.label_end = new System.Windows.Forms.Label();
            this.label_start = new System.Windows.Forms.Label();
            this.label_waveEnd = new System.Windows.Forms.Label();
            this.label_waveUP = new System.Windows.Forms.Label();
            this.comboBox_wavesDown = new System.Windows.Forms.ComboBox();
            this.comboBox_wavesUp = new System.Windows.Forms.ComboBox();
            this.button_clearPV = new System.Windows.Forms.Button();
            this.button_clearWaves = new System.Windows.Forms.Button();
            this.bindingSource_candlestick = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlestick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_candlestick)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker_start.Location = new System.Drawing.Point(12, 443);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_start.TabIndex = 0;
            this.dateTimePicker_start.Value = new System.DateTime(2024, 1, 16, 0, 0, 0, 0);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker_end.Location = new System.Drawing.Point(12, 503);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_end.TabIndex = 3;
            this.dateTimePicker_end.Value = new System.DateTime(2025, 2, 25, 0, 0, 0, 0);
            // 
            // button_update
            // 
            this.button_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_update.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_update.Location = new System.Drawing.Point(543, 418);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(336, 51);
            this.button_update.TabIndex = 1;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // chart_candlestick
            // 
            this.chart_candlestick.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisY.Title = "Price ($)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea_CandleStick";
            chartArea2.AlignWithChartArea = "ChartArea_CandleStick";
            chartArea2.AxisX.Title = "Date";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Impact", 12F);
            chartArea2.AxisY.Title = "Stock Shares";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Impact", 12F);
            chartArea2.Name = "ChartArea_Volume";
            this.chart_candlestick.ChartAreas.Add(chartArea1);
            this.chart_candlestick.ChartAreas.Add(chartArea2);
            this.chart_candlestick.Location = new System.Drawing.Point(0, 0);
            this.chart_candlestick.Name = "chart_candlestick";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea_CandleStick";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Chartreuse";
            series1.IsXValueIndexed = true;
            series1.Name = "Series_CandleStick";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "High, Low, Open, Close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.IsXValueIndexed = true;
            series2.Name = "Series_Volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "Volume";
            this.chart_candlestick.Series.Add(series1);
            this.chart_candlestick.Series.Add(series2);
            this.chart_candlestick.Size = new System.Drawing.Size(891, 409);
            this.chart_candlestick.TabIndex = 22;
            this.chart_candlestick.Text = "chart1";
            this.chart_candlestick.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // hScrollBar_margin
            // 
            this.hScrollBar_margin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hScrollBar_margin.LargeChange = 1;
            this.hScrollBar_margin.Location = new System.Drawing.Point(231, 503);
            this.hScrollBar_margin.Maximum = 8;
            this.hScrollBar_margin.Minimum = 1;
            this.hScrollBar_margin.Name = "hScrollBar_margin";
            this.hScrollBar_margin.Size = new System.Drawing.Size(248, 20);
            this.hScrollBar_margin.TabIndex = 23;
            this.hScrollBar_margin.Value = 1;
            this.hScrollBar_margin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_margin_Scroll);
            // 
            // label_margin
            // 
            this.label_margin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_margin.AutoSize = true;
            this.label_margin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_margin.Location = new System.Drawing.Point(229, 485);
            this.label_margin.Name = "label_margin";
            this.label_margin.Size = new System.Drawing.Size(57, 16);
            this.label_margin.TabIndex = 24;
            this.label_margin.Text = "Margin : ";
            // 
            // label_end
            // 
            this.label_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_end.AutoSize = true;
            this.label_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_end.Location = new System.Drawing.Point(15, 485);
            this.label_end.Name = "label_end";
            this.label_end.Size = new System.Drawing.Size(63, 16);
            this.label_end.TabIndex = 27;
            this.label_end.Text = "End Date";
            // 
            // label_start
            // 
            this.label_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_start.AutoSize = true;
            this.label_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_start.Location = new System.Drawing.Point(12, 425);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(66, 16);
            this.label_start.TabIndex = 26;
            this.label_start.Text = "Start Date";
            // 
            // label_waveEnd
            // 
            this.label_waveEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_waveEnd.AutoSize = true;
            this.label_waveEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_waveEnd.Location = new System.Drawing.Point(388, 423);
            this.label_waveEnd.Name = "label_waveEnd";
            this.label_waveEnd.Size = new System.Drawing.Size(87, 16);
            this.label_waveEnd.TabIndex = 31;
            this.label_waveEnd.Text = "Down Waves";
            // 
            // label_waveUP
            // 
            this.label_waveUP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_waveUP.AutoSize = true;
            this.label_waveUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_waveUP.Location = new System.Drawing.Point(228, 423);
            this.label_waveUP.Name = "label_waveUP";
            this.label_waveUP.Size = new System.Drawing.Size(71, 16);
            this.label_waveUP.TabIndex = 30;
            this.label_waveUP.Text = "Up Waves";
            // 
            // comboBox_wavesDown
            // 
            this.comboBox_wavesDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_wavesDown.FormattingEnabled = true;
            this.comboBox_wavesDown.Location = new System.Drawing.Point(389, 442);
            this.comboBox_wavesDown.Name = "comboBox_wavesDown";
            this.comboBox_wavesDown.Size = new System.Drawing.Size(148, 21);
            this.comboBox_wavesDown.TabIndex = 29;
            this.comboBox_wavesDown.SelectedIndexChanged += new System.EventHandler(this.comboBox_wavesDown_SelectedIndexChanged);
            // 
            // comboBox_wavesUp
            // 
            this.comboBox_wavesUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_wavesUp.FormattingEnabled = true;
            this.comboBox_wavesUp.Items.AddRange(new object[] {
            "12/12/2024 – 12/12/2024"});
            this.comboBox_wavesUp.Location = new System.Drawing.Point(231, 442);
            this.comboBox_wavesUp.Name = "comboBox_wavesUp";
            this.comboBox_wavesUp.Size = new System.Drawing.Size(152, 21);
            this.comboBox_wavesUp.TabIndex = 28;
            this.comboBox_wavesUp.SelectedIndexChanged += new System.EventHandler(this.comboBox_wavesUp_SelectedIndexChanged);
            // 
            // button_clearPV
            // 
            this.button_clearPV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_clearPV.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button_clearPV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clearPV.Location = new System.Drawing.Point(543, 478);
            this.button_clearPV.Name = "button_clearPV";
            this.button_clearPV.Size = new System.Drawing.Size(145, 46);
            this.button_clearPV.TabIndex = 32;
            this.button_clearPV.Text = "Clear Peaks and Valleys";
            this.button_clearPV.UseVisualStyleBackColor = false;
            this.button_clearPV.Click += new System.EventHandler(this.button_clearPV_Click);
            // 
            // button_clearWaves
            // 
            this.button_clearWaves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_clearWaves.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button_clearWaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clearWaves.Location = new System.Drawing.Point(734, 478);
            this.button_clearWaves.Name = "button_clearWaves";
            this.button_clearWaves.Size = new System.Drawing.Size(145, 46);
            this.button_clearWaves.TabIndex = 33;
            this.button_clearWaves.Text = "Clear Waves";
            this.button_clearWaves.UseVisualStyleBackColor = false;
            this.button_clearWaves.Click += new System.EventHandler(this.button_clearWaves_Click);
            // 
            // bindingSource_candlestick
            // 
            this.bindingSource_candlestick.AllowNew = true;
            this.bindingSource_candlestick.DataSource = typeof(StockProject2.Candlestick);
            // 
            // Form_chartDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 536);
            this.Controls.Add(this.button_clearWaves);
            this.Controls.Add(this.button_clearPV);
            this.Controls.Add(this.label_waveEnd);
            this.Controls.Add(this.label_waveUP);
            this.Controls.Add(this.comboBox_wavesDown);
            this.Controls.Add(this.comboBox_wavesUp);
            this.Controls.Add(this.label_end);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.label_margin);
            this.Controls.Add(this.hScrollBar_margin);
            this.Controls.Add(this.chart_candlestick);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.dateTimePicker_end);
            this.Name = "Form_chartDisplay";
            this.Text = "Form_chartDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlestick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_candlestick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_candlestick;
        private System.Windows.Forms.BindingSource bindingSource_candlestick;
        private System.Windows.Forms.HScrollBar hScrollBar_margin;
        private System.Windows.Forms.Label label_margin;
        private System.Windows.Forms.Label label_end;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.Label label_waveEnd;
        private System.Windows.Forms.Label label_waveUP;
        private System.Windows.Forms.ComboBox comboBox_wavesDown;
        private System.Windows.Forms.ComboBox comboBox_wavesUp;
        private System.Windows.Forms.Button button_clearPV;
        private System.Windows.Forms.Button button_clearWaves;
    }
}