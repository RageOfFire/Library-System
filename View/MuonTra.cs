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
            if (string.IsNullOrWhiteSpace(maMuonTraBoxMT.Text))
            {
                PoisonMessageBox.Show(this, "Chưa nhập mã", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maMuonTraBoxMT.Focus();
            }
            else
            {
                try
                {
                    mt.InsertMT(this.maMuonTraBoxMT.Text, Convert.ToInt32(this.soTheComboMT.Text), this.maSachComboMT.Text, this.maNhanVienBoxNV.Text, this.ngayMuonDateMT.Value.ToShortDateString(), this.ngayTraDateMT.Value.ToShortTimeString(), this.radioData);
                    PoisonMessageBox.Show(this, "Thêm thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editButtonMT_Click(object sender, EventArgs e)
        {
            CheckRadio();
            try
            {
                mt.UpdateMT(this.maMuonTraBoxMT.Text, Convert.ToInt32(this.soTheComboMT.Text), this.maSachComboMT.Text, this.maNhanVienComboMT.Text, this.ngayMuonDateMT.Value.ToShortDateString(), this.ngayTraDateMT.Value.ToShortTimeString(), this.radioData);
                PoisonMessageBox.Show(this, "Sửa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maMuonTraBoxMT.Enabled = true;
                addButtonMT.Enabled = true;
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deleteButtonMT_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = PoisonMessageBox.Show(this, "Bạn có thực sự muốn xóa không ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DialogResult rs2 = PoisonMessageBox.Show(this, "Bạn chắc chưa ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs2 == DialogResult.OK)
                    {
                        mt.DeleteMT(this.maMuonTraBoxMT.Text);
                        PoisonMessageBox.Show(this, "Xóa thành công", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maMuonTraBoxMT.Enabled = true;
                        addButtonMT.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult rs = PoisonMessageBox.Show(this, "Bạn có muốn thoát khỏi ứng dụng ?", "Bùi Hồng Sơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void searchButtonMT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBoxMT.Text))
            {
                PoisonMessageBox.Show(this, "Chưa Nhập từ khóa để tìm kiếm ?", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBoxMT.Focus();
            }
            else
            {
                try
                {
                    mt.TimMT(this.searchBoxMT.Text);
                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK);
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
                 soTheComboMT.Items.Add(drST[0].ToString());
                }
            }
            while (drNV.Read())
            {
                if (drNV.FieldCount > 0)
                {
                    maNhanVienComboMT.Items.Add(drNV[0].ToString());
                }
            }
            while (drS.Read())
            {
                if(drS.FieldCount > 0)
                {
                    maSachComboMT.Items.Add(drS[0].ToString());
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
            maSachComboMT.Text = muonTraGridView.Rows[i].Cells[3].Value.ToString();
            maNhanVienComboMT.Text = muonTraGridView.Rows[i].Cells[4].Value.ToString();
            ngayMuonDateMT.Value = DateTime.ParseExact(muonTraGridView.Rows[i].Cells[5].Value.ToString(), "dd:MM:yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ngayTraDateMT.Value = DateTime.ParseExact(muonTraGridView.Rows[i].Cells[6].Value.ToString(), "dd:MM:yyyy", System.Globalization.CultureInfo.InvariantCulture);
            string RadioDataGo = muonTraGridView.Rows[i].Cells[7].Value.ToString();
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
        }
    }
}
