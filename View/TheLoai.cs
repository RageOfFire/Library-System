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
        ControllerTL tl = new ControllerTL();
        // Thể loại
        private void addButtonTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tenTheLoaiBoxTL.Text))
            {
                EasyMessageBox("Chưa nhập tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTheLoaiBoxTL.Focus();
            }
            else
            {
                try
                {
                    tl.InsertTL(this.tenTheLoaiBoxTL.Text);
                    EasyMessageBox("Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maTheLoaiBoxTL.Text))
            {
                EasyMessageBox("Bạn cần chọn 1 thông tin để sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(tenTheLoaiBoxTL.Text))
            {
                EasyMessageBox("Chưa nhập tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTheLoaiBoxTL.Focus();
            }
            else
            {
                try
                {
                    tl.UpdateTL(this.maTheLoaiBoxTL.Text, this.tenTheLoaiBoxTL.Text);
                    EasyMessageBox("Sửa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maTheLoaiBoxTL.Enabled = true;
                    addButtonTL.Enabled = true;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void deleteButtonTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maTheLoaiBoxTL.Text))
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
                            tl.DeleteTL(this.maTheLoaiBoxTL.Text);
                            EasyMessageBox("Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            maTheLoaiBoxTL.Enabled = true;
                            addButtonTL.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void resetButtonTL_Click(object sender, EventArgs e)
        {
            ResetAlls(theLoaiTab);
            maTheLoaiBoxTL.Enabled = true;
            addButtonTL.Enabled = true;
        }
        private void exitButtonTL_Click(object sender, EventArgs e)
        {
            DialogResult rs = EasyMessageBox("Bạn có muốn thoát khỏi ứng dụng ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                Exit();
            }
        }
        private void theLoaiTab_Layout(object sender, LayoutEventArgs e)
        {
            dt = tl.HienThiTL();
            theLoaiGridView.DataSource = dt;
            for (int i = 0; i < theLoaiGridView.Rows.Count; i++)
            {
                theLoaiGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }
        private void searchButtonTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxTL.Text))
            {
                EasyMessageBox("Chưa Nhập từ khóa để tìm kiếm ?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxTL.Focus();
            }
            else
            {
                try
                {
                    dt = tl.TimTL(this.searchBoxTL.Text);
                    theLoaiGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void theLoaiGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maTheLoaiBoxTL.Enabled = false;
            addButtonTL.Enabled = false;
            int i;
            i = e.RowIndex;
            maTheLoaiBoxTL.Text = theLoaiGridView.Rows[i].Cells[1].Value.ToString();
            tenTheLoaiBoxTL.Text = theLoaiGridView.Rows[i].Cells[2].Value.ToString();
        }
        private void ExcelButtonTL_Click(object sender, EventArgs e)
        {
            if (theLoaiGridView.Rows.Count > 0)
            {
                Excel(theLoaiGridView);
            }
            else
            {
                EasyMessageBox("Cần ít nhất 1 dữ liệu để xuất ra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
