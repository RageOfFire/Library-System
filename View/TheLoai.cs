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
            if (string.IsNullOrWhiteSpace(maTheLoaiBoxTL.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập mã", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maTheLoaiBoxTL.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenTheLoaiBoxTL.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTheLoaiBoxTL.Focus();
            }
            else
            {
                try
                {
                    tl.InsertTL(this.maTheLoaiBoxTL.Text, this.tenTheLoaiBoxTL.Text);
                    PoisonMessageBox.Show(this, "Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tenTheLoaiBoxTL.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTheLoaiBoxTL.Focus();
            }
            else
            {
                try
                {
                    tl.UpdateTL(this.maTheLoaiBoxTL.Text, this.tenTheLoaiBoxTL.Text);
                    PoisonMessageBox.Show(this, "Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maTheLoaiBoxTL.Enabled = true;
                    addButtonTL.Enabled = true;
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void deleteButtonTL_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = PoisonMessageBox.Show(this, "Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = PoisonMessageBox.Show(this, "Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        tl.DeleteTL(this.maTheLoaiBoxTL.Text);
                        PoisonMessageBox.Show(this, "Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maTheLoaiBoxTL.Enabled = true;
                        addButtonTL.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult rs = PoisonMessageBox.Show(this, "Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
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
                PoisonMessageBox.Show(this, "Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxTL.Focus();
            }
            else
            {
                try
                {
                    tl.TimTL(this.searchBoxTL.Text);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
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
                PoisonMessageBox.Show(this, "Cần ít nhất 1 dữ liệu để xuất ra", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
