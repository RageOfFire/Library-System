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
        String chekedtest;
        String dataRadioGet;
        ControllerCTMT ctmt = new ControllerCTMT();
        SqlDataReader drS;
        SqlDataReader drMT;
        public void radioCheck()
        {
            if (daTraRadioCTMT.Checked)
            {
                chekedtest = "Đã trả";
            }
            else
            {
                chekedtest = "Chưa trả";
            }
        }
        private void addButtonCTMT_Click(object sender, EventArgs e)
        {
            radioCheck();
            try
            {
               ctmt.InsertCTMT(this.maMuonTraComboCTMT.Text, this.maSachComboCTMT.Text, this.ghiChuBoxCTMT.Text, this.chekedtest, this.ngayTraDateCTMT.Value.ToShortDateString());
               MessageBox.Show("Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void editButtonCTMT_Click(object sender, EventArgs e)
        {
            radioCheck();
                try
                {
                    ctmt.UpdateCTMT(this.maMuonTraComboCTMT.Text, this.maSachComboCTMT.Text, this.ghiChuBoxCTMT.Text, this.chekedtest, this.ngayTraDateCTMT.Value.ToShortDateString());
                    MessageBox.Show("Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addButtonCTMT.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        private void deleteButtonCTMT_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = MessageBox.Show("Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        ctmt.DeleteCTMT(this.maSachComboCTMT.Text);
                        MessageBox.Show("Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        addButtonCTMT.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void resetButtonCTMT_Click(object sender, EventArgs e)
        {
            ResetAlls(CTmuontraTab);
            addButtonCTMT.Enabled = true;
        }
        private void exitButtonCTMT_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void CTmuontraTab_Layout(object sender, LayoutEventArgs e)
        {
            dt = ctmt.HienThiCTMT();
            chiTietMuonTraGridView.DataSource = dt;
            for (int i = 0; i < chiTietMuonTraGridView.Rows.Count; i++)
            {
                chiTietMuonTraGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
            drS = ctmt.HienthiS_CB();
            drMT = ctmt.HienthiMT_CB();
            while (drS.Read())
            {
                maSachComboCTMT.Items.Add(drS[0].ToString());
            }
            while (drMT.Read())
            {
                maMuonTraComboCTMT.Items.Add(drMT[0].ToString());
            }
        }
        private void searchButtonCTMT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxCTMT.Text))
            {
                MessageBox.Show("Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxCTMT.Focus();
            }
            else
            {
                try
                {
                    ctmt.TimCTMT(this.searchBoxCTMT.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
                }
            }
        }
        private void chiTietMuonTraGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            addButtonCTMT.Enabled = false;
            int i;
            i = e.RowIndex;
            maMuonTraComboCTMT.Text = chiTietMuonTraGridView.Rows[i].Cells[1].Value.ToString();
            maSachComboCTMT.Text = chiTietMuonTraGridView.Rows[i].Cells[2].Value.ToString();
            ghiChuBoxCTMT.Text = chiTietMuonTraGridView.Rows[i].Cells[3].Value.ToString();
            dataRadioGet = chiTietMuonTraGridView.Rows[i].Cells[4].Value.ToString();
            if (dataRadioGet == "Đã trả")
            {
                daTraRadioCTMT.Checked = true;
                chuaTraRadioCTMT.Checked = false;
            }
            else
            {
                daTraRadioCTMT.Checked = false;
                chuaTraRadioCTMT.Checked = true;
            }
            ngayTraDateCTMT.Value = DateTime.ParseExact(chiTietMuonTraGridView.Rows[i].Cells[5].Value.ToString(), "dd:MM:yyyy",System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
