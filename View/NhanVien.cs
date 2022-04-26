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
using Controller;

namespace View
{
    public partial class Sach : Form
    {
        ControllerNhanVien nv = new ControllerNhanVien();
        private void addButtonNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maNhanVienBoxNV.Text))
            {
                MessageBox.Show("Chưa nhập mã", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maNhanVienBoxNV.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenNhanVienBoxNV.Text))
            {
                MessageBox.Show("Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenNhanVienBoxNV.Focus();
            }
            else if (!int.TryParse(sdtBoxNV.Text, out value))
            {
                MessageBox.Show("Năm xuất bản không phải là số", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sdtBoxNV.Focus();
            }
            else
            {
                try
                {
                    nv.InsertNV(this.maNhanVienBoxNV.Text, this.tenNhanVienBoxNV.Text, this.ngaySinhDateNV.Value.ToShortDateString(), Convert.ToInt32(this.sdtBoxNV.Text));
                    MessageBox.Show("Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
