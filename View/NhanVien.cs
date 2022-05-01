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
using ReaLTaiizor.Controls;
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
                PoisonMessageBox.Show(this, "Chưa nhập mã", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maNhanVienBoxNV.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenNhanVienBoxNV.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenNhanVienBoxNV.Focus();
            }
            else if (!int.TryParse(sdtBoxNV.Text, out value))
            {
                PoisonMessageBox.Show(this, "Năm xuất bản không phải là số", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sdtBoxNV.Focus();
            }
            else
            {
                try
                {
                    nv.InsertNV(this.maNhanVienBoxNV.Text, this.tenNhanVienBoxNV.Text, this.ngaySinhDateNV.Value.ToShortDateString(), Convert.ToInt32(this.sdtBoxNV.Text));
                    PoisonMessageBox.Show(this, "Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonNV_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(sdtBoxNV.Text, out value))
            {
                PoisonMessageBox.Show(this, "Năm xuất bản không phải là số", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sdtBoxNV.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenNhanVienBoxNV.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenNhanVienBoxNV.Focus();
            }
            else
            {
                try
                {
                    nv.UpdateNV(this.maNhanVienBoxNV.Text, this.tenNhanVienBoxNV.Text, this.ngaySinhDateNV.Value.ToShortDateString(), Convert.ToInt32(this.sdtBoxNV.Text));
                    PoisonMessageBox.Show(this, "Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maNhanVienBoxNV.Enabled = true;
                    addButtonNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void deleteButtonNV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = PoisonMessageBox.Show(this, "Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = PoisonMessageBox.Show(this, "Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        nv.DeleteNV(this.maNhanVienBoxNV.Text);
                        PoisonMessageBox.Show(this, "Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maNhanVienBoxNV.Enabled = true;
                        addButtonNV.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void resetButtonNV_Click(object sender, EventArgs e)
        {
            ResetAlls(nhanVienTab);
            maNhanVienBoxNV.Enabled = true;
            addButtonNV.Enabled = true;
        }
        private void exitButtonNV_Click(object sender, EventArgs e)
        {
            DialogResult rs = PoisonMessageBox.Show(this, "Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void nhanVienTab_Layout(object sender, LayoutEventArgs e)
        {
            dt = nv.HienThiNV();
            nhanVienGridView.DataSource = dt;
            for (int i = 0; i < nhanVienGridView.Rows.Count; i++)
            {
                nhanVienGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }
        private void searchButtonNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxNV.Text))
            {
                PoisonMessageBox.Show(this, "Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxNV.Focus();
            }
            else
            {
                try
                {
                    nv.TimNV(this.searchBoxNV.Text);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
                }
            }
        }
        private void nhanVienGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maNhanVienBoxNV.Enabled = false;
            addButtonNV.Enabled = false;
            int i;
            i = e.RowIndex;
            maNhanVienBoxNV.Text = nhanVienGridView.Rows[i].Cells[1].Value.ToString();
            tenNhanVienBoxNV.Text = nhanVienGridView.Rows[i].Cells[2].Value.ToString();
            ngaySinhDateNV.Value = DateTime.ParseExact(nhanVienGridView.Rows[i].Cells[3].Value.ToString(),"dd:MM:yyyy",System.Globalization.CultureInfo.InvariantCulture);
            sdtBoxNV.Text = nhanVienGridView.Rows[i].Cells[4].Value.ToString();
        }
    }
}
