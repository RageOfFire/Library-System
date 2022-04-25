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
        ControllerTL tl = new ControllerTL();
        // Thể loại
        private void addButtonTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maTheLoaiBoxTL.Text))
            {
                MessageBox.Show("Chưa nhập mã", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maTheLoaiBoxTL.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenTheLoaiBoxTL.Text))
            {
                MessageBox.Show("Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTheLoaiBoxTL.Focus();
            }
            else
            {
                try
                {
                    tl.InsertTL(this.maTheLoaiBoxTL.Text, this.tenTheLoaiBoxTL.Text);
                    MessageBox.Show("Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tenTheLoaiBoxTL.Text))
            {
                MessageBox.Show("Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTheLoaiBoxTL.Focus();
            }
            else
            {
                try
                {
                    tl.UpdateTL(this.maTheLoaiBoxTL.Text, this.tenTheLoaiBoxTL.Text);
                    MessageBox.Show("Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maTheLoaiBoxTL.Enabled = true;
                    addButtonTL.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void deleteButtonTL_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = MessageBox.Show("Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        tl.DeleteTL(this.maTheLoaiBoxTL.Text);
                        MessageBox.Show("Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maTheLoaiBoxTL.Enabled = true;
                        addButtonTL.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void searchButtonTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxTL.Text))
            {
                MessageBox.Show("Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
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
    }
}
