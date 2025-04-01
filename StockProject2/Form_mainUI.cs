using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockProject2
{
    public partial class Form_mainUI : Form
    {

        public Form_mainUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the 'Load' button. 
        /// It opens the file picker dialog to allow the user to select files.
        /// </summary>
        /// <param name="sender">The source of the event (the button).</param>
        /// <param name="e">Event arguments containing additional event data.</param>
        private void button_load_Click(object sender, EventArgs e)
        {
            //show the open file dialog
            openFileDialog_filePicker.ShowDialog();
        }

        /// <summary>
        /// Handles the 'FileOk' event of the file picker dialog.
        /// Iterates through the selected files and creates a new chart display form for each file.
        /// Only displays the form if the selected date range is valid.
        /// </summary>
        /// <param name="sender">The source of the event (file picker dialog).</param>
        /// <param name="e">Event arguments containing additional event data.</param>
        private void openFileDialog_filePicker_FileOk(object sender, CancelEventArgs e)
        {
            //for each chosen file construct a form
            foreach (var filePath in openFileDialog_filePicker.FileNames)
            {
                //construct the form
                Form_chartDisplay f = new Form_chartDisplay(filePath, dateTimePicker_strt.Value, dateTimePicker_end.Value);

                //show the form only if dates are valid
                if (f.isValid)
                {
                    f.Show();
                }
                else
                {
                    //delete invalid form
                    f.Dispose();
                }
            }
        }
    }
}
