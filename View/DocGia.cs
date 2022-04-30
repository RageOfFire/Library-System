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
        ControllerDocGia dg = new ControllerDocGia();
        SqlDataReader drST2;
        private void addButtonDG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maDocGiaBoxDG.Text))
            {
                MessageBox.Show("Chưa nhập mã", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maDocGiaBoxDG.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tenDocGiaBoxDG.Text))
            {
                MessageBox.Show("Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenDocGiaBoxDG.Focus();
            }
            else
            {
                try
                {
                    dg.InsertDG(this.maDocGiaBoxDG.Text, this.tenDocGiaBoxDG.Text, this.diaChiBoxDG.Text, Convert.ToInt32(this.soTheComboDG.Text));
                    MessageBox.Show("Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonDG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tenDocGiaBoxDG.Text))
            {
                MessageBox.Show("Chưa nhập tên", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tenDocGiaBoxDG.Focus();
            }
            else
            {
                try
                {
                    dg.UpdateDG(this.maDocGiaBoxDG.Text, this.tenDocGiaBoxDG.Text, this.diaChiBoxDG.Text, Convert.ToInt32(this.soTheComboDG.Text));
                    MessageBox.Show("Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maDocGiaBoxDG.Enabled = true;
                    addButtonDG.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void deleteButtonDG_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = MessageBox.Show("Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        dg.DeleteDG(this.maDocGiaBoxDG.Text);
                        MessageBox.Show("Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maDocGiaBoxDG.Enabled = true;
                        addButtonDG.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void resetButtonDG_Click(object sender, EventArgs e)
        {
            ResetAlls(docGiaTab);
            maDocGiaBoxDG.Enabled = true;
            addButtonDG.Enabled = true;
        }
        private void exitButtonDG_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void searchButtonDG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxDG.Text))
            {
                MessageBox.Show("Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxDG.Focus();
            }
            else
            {
                try
                {
                    dg.TimDG(this.searchBoxDG.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
                }
            }
        }
        private void docGiaTab_Layout(object sender, LayoutEventArgs e)
        {
            dt = dg.HienThiDG();
            docGiaGridView.DataSource = dt;
            for (int i = 0; i < docGiaGridView.Rows.Count; i++)
            {
                docGiaGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
            drST2 = dg.HienthiST_CB();
            while (drST2.Read())
            {
                if(drST2.FieldCount > 0)
                {
                    soTheComboDG.Items.Add(drST2[0].ToString());
                }
            }
        }
        private void docGiaGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maDocGiaBoxDG.Enabled = false;
            addButtonDG.Enabled = false;
            int i;
            i = e.RowIndex;
            maDocGiaBoxDG.Text = docGiaGridView.Rows[i].Cells[1].Value.ToString();
            tenDocGiaBoxDG.Text = docGiaGridView.Rows[i].Cells[2].Value.ToString();
            diaChiBoxDG.Text = docGiaGridView.Rows[i].Cells[3].Value.ToString();
            soTheComboDG.Text = docGiaGridView.Rows[i].Cells[4].Value.ToString();
        }
    }
}
