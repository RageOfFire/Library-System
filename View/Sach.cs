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
        int value;
        DataTable dt = new DataTable();
        SqlDataReader drTG;
        SqlDataReader drTL;
        SqlDataReader drNXB;
        ControllerSach sach = new ControllerSach();
        public Sach(string username)
        {
            InitializeComponent();
            if(!string.IsNullOrEmpty(username))
            {
            SachForm.Text = "Chào mừng trở lại " + username;
            SachStatus.Text = "Chào mừng trở lại " + username;
            }
        }
        // Sách
        private void addButtonS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maSachBoxS.Text))
            {
                EasyMessageBox("Chưa nhập mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maSachBoxS.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenSachBoxS.Text))
            {
                EasyMessageBox("Chưa nhập tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenSachBoxS.Focus();
            }
            else if (!int.TryParse(namXuatBanBoxS.Text, out value))
            {
                EasyMessageBox("Năm xuất bản không phải là số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                namXuatBanBoxS.Focus();
            }
            else
            {
                try
                {
                    sach.InsertS(this.maSachBoxS.Text, this.tenSachBoxS.Text, this.maTacGiaComboS.Text, this.maTheLoaiComboS.Text, this.maNhaXuatBanComboS.Text, Convert.ToInt32(this.namXuatBanBoxS.Text));
                    EasyMessageBox("Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editButtonS_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(namXuatBanBoxS.Text, out value))
            {
                EasyMessageBox("Năm xuất bản không phải là số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                namXuatBanBoxS.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenSachBoxS.Text))
            {
                EasyMessageBox("Chưa nhập tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenSachBoxS.Focus();
            }
            else
            {
                try
                {
                    sach.UpdateS(this.maSachBoxS.Text, this.tenSachBoxS.Text, this.maTacGiaComboS.Text, this.maTheLoaiComboS.Text, this.maNhaXuatBanComboS.SelectedValue.ToString(), Convert.ToInt32(this.namXuatBanBoxS.Text));
                    EasyMessageBox("Sửa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maSachBoxS.Enabled = true;
                    addButtonS.Enabled = true;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteButtonS_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = EasyMessageBox("Bạn có thực sự muốn xóa không ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = EasyMessageBox("Bạn chắc chưa ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        sach.DeleteS(this.maSachBoxS.Text);
                        EasyMessageBox("Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maSachBoxS.Enabled = true;
                        addButtonS.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                EasyMessageBox("Error" + ex, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void resetButtonS_Click(object sender, EventArgs e)
        {
            ResetAlls(sachTab);
            maSachBoxS.Enabled = true;
            addButtonS.Enabled = true;
        }

        private void exitButtonS_Click(object sender, EventArgs e)
        {
            DialogResult rs = EasyMessageBox("Bạn có muốn thoát khỏi ứng dụng ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void sachTab_Layout(object sender, LayoutEventArgs e)
        {
            dt = sach.HienThiS();
            sachDataGridView.DataSource = dt;
            for (int i = 0; i < sachDataGridView.Rows.Count; i++)
            {
                sachDataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
            drTG = sach.HienthiTG_CB();
            drTL = sach.HienthiTL_CB();
            drNXB = sach.HienthiNXB_CB();
            while (drTG.Read())
            {
                if(drTG.FieldCount > 0)
                {
                    if(!maTacGiaComboS.Items.Contains(drTG[0].ToString()))
                    {
                        maTacGiaComboS.Items.Add(drTG[0].ToString());
                    }
                }
            }
            while (drTL.Read())
            {
                if(drTL.FieldCount > 0)
                {
                    if(!maTheLoaiComboS.Items.Contains(drTL[0].ToString()))
                    {
                        maTheLoaiComboS.Items.Add(drTL[0].ToString());
                    }
                }
            }
            while (drNXB.Read())
            {
                if(drNXB.FieldCount > 0)
                {
                    if(!maNhaXuatBanComboS.Items.Contains(drNXB[0].ToString()))
                    {
                        maNhaXuatBanComboS.Items.Add(drNXB[0].ToString());
                    }
                }
            }
        }

        private void searchButtonS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxS.Text))
            {
                EasyMessageBox("Chưa Nhập từ khóa để tìm kiếm ?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxS.Focus();
            }
            else
            {
                try
                {
                    dt = sach.TimS(this.searchBoxS.Text);
                    sachDataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sachDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maSachBoxS.Enabled = false;
            addButtonS.Enabled = false;
            int i;
            i = e.RowIndex;
            maSachBoxS.Text = sachDataGridView.Rows[i].Cells[1].Value.ToString();
            tenSachBoxS.Text = sachDataGridView.Rows[i].Cells[2].Value.ToString();
            maTacGiaComboS.Text = sachDataGridView.Rows[i].Cells[3].Value.ToString();
            maTheLoaiComboS.Text = sachDataGridView.Rows[i].Cells[4].Value.ToString();
            maNhaXuatBanComboS.Text = sachDataGridView.Rows[i].Cells[5].Value.ToString();
            namXuatBanBoxS.Text = sachDataGridView.Rows[i].Cells[6].Value.ToString();
        }

        private void ExcelButtonS_Click(object sender, EventArgs e)
        {
            if (sachDataGridView.Rows.Count > 0)
            {
                Excel(sachDataGridView);
            }
            else
            {
                EasyMessageBox("Cần ít nhất 1 dữ liệu để xuất ra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

