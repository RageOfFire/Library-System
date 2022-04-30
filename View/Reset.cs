using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Sach : Form
    {
        public static void ResetAlls(TabPage page)
        {
            foreach (Control control in page.Controls)
            {
                if (control is ReaLTaiizor.Controls.ForeverTextBox)
                {
                    ReaLTaiizor.Controls.ForeverTextBox textBox = (ReaLTaiizor.Controls.ForeverTextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = -1;
                }

                if (control is DateTimePicker)
                {
                    DateTimePicker dateTime = (DateTimePicker)control;
                    dateTime.Value = DateTime.UtcNow;
                }
            }
        }
    }
}

