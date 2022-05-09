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
        string radioData;
        ControllerMT mt = new ControllerMT();
        SqlDataReader drST;
        SqlDataReader drNV;
        SqlDataReader drS;
        public void CheckRadio()
        {
            if (daTraRadioMT.Checked)
            {
                radioData = daTraRadioMT.Text;
            }
            else
            {
                radioData = chuaTraRadioMT.Text;
            }
        }
        private void addButtonMT_Click(object sender, EventArgs e)
        {
            CheckRadio();
                try
                {
                    mt.InsertMT(Convert.ToInt32(this.soTheComboMT.Text), this.maNhanVienComboMT.Text, this.maSachComboMT.Text, this.ngayMuonDateMT.Value.ToShortDateString(), this.ngayTraDateMT.Value.ToShortTimeString(), this.radioData);
                    EasyMessageBox("Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        private void editButtonMT_Click(object sender, EventArgs e)
        {
            CheckRadio();
            try
            {
                mt.UpdateMT(this.maMuonTraBoxMT.Text, Convert.ToInt32(this.soTheComboMT.Text), this.maSachComboMT.Text, this.maNhanVienComboMT.Text, this.ngayMuonDateMT.Value.ToShortDateString(), this.ngayTraDateMT.Value.ToShortTimeString(), this.radioData);
                EasyMessageBox("Sửa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maMuonTraBoxMT.Enabled = true;
                addButtonMT.Enabled = true;
            }
            catch (Exception ex)
            {
                EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deleteButtonMT_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = EasyMessageBox("Bạn có thực sự muốn xóa không ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = EasyMessageBox("Bạn chắc chưa ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        mt.DeleteMT(this.maMuonTraBoxMT.Text);
                        EasyMessageBox("Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maMuonTraBoxMT.Enabled = true;
                        addButtonMT.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void resetButtonMT_Click(object sender, EventArgs e)
        {
            ResetAlls(muonTraTab);
            maMuonTraBoxMT.Enabled = true;
            addButtonMT.Enabled = true;
        }
        private void exitButtonMT_Click(object sender, EventArgs e)
        {
            DialogResult rs = EasyMessageBox("Bạn có muốn thoát khỏi ứng dụng ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void searchButtonMT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxMT.Text))
            {
                EasyMessageBox("Chưa Nhập từ khóa để tìm kiếm ?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxMT.Focus();
            }
            else
            {
                try
                {
                    dt = mt.TimMT(this.searchBoxMT.Text);
                    muonTraGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    EasyMessageBox("Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void muonTraTab_Layout(object sender, LayoutEventArgs e)
        {
            dt = mt.HienThiMT();
            muonTraGridView.DataSource = dt;
            for (int i = 0; i < muonTraGridView.Rows.Count; i++)
            {
                muonTraGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
            drST = mt.HienthiST_CB();
            drNV = mt.HienthiNV_CB();
            drS = mt.HienThiS_CB();
            while (drST.Read())
            {
                if(drST.FieldCount > 0)
                {
                    if(!soTheComboMT.Items.Contains(drST[0].ToString()))
                    {
                        soTheComboMT.Items.Add(drST[0].ToString());
                    }
                }
            }
            while (drNV.Read())
            {
                if (drNV.FieldCount > 0)
                {
                    if(!maNhanVienComboMT.Items.Contains(drNV[0].ToString()))
                    {
                        maNhanVienComboMT.Items.Add(drNV[0].ToString());
                    }
                    
                }
            }
            while (drS.Read())
            {
                if(drS.FieldCount > 0)
                {
                    if(!maSachComboMT.Items.Contains(drS[0].ToString()))
                    {
                        maSachComboMT.Items.Add(drS[0].ToString());
                    }  
                }
            }
        }
        private void muonTraGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maMuonTraBoxMT.Enabled = false;
            addButtonMT.Enabled = false;
            int i;
            i = e.RowIndex;
            maMuonTraBoxMT.Text = muonTraGridView.Rows[i].Cells[1].Value.ToString();
            soTheComboMT.Text = muonTraGridView.Rows[i].Cells[2].Value.ToString();
            maNhanVienComboMT.Text = muonTraGridView.Rows[i].Cells[3].Value.ToString();
            maSachComboMT.Text = muonTraGridView.Rows[i].Cells[4].Value.ToString();
            ngayMuonDateMT.Text = muonTraGridView.Rows[i].Cells[5].Value.ToString();
            string RadioDataGo = muonTraGridView.Rows[i].Cells[6].Value.ToString();
            if (RadioDataGo == daTraRadioMT.Text)
            {
                daTraRadioMT.Checked = true;
                chuaTraRadioMT.Checked = false;
            }
            else
            {
                chuaTraRadioMT.Checked = true;
                daTraRadioMT.Checked = false;
            }
            ngayTraDateMT.Text = muonTraGridView.Rows[i].Cells[7].Value.ToString();
        }
        private void ExcelButtonMT_Click(object sender, EventArgs e)
        {
            if(muonTraGridView.Rows.Count > 0)
            {
                Excel(muonTraGridView);
            }
            else
            {
                EasyMessageBox("Cần ít nhất 1 dữ liệu để xuất ra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
