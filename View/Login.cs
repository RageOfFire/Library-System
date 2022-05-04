using Controller;
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

namespace View
{
    public partial class Login : System.Windows.Forms.Form
    {
        ControllerLogin login = new ControllerLogin();
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userTextbox.Text))
            {
                
                PoisonMessageBox.Show(this, "Bạn cần nhập tên tài khoản", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userTextbox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(passTextbox.Text))
            {
                PoisonMessageBox.Show(this, "Bạn cần nhập mật khẩu", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passTextbox.Focus();
            }
            else
            {
                try
                {
                    DataTable dt = login.Login(this.userTextbox.Text, this.passTextbox.Text);
                    if (dt.Rows.Count > 0)
                    {
                        this.Hide();
                        Sach sach = new Sach();
                        sach.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        PoisonMessageBox.Show(this, "Đăng nhập thất bại!\nKiểm tra lại tài khoản và mật khẩu", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    PoisonMessageBox.Show(this, "Error" + ex, "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
