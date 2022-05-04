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
                EasyMessageBox("Chưa nhập số thẻ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                soTheBoxTTV.Focus();
            }
            else if (!int.TryParse(soTheBoxTTV.Text, out value))
            {
                EasyMessageBox("Số thẻ phải là dạng số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                soTheBoxTTV.Focus();
            }
            else
            {
                try
                {
                    ttv.InsertTTV(Convert.ToInt32(this.soTheBoxTTV.Text), this.ngayBatDauDateTTV.Value.ToShortDateString(), this.ngayHetHanDateTTV.Value.ToShortDateString(), this.ghiChuBoxTTV.Text);
                    EasyMessageBox("Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonTTV_Click(object sender, EventArgs e)
        {
                try
                {
                    ttv.UpdateTTV(Convert.ToInt32(this.soTheBoxTTV.Text), this.ngayBatDauDateTTV.Value.ToShortDateString(), this.ngayHetHanDateTTV.Value.ToShortDateString(), this.ghiChuBoxTTV.Text);
                    EasyMessageBox("Sửa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    soTheBoxTTV.Enabled = true;
                    addButtonTTV.Enabled = true;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        private void deleteButtonTTV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = EasyMessageBox("Bạn có thực sự muốn xóa không ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = EasyMessageBox("Bạn chắc chưa ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        ttv.DeleteTTV(Convert.ToInt32(this.soTheBoxTTV.Text));
                        EasyMessageBox("Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        soTheBoxTTV.Enabled = true;
                        addButtonTTV.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult rs = EasyMessageBox("Bạn có muốn thoát khỏi ứng dụng ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                EasyMessageBox("Chưa Nhập từ khóa để tìm kiếm ?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ngayBatDauDateTTV.Text = docGiaGridView.Rows[i].Cells[2].Value.ToString();
            ngayHetHanDateTTV.Text = docGiaGridView.Rows[i].Cells[3].Value.ToString();
            ghiChuBoxTTV.Text = docGiaGridView.Rows[i].Cells[4].Value.ToString();
        }
        private void ExcelButtonTTV_Click(object sender, EventArgs e)
        {
            if (theThuVienGridView.Rows.Count > 0)
            {
                Excel(theThuVienGridView);
            }
            else
            {
                EasyMessageBox("Cần ít nhất 1 dữ liệu để xuất ra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
