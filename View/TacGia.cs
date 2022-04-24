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
using Controller;

namespace View
{
    public partial class Sach : Form
    {
    ControllerTacGia tacGia = new ControllerTacGia();
        // Tác giả
        private void addButtonTG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maTacGiaBoxTG.Text))
            {
                MessageBox.Show("Chưa nhập mã", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maTacGiaBoxTG.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenTacGiaBoxTG.Text))
            {
                MessageBox.Show("Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTacGiaBoxTG.Focus();
            }
            else
            {
                try
                {
                    tacGia.InsertTG(this.maTacGiaBoxTG.Text, this.tenTacGiaBoxTG.Text, this.websiteBoxTG.Text, this.noteBoxTG.Text);
                    MessageBox.Show("Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editButtonTG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tenTacGiaBoxTG.Text))
            {
                MessageBox.Show("Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenTacGiaBoxTG.Focus();
            }
            else
            {
                try
                {
                    tacGia.UpdateTG(this.maTacGiaBoxTG.Text, this.tenTacGiaBoxTG.Text, this.websiteBoxTG.Text, this.noteBoxTG.Text);
                    MessageBox.Show("Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maTacGiaBoxTG.Enabled = true;
                    addButtonTG.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void deleteButtonTG_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = MessageBox.Show("Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        tacGia.DeleteTG(this.maTacGiaBoxTG.Text);
                        MessageBox.Show("Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maTacGiaBoxTG.Enabled = true;
                        addButtonTG.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void searchButtonTG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxTG.Text))
            {
                MessageBox.Show("Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxTG.Focus();
            }
            else
            {
                try
                {
                    tacGia.TimTG(this.searchBoxTG.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
                }
            }
        }

        private void tacGiaGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maTacGiaBoxTG.Enabled = false;
            addButtonTG.Enabled = false;
            int i;
            i = e.RowIndex;
            maTacGiaBoxTG.Text = sachDataGridView.Rows[i].Cells[1].Value.ToString();
            tenTacGiaBoxTG.Text = sachDataGridView.Rows[i].Cells[2].Value.ToString();
            websiteBoxTG.Text = sachDataGridView.Rows[i].Cells[3].Value.ToString();
            noteBoxTG.Text = sachDataGridView.Rows[i].Cells[4].Value.ToString();
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
    }
}

