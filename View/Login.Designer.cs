namespace View
{
    partial class Login
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
            this.LoginForm = new ReaLTaiizor.Forms.ForeverForm();
            this.loginlabel = new ReaLTaiizor.Controls.ForeverLabel();
            this.userlabel = new ReaLTaiizor.Controls.ForeverLabel();
            this.passlabel = new ReaLTaiizor.Controls.ForeverLabel();
            this.userTextbox = new ReaLTaiizor.Controls.ForeverTextBox();
            this.passTextbox = new ReaLTaiizor.Controls.ForeverTextBox();
            this.loginButton = new ReaLTaiizor.Controls.ForeverButton();
            this.closeButton = new ReaLTaiizor.Controls.ForeverClose();
            this.LoginForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.LoginForm.BackColor = System.Drawing.Color.White;
            this.LoginForm.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.LoginForm.BorderColor = System.Drawing.Color.DodgerBlue;
            this.LoginForm.Controls.Add(this.closeButton);
            this.LoginForm.Controls.Add(this.loginButton);
            this.LoginForm.Controls.Add(this.passTextbox);
            this.LoginForm.Controls.Add(this.userTextbox);
            this.LoginForm.Controls.Add(this.passlabel);
            this.LoginForm.Controls.Add(this.userlabel);
            this.LoginForm.Controls.Add(this.loginlabel);
            this.LoginForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginForm.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginForm.ForeverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.LoginForm.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.LoginForm.HeaderMaximize = false;
            this.LoginForm.HeaderTextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.LoginForm.Image = null;
            this.LoginForm.Location = new System.Drawing.Point(0, 0);
            this.LoginForm.MinimumSize = new System.Drawing.Size(210, 50);
            this.LoginForm.Name = "LoginForm";
            this.LoginForm.Padding = new System.Windows.Forms.Padding(1, 51, 1, 1);
            this.LoginForm.Sizable = true;
            this.LoginForm.Size = new System.Drawing.Size(800, 450);
            this.LoginForm.TabIndex = 0;
            this.LoginForm.Text = "Login";
            this.LoginForm.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.LoginForm.TextLight = System.Drawing.Color.SeaGreen;
            // 
            // loginlabel
            // 
            this.loginlabel.AutoSize = true;
            this.loginlabel.BackColor = System.Drawing.Color.Transparent;
            this.loginlabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.loginlabel.Location = new System.Drawing.Point(204, 67);
            this.loginlabel.Name = "loginlabel";
            this.loginlabel.Size = new System.Drawing.Size(365, 54);
            this.loginlabel.TabIndex = 0;
            this.loginlabel.Text = "Chào mừng trở lại";
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.BackColor = System.Drawing.Color.Transparent;
            this.userlabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.userlabel.Location = new System.Drawing.Point(89, 149);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(114, 31);
            this.userlabel.TabIndex = 1;
            this.userlabel.Text = "Tài khoản:";
            // 
            // passlabel
            // 
            this.passlabel.AutoSize = true;
            this.passlabel.BackColor = System.Drawing.Color.Transparent;
            this.passlabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.passlabel.Location = new System.Drawing.Point(89, 211);
            this.passlabel.Name = "passlabel";
            this.passlabel.Size = new System.Drawing.Size(115, 31);
            this.passlabel.TabIndex = 2;
            this.passlabel.Text = "Mật khẩu:";
            // 
            // userTextbox
            // 
            this.userTextbox.BackColor = System.Drawing.Color.Transparent;
            this.userTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.userTextbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.userTextbox.FocusOnHover = false;
            this.userTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.userTextbox.Location = new System.Drawing.Point(254, 149);
            this.userTextbox.MaxLength = 32767;
            this.userTextbox.Multiline = false;
            this.userTextbox.Name = "userTextbox";
            this.userTextbox.ReadOnly = false;
            this.userTextbox.Size = new System.Drawing.Size(315, 34);
            this.userTextbox.TabIndex = 3;
            this.userTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.userTextbox.UseSystemPasswordChar = false;
            // 
            // passTextbox
            // 
            this.passTextbox.BackColor = System.Drawing.Color.Transparent;
            this.passTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.passTextbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.passTextbox.FocusOnHover = false;
            this.passTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.passTextbox.Location = new System.Drawing.Point(254, 208);
            this.passTextbox.MaxLength = 32767;
            this.passTextbox.Multiline = false;
            this.passTextbox.Name = "passTextbox";
            this.passTextbox.ReadOnly = false;
            this.passTextbox.Size = new System.Drawing.Size(315, 34);
            this.passTextbox.TabIndex = 4;
            this.passTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.passTextbox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.Transparent;
            this.loginButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.loginButton.Location = new System.Drawing.Point(309, 296);
            this.loginButton.Name = "loginButton";
            this.loginButton.Rounded = false;
            this.loginButton.Size = new System.Drawing.Size(120, 40);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Đăng nhập";
            this.loginButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
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
            this.closeButton.Location = new System.Drawing.Point(770, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.closeButton.Size = new System.Drawing.Size(18, 18);
            this.closeButton.TabIndex = 6;
            this.closeButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoginForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.LoginForm.ResumeLayout(false);
            this.LoginForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm LoginForm;
        private ReaLTaiizor.Controls.ForeverButton loginButton;
        private ReaLTaiizor.Controls.ForeverTextBox passTextbox;
        private ReaLTaiizor.Controls.ForeverTextBox userTextbox;
        private ReaLTaiizor.Controls.ForeverLabel passlabel;
        private ReaLTaiizor.Controls.ForeverLabel userlabel;
        private ReaLTaiizor.Controls.ForeverLabel loginlabel;
        private ReaLTaiizor.Controls.ForeverClose closeButton;
    }
}