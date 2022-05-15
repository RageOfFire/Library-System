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
            if (string.IsNullOrWhiteSpace(tenNhanVienBoxNV.Text))
            {
                EasyMessageBox("Chưa nhập tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenNhanVienBoxNV.Focus();
            }
            else if (!int.TryParse(sdtBoxNV.Text, out value))
            {
                EasyMessageBox("Năm xuất bản không phải là số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sdtBoxNV.Focus();
            }
            else
            {
                try
                {
                    nv.InsertNV(this.tenNhanVienBoxNV.Text, this.ngaySinhDateNV.Value.ToShortDateString(), Convert.ToInt32(this.sdtBoxNV.Text));
                    EasyMessageBox("Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maNhanVienBoxNV.Text))
            {
                EasyMessageBox("Bạn cần chọn 1 thông tin để sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!int.TryParse(sdtBoxNV.Text, out value))
            {
                EasyMessageBox("Năm xuất bản không phải là số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sdtBoxNV.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenNhanVienBoxNV.Text))
            {
                EasyMessageBox("Chưa nhập tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenNhanVienBoxNV.Focus();
            }
            else
            {
                try
                {
                    nv.UpdateNV(this.maNhanVienBoxNV.Text, this.tenNhanVienBoxNV.Text, this.ngaySinhDateNV.Value.ToShortDateString(), Convert.ToInt32(this.sdtBoxNV.Text));
                    EasyMessageBox("Sửa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maNhanVienBoxNV.Enabled = true;
                    addButtonNV.Enabled = true;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void deleteButtonNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maNhanVienBoxNV.Text))
            {
                EasyMessageBox("Bạn cần chọn 1 thông tin để xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DialogResult rs = EasyMessageBox("Bạn có thực sự muốn xóa không ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        DialogResult rs2 = EasyMessageBox("Bạn chắc chưa ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (rs2 == DialogResult.OK)
                        {
                            nv.DeleteNV(this.maNhanVienBoxNV.Text);
                            EasyMessageBox("Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            maNhanVienBoxNV.Enabled = true;
                            addButtonNV.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            DialogResult rs = EasyMessageBox("Bạn có muốn thoát khỏi ứng dụng ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                Exit();
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
                EasyMessageBox("Chưa Nhập từ khóa để tìm kiếm ?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxNV.Focus();
            }
            else
            {
                try
                {
                    dt = nv.TimNV(this.searchBoxNV.Text);
                    nhanVienGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ngaySinhDateNV.Text = nhanVienGridView.Rows[i].Cells[3].Value.ToString();
            sdtBoxNV.Text = nhanVienGridView.Rows[i].Cells[4].Value.ToString();
        }
        private void ExcelButtonNV_Click(object sender, EventArgs e)
        {
            if (nhanVienGridView.Rows.Count > 0)
            {
                Excel(nhanVienGridView);
            }
            else
            {
                EasyMessageBox("Cần ít nhất 1 dữ liệu để xuất ra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
