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
        ControllerTTV ttv = new ControllerTTV();
        private void addButtonTTV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(soTheBoxTTV.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập số thẻ", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                soTheBoxTTV.Focus();
            }
            else if (!int.TryParse(soTheBoxTTV.Text, out value))
            {
                PoisonMessageBox.Show(this, "Số thẻ phải là dạng số", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                soTheBoxTTV.Focus();
            }
            else
            {
                try
                {
                    ttv.InsertTTV(Convert.ToInt32(this.soTheBoxTTV.Text), this.ngayBatDauDateTTV.Value.ToShortDateString(), this.ngayHetHanDateTTV.Value.ToShortDateString(), this.ghiChuBoxTTV.Text);
                    PoisonMessageBox.Show(this, "Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonTTV_Click(object sender, EventArgs e)
        {
                try
                {
                    ttv.UpdateTTV(Convert.ToInt32(this.soTheBoxTTV.Text), this.ngayBatDauDateTTV.Value.ToShortDateString(), this.ngayHetHanDateTTV.Value.ToShortDateString(), this.ghiChuBoxTTV.Text);
                    PoisonMessageBox.Show(this, "Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    soTheBoxTTV.Enabled = true;
                    addButtonTTV.Enabled = true;
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        private void deleteButtonTTV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = PoisonMessageBox.Show(this, "Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = PoisonMessageBox.Show(this, "Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        ttv.DeleteTTV(Convert.ToInt32(this.soTheBoxTTV.Text));
                        PoisonMessageBox.Show(this, "Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        soTheBoxTTV.Enabled = true;
                        addButtonTTV.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void resetButtonTTV_Click(object sender, EventArgs e)
        {
            ResetAlls(theThuVienTab);
            soTheBoxTTV.Enabled = true;
            addButtonTTV.Enabled = true;
        }
        private void exitButtonTTV_Click(object sender, EventArgs e)
        {
            DialogResult rs = PoisonMessageBox.Show(this, "Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void theThuVienTab_Layout(object sender, LayoutEventArgs e)
        {
            dt = ttv.HienThiTTV();
            theThuVienGridView.DataSource = dt;
            for (int i = 0; i < theThuVienGridView.Rows.Count; i++)
            {
                theThuVienGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }
        private void searchButtonTTV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxTTV.Text))
            {
                PoisonMessageBox.Show(this, "Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxTTV.Focus();
            }
            else
            {
                try
                {
                    ttv.TimTTV(this.searchBoxTTV.Text);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
                }
            }
        }
        private void theThuVienGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            soTheBoxTTV.Enabled = false;
            addButtonTTV.Enabled = false;
            int i;
            i = e.RowIndex;
            soTheBoxTTV.Text = docGiaGridView.Rows[i].Cells[1].Value.ToString();
            ngayBatDauDateTTV.Value = DateTime.ParseExact(docGiaGridView.Rows[i].Cells[2].Value.ToString(),"dd:MM:yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ngayHetHanDateTTV.Value = DateTime.ParseExact(docGiaGridView.Rows[i].Cells[3].Value.ToString(), "dd:MM:yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ghiChuBoxTTV.Text = docGiaGridView.Rows[i].Cells[4].Value.ToString();
        }
    }
}
