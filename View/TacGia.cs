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
    ControllerTacGia tacGia = new ControllerTacGia();
        // Tác giả
        private void addButtonTG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tenTacGiaBoxTG.Text))
            {
                EasyMessageBox("Chưa nhập tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTacGiaBoxTG.Focus();
            }
            else
            {
                try
                {
                    tacGia.InsertTG(this.tenTacGiaBoxTG.Text, this.websiteBoxTG.Text, this.noteBoxTG.Text);
                    EasyMessageBox("Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editButtonTG_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(maTacGiaBoxTG.Text))
            {
                EasyMessageBox("Bạn cần chọn 1 thông tin để sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(tenTacGiaBoxTG.Text))
            {
                EasyMessageBox("Chưa nhập tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTacGiaBoxTG.Focus();
            }
            else
            {
                try
                {
                    tacGia.UpdateTG(this.maTacGiaBoxTG.Text, this.tenTacGiaBoxTG.Text, this.websiteBoxTG.Text, this.noteBoxTG.Text);
                    EasyMessageBox("Sửa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maTacGiaBoxTG.Enabled = true;
                    addButtonTG.Enabled = true;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void deleteButtonTG_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = EasyMessageBox("Bạn có thực sự muốn xóa không ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = EasyMessageBox("Bạn chắc chưa ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        tacGia.DeleteTG(this.maTacGiaBoxTG.Text);
                        EasyMessageBox("Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maTacGiaBoxTG.Enabled = true;
                        addButtonTG.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetButtonTG_Click(object sender, EventArgs e)
        {
            ResetAlls(tacGiaTab);
            maTacGiaBoxTG.Enabled = true;
            addButtonTG.Enabled = true;
        }

        private void exitButtonTG_Click(object sender, EventArgs e)
        {
            DialogResult rs = EasyMessageBox("Bạn có muốn thoát khỏi ứng dụng ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void searchButtonTG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxTG.Text))
            {
                EasyMessageBox("Chưa Nhập từ khóa để tìm kiếm ?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxTG.Focus();
            }
            else
            {
                try
                {
                    dt = tacGia.TimTG(this.searchBoxTG.Text);
                    tacGiaGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tacGiaGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maTacGiaBoxTG.Enabled = false;
            addButtonTG.Enabled = false;
            int i;
            i = e.RowIndex;
            maTacGiaBoxTG.Text = tacGiaGridView.Rows[i].Cells[1].Value.ToString();
            tenTacGiaBoxTG.Text = tacGiaGridView.Rows[i].Cells[2].Value.ToString();
            websiteBoxTG.Text = tacGiaGridView.Rows[i].Cells[3].Value.ToString();
            noteBoxTG.Text = tacGiaGridView.Rows[i].Cells[4].Value.ToString();
        }
        private void tacGiaTab_Layout(object sender, LayoutEventArgs e)
        {
            dt = tacGia.HienThiTG();
            tacGiaGridView.DataSource = dt;
            for (int i = 0; i < tacGiaGridView.Rows.Count; i++)
            {
                tacGiaGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }
        private void ExcelButtonTG_Click(object sender, EventArgs e)
        {
            if (tacGiaGridView.Rows.Count > 0)
            {
                Excel(tacGiaGridView);
            }
            else
            {
                EasyMessageBox("Cần ít nhất 1 dữ liệu để xuất ra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

