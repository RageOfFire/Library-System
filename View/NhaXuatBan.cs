﻿using System;
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
        ControllerNXB NXB = new ControllerNXB();
        // Nhà xuất bản
        private void addButtonNXB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maNXBBoxNXB.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập mã", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maNXBBoxNXB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenNXBBoxNXB.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenNXBBoxNXB.Focus();
            }
            else
            {
                try
                {
                    NXB.InsertNXB(this.maNXBBoxNXB.Text, this.tenNXBBoxNXB.Text, this.DiaChiBoxNXB.Text, this.EmailBoxNXB.Text, this.thongTinBoxNXB.Text);
                    PoisonMessageBox.Show(this, "Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonNXB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tenNXBBoxNXB.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenNXBBoxNXB.Focus();
            }
            else
            {
                try
                {
                    NXB.UpdateNXB(this.maNXBBoxNXB.Text, this.tenNXBBoxNXB.Text, this.DiaChiBoxNXB.Text, this.EmailBoxNXB.Text, this.thongTinBoxNXB.Text);
                    PoisonMessageBox.Show(this, "Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maNXBBoxNXB.Enabled = true;
                    addButtonNXB.Enabled = true;
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void deleteButtonNXB_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = PoisonMessageBox.Show(this, "Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = PoisonMessageBox.Show(this, "Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        NXB.DeleteNXB(this.maNXBBoxNXB.Text);
                        PoisonMessageBox.Show(this, "Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maNXBBoxNXB.Enabled = true;
                        addButtonNXB.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void resetButtonNXB_Click(object sender, EventArgs e)
        {
            ResetAlls(nhaXuatBanTab);
            maNXBBoxNXB.Enabled = true;
            addButtonNXB.Enabled = true;
        }
        private void exitButtonNXB_Click(object sender, EventArgs e)
        {
            DialogResult rs = PoisonMessageBox.Show(this, "Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void nhaXuatBanTab_Layout(object sender, LayoutEventArgs e)
        {
            dt = NXB.HienThiNXB();
            nhaXuatBanGridView.DataSource = dt;
            for (int i = 0; i < nhaXuatBanGridView.Rows.Count; i++)
            {
                nhaXuatBanGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }
        private void searchButtonNXB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxNXB.Text))
            {
                PoisonMessageBox.Show(this, "Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxNXB.Focus();
            }
            else
            {
                try
                {
                    NXB.TimNXB(this.searchBoxNXB.Text);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
                }
            }
        }
        private void nhaXuatBanGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maNXBBoxNXB.Enabled = false;
            addButtonNXB.Enabled = false;
            int i;
            i = e.RowIndex;
            maNXBBoxNXB.Text = nhaXuatBanGridView.Rows[i].Cells[1].Value.ToString();
            tenNXBBoxNXB.Text = nhaXuatBanGridView.Rows[i].Cells[2].Value.ToString();
            DiaChiBoxNXB.Text = nhaXuatBanGridView.Rows[i].Cells[3].Value.ToString();
            EmailBoxNXB.Text = nhaXuatBanGridView.Rows[i].Cells[4].Value.ToString();
            thongTinBoxNXB.Text = nhaXuatBanGridView.Rows[i].Cells[5].Value.ToString();
        }
        private void ExcelButtonNXB_Click(object sender, EventArgs e)
        {
            if (nhaXuatBanGridView.Rows.Count > 0)
            {
                Excel(nhaXuatBanGridView);
            }
            else
            {
                PoisonMessageBox.Show(this, "Cần ít nhất 1 dữ liệu để xuất ra", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
