using ReaLTaiizor.Controls;
using System;
using System.Windows.Forms;
using TabPage = System.Windows.Forms.TabPage;

namespace View
{
    public partial class Sach : Form
    {
        // Đây là chức năng để làm mới toàn bộ TextBox,ComboBox,...
        public static void ResetAlls(TabPage page)
        {
            foreach (Control control in page.Controls)
            {
                if (control is ForeverTextBox textBox)
                {
                    textBox.Text = null;
                }

                if (control is ComboBox comboBox)
                {
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = -1;
                }

                if (control is DateTimePicker dateTime)
                {
                    dateTime.Value = DateTime.UtcNow;
                }
            }
        }
        //Chức năng xuất dữ liệu sang dạng excels
        public static void Excel(DataGridView table)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Xuất dữ liệu";
            for (int i = 1; i < table.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = table.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = table.Rows[i].Cells[j].Value.ToString();
                }
            }
            worksheet.Columns.AutoFit();

            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "xlsx files (*.xlsx)|*.xlsx|xls files (*.xls)|*.xls|All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(dlg.FileName);
                }
            }
            app.Quit();
        }
        // Chức năng messageBox
        public DialogResult EasyMessageBox(string text, MessageBoxButtons button, MessageBoxIcon icon)
        {
            DialogResult rs = PoisonMessageBox.Show(this, text, "Quản lý thư viện", button, icon);
            return rs;
        }
        public void Exit()
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}

