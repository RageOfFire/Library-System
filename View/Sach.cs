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
        int value;
        DataTable dt = new DataTable();
        SqlDataReader drTG;
        SqlDataReader drTL;
        SqlDataReader drNXB;
        ControllerSach sach = new ControllerSach();
        public Sach()
        {
            InitializeComponent();
        }
        // Sách
        private void addButtonS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maSachBoxS.Text))
            {
                MessageBox.Show("Chưa nhập mã", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maSachBoxS.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenSachBoxS.Text))
            {
                MessageBox.Show("Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenSachBoxS.Focus();
            }
            else if (!int.TryParse(namXuatBanBoxS.Text, out value))
            {
                MessageBox.Show("Năm xuất bản không phải là số", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                namXuatBanBoxS.Focus();
            }
            else
            {
                try
                {
                    sach.InsertS(this.maSachBoxS.Text, this.tenSachBoxS.Text, this.maTacGiaComboS.Text, this.maTheLoaiComboS.Text, this.maNhaXuatBanComboS.Text, Convert.ToInt32(this.namXuatBanBoxS.Text));
                    MessageBox.Show("Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editButtonS_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(namXuatBanBoxS.Text, out value))
            {
                MessageBox.Show("Năm xuất bản không phải là số", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                namXuatBanBoxS.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenSachBoxS.Text))
            {
                MessageBox.Show("Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenSachBoxS.Focus();
            }
            else
            {
                try
                {
                    sach.UpdateS(this.maSachBoxS.Text, this.tenSachBoxS.Text, this.maTacGiaComboS.Text, this.maTheLoaiComboS.Text, this.maNhaXuatBanComboS.Text, Convert.ToInt32(this.namXuatBanBoxS.Text));
                    MessageBox.Show("Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maSachBoxS.Enabled = true;
                    addButtonS.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteButtonS_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = MessageBox.Show("Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        sach.DeleteS(this.maSachBoxS.Text);
                        MessageBox.Show("Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maSachBoxS.Enabled = true;
                        addButtonS.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                    maTacGiaComboS.Items.Add(drTG[0].ToString());
                }
            }
            while (drTL.Read())
            {
                if(drTL.FieldCount > 0)
                {
                    maTheLoaiComboS.Items.Add(drTL[0].ToString());
                }
            }
            while (drNXB.Read())
            {
                if(drNXB.FieldCount > 0)
                {
                    maNhaXuatBanComboS.Items.Add(drNXB[0].ToString());
                }
            }
        }

        private void searchButtonS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxS.Text))
            {
                MessageBox.Show("Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxS.Focus();
            }
            else
            {
                try
                {
                    sach.TimS(this.searchBoxS.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
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


    }
}

