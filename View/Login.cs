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
                MessageBox.Show("Bạn cần nhập tên tài khoản", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userTextbox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(passTextbox.Text))
            {
                MessageBox.Show("Bạn cần nhập mật khẩu", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("Đăng nhập thất bại!\nKiểm tra lại tài khoản và mật khẩu", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
