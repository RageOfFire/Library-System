namespace View
{
    partial class UserMuonTra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.UserThuVien = new ReaLTaiizor.Forms.ForeverForm();
            this.foreverStatusBar1 = new ReaLTaiizor.Controls.ForeverStatusBar();
            this.foreverNotification1 = new ReaLTaiizor.Controls.ForeverNotification();
            this.MuonTraUserGridView = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.foreverMaximize1 = new ReaLTaiizor.Controls.ForeverMaximize();
            this.foreverMinimize1 = new ReaLTaiizor.Controls.ForeverMinimize();
            this.closeButton = new ReaLTaiizor.Controls.ForeverClose();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserThuVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MuonTraUserGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UserThuVien
            // 
            this.UserThuVien.BackColor = System.Drawing.Color.White;
            this.UserThuVien.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.UserThuVien.BorderColor = System.Drawing.Color.DodgerBlue;
            this.UserThuVien.Controls.Add(this.foreverStatusBar1);
            this.UserThuVien.Controls.Add(this.foreverNotification1);
            this.UserThuVien.Controls.Add(this.MuonTraUserGridView);
            this.UserThuVien.Controls.Add(this.foreverMaximize1);
            this.UserThuVien.Controls.Add(this.foreverMinimize1);
            this.UserThuVien.Controls.Add(this.closeButton);
            this.UserThuVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserThuVien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.UserThuVien.ForeverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.UserThuVien.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.UserThuVien.HeaderMaximize = false;
            this.UserThuVien.HeaderTextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.UserThuVien.Image = null;
            this.UserThuVien.Location = new System.Drawing.Point(0, 0);
            this.UserThuVien.MinimumSize = new System.Drawing.Size(210, 50);
            this.UserThuVien.Name = "UserThuVien";
            this.UserThuVien.Padding = new System.Windows.Forms.Padding(1, 51, 1, 1);
            this.UserThuVien.Sizable = true;
            this.UserThuVien.Size = new System.Drawing.Size(800, 717);
            this.UserThuVien.TabIndex = 0;
            this.UserThuVien.Text = "Thư viện";
            this.UserThuVien.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.UserThuVien.TextLight = System.Drawing.Color.SeaGreen;
            this.UserThuVien.Layout += new System.Windows.Forms.LayoutEventHandler(this.UserThuVien_Layout);
            // 
            // foreverStatusBar1
            // 
            this.foreverStatusBar1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.foreverStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.foreverStatusBar1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.foreverStatusBar1.ForeColor = System.Drawing.Color.White;
            this.foreverStatusBar1.Location = new System.Drawing.Point(1, 693);
            this.foreverStatusBar1.Name = "foreverStatusBar1";
            this.foreverStatusBar1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.foreverStatusBar1.ShowTimeDate = true;
            this.foreverStatusBar1.Size = new System.Drawing.Size(798, 23);
            this.foreverStatusBar1.TabIndex = 14;
            this.foreverStatusBar1.Text = "Chào mừng";
            this.foreverStatusBar1.TextColor = System.Drawing.Color.White;
            this.foreverStatusBar1.TimeColor = System.Drawing.Color.White;
            this.foreverStatusBar1.TimeFormat = "dd.MM.yyyy";
            // 
            // foreverNotification1
            // 
            this.foreverNotification1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.foreverNotification1.Close = true;
            this.foreverNotification1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.foreverNotification1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.foreverNotification1.Kind = ReaLTaiizor.Controls.ForeverNotification._Kind.Success;
            this.foreverNotification1.Location = new System.Drawing.Point(12, 54);
            this.foreverNotification1.Name = "foreverNotification1";
            this.foreverNotification1.Size = new System.Drawing.Size(778, 42);
            this.foreverNotification1.TabIndex = 13;
            this.foreverNotification1.Text = "Ấn vào sách cần mượn";
            this.foreverNotification1.Visible = false;
            // 
            // MuonTraUserGridView
            // 
            this.MuonTraUserGridView.AllowUserToAddRows = false;
            this.MuonTraUserGridView.AllowUserToDeleteRows = false;
            this.MuonTraUserGridView.AllowUserToResizeRows = false;
            this.MuonTraUserGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MuonTraUserGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.MuonTraUserGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MuonTraUserGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.MuonTraUserGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MuonTraUserGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MuonTraUserGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MuonTraUserGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.TenSach,
            this.TheLoai,
            this.TacGia,
            this.NXB});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MuonTraUserGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.MuonTraUserGridView.EnableHeadersVisualStyles = false;
            this.MuonTraUserGridView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MuonTraUserGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.MuonTraUserGridView.Location = new System.Drawing.Point(6, 109);
            this.MuonTraUserGridView.Name = "MuonTraUserGridView";
            this.MuonTraUserGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MuonTraUserGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.MuonTraUserGridView.RowHeadersWidth = 51;
            this.MuonTraUserGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.MuonTraUserGridView.RowTemplate.Height = 24;
            this.MuonTraUserGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MuonTraUserGridView.Size = new System.Drawing.Size(793, 485);
            this.MuonTraUserGridView.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Green;
            this.MuonTraUserGridView.TabIndex = 12;
            this.MuonTraUserGridView.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            // 
            // foreverMaximize1
            // 
            this.foreverMaximize1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverMaximize1.BackColor = System.Drawing.Color.White;
            this.foreverMaximize1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.foreverMaximize1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.foreverMaximize1.DefaultLocation = true;
            this.foreverMaximize1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.foreverMaximize1.Font = new System.Drawing.Font("Marlett", 12F);
            this.foreverMaximize1.Location = new System.Drawing.Point(746, 16);
            this.foreverMaximize1.Name = "foreverMaximize1";
            this.foreverMaximize1.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.foreverMaximize1.Size = new System.Drawing.Size(18, 18);
            this.foreverMaximize1.TabIndex = 11;
            this.foreverMaximize1.Text = "foreverMaximize1";
            this.foreverMaximize1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // foreverMinimize1
            // 
            this.foreverMinimize1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverMinimize1.BackColor = System.Drawing.Color.White;
            this.foreverMinimize1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.foreverMinimize1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.foreverMinimize1.DefaultLocation = true;
            this.foreverMinimize1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.foreverMinimize1.Font = new System.Drawing.Font("Marlett", 12F);
            this.foreverMinimize1.Location = new System.Drawing.Point(722, 16);
            this.foreverMinimize1.Name = "foreverMinimize1";
            this.foreverMinimize1.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.foreverMinimize1.Size = new System.Drawing.Size(18, 18);
            this.foreverMinimize1.TabIndex = 10;
            this.foreverMinimize1.Text = "foreverMinimize1";
            this.foreverMinimize1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.White;
            this.closeButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.DefaultLocation = true;
            this.closeButton.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.closeButton.Location = new System.Drawing.Point(770, 16);
            this.closeButton.Name = "closeButton";
            this.closeButton.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.closeButton.Size = new System.Drawing.Size(18, 18);
            this.closeButton.TabIndex = 9;
            this.closeButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // TenSach
            // 
            this.TenSach.DataPropertyName = "Ten_sach";
            this.TenSach.HeaderText = "Tên sách";
            this.TenSach.MinimumWidth = 6;
            this.TenSach.Name = "TenSach";
            this.TenSach.ReadOnly = true;
            // 
            // TheLoai
            // 
            this.TheLoai.DataPropertyName = "Ten_the_loai";
            this.TheLoai.HeaderText = "Thể loại";
            this.TheLoai.MinimumWidth = 6;
            this.TheLoai.Name = "TheLoai";
            this.TheLoai.ReadOnly = true;
            // 
            // TacGia
            // 
            this.TacGia.DataPropertyName = "Ten_tac_gia";
            this.TacGia.HeaderText = "Tác giả";
            this.TacGia.MinimumWidth = 6;
            this.TacGia.Name = "TacGia";
            this.TacGia.ReadOnly = true;
            // 
            // NXB
            // 
            this.NXB.DataPropertyName = "Ten_NXB";
            this.NXB.HeaderText = "Nhà xuất bản";
            this.NXB.MinimumWidth = 6;
            this.NXB.Name = "NXB";
            this.NXB.ReadOnly = true;
            // 
            // UserMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 717);
            this.Controls.Add(this.UserThuVien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserMuonTra";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.UserThuVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MuonTraUserGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm UserThuVien;
        private ReaLTaiizor.Controls.ForeverNotification foreverNotification1;
        private ReaLTaiizor.Controls.PoisonDataGridView MuonTraUserGridView;
        private ReaLTaiizor.Controls.ForeverMaximize foreverMaximize1;
        private ReaLTaiizor.Controls.ForeverMinimize foreverMinimize1;
        private ReaLTaiizor.Controls.ForeverClose closeButton;
        private ReaLTaiizor.Controls.ForeverStatusBar foreverStatusBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NXB;
    }
}