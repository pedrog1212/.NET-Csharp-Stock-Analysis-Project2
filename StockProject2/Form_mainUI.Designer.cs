namespace StockProject2
{
    partial class Form_mainUI
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
            this.label_end = new System.Windows.Forms.Label();
            this.label_strt = new System.Windows.Forms.Label();
            this.dateTimePicker_strt = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.button_load = new System.Windows.Forms.Button();
            this.openFileDialog_filePicker = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label_end
            // 
            this.label_end.AutoSize = true;
            this.label_end.Location = new System.Drawing.Point(13, 84);
            this.label_end.Name = "label_end";
            this.label_end.Size = new System.Drawing.Size(52, 13);
            this.label_end.TabIndex = 19;
            this.label_end.Text = "End Time";
            // 
            // label_strt
            // 
            this.label_strt.AutoSize = true;
            this.label_strt.Location = new System.Drawing.Point(13, 27);
            this.label_strt.Name = "label_strt";
            this.label_strt.Size = new System.Drawing.Size(55, 13);
            this.label_strt.TabIndex = 18;
            this.label_strt.Text = "Start Time";
            // 
            // dateTimePicker_strt
            // 
            this.dateTimePicker_strt.Location = new System.Drawing.Point(12, 49);
            this.dateTimePicker_strt.Name = "dateTimePicker_strt";
            this.dateTimePicker_strt.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_strt.TabIndex = 17;
            this.dateTimePicker_strt.Value = new System.DateTime(2021, 2, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(12, 109);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_end.TabIndex = 16;
            this.dateTimePicker_end.Value = new System.DateTime(2021, 2, 28, 0, 0, 0, 0);
            // 
            // button_load
            // 
            this.button_load.BackColor = System.Drawing.Color.LimeGreen;
            this.button_load.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button_load.FlatAppearance.BorderSize = 2;
            this.button_load.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_load.Location = new System.Drawing.Point(237, 44);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(135, 85);
            this.button_load.TabIndex = 0;
            this.button_load.Text = "Load Stock Data File";
            this.button_load.UseVisualStyleBackColor = false;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // openFileDialog_filePicker
            // 
            this.openFileDialog_filePicker.DefaultExt = "csv";
            this.openFileDialog_filePicker.FileName = "ABBV-Day";
            this.openFileDialog_filePicker.Filter = "All|*.csv|Monthly|*-Month.csv|Weekly|*-Week.csv|Daily|*-Day.csv";
            this.openFileDialog_filePicker.InitialDirectory = "..\\Stock Data";
            this.openFileDialog_filePicker.Multiselect = true;
            this.openFileDialog_filePicker.ReadOnlyChecked = true;
            this.openFileDialog_filePicker.ShowReadOnly = true;
            this.openFileDialog_filePicker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_filePicker_FileOk);
            // 
            // Form_mainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 161);
            this.Controls.Add(this.label_end);
            this.Controls.Add(this.label_strt);
            this.Controls.Add(this.dateTimePicker_strt);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.button_load);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 200);
            this.MinimumSize = new System.Drawing.Size(420, 200);
            this.Name = "Form_mainUI";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_end;
        private System.Windows.Forms.Label label_strt;
        private System.Windows.Forms.DateTimePicker dateTimePicker_strt;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.OpenFileDialog openFileDialog_filePicker;
    }
}

