using Controller;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace View
{
    public partial class Login : System.Windows.Forms.Form
    {
        ControllerLogin login = new ControllerLogin();
        SqlDataReader drc;
        string check;
        public Login()
        {
            InitializeComponent();
        }

        //Khi người dùng ấn nút đăng nhập
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
                        drc = login.CheckUser(this.userTextbox.Text, this.passTextbox.Text);
                        PoisonMessageBox.Show(this, "Đăng nhập thành công", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (drc.Read())
                        {
                            check = drc["Nhan_vien"].ToString();
                            if (check == "1")
                            {
                                this.Hide();
                                Sach sach = new Sach(this.userTextbox.Text);
                                sach.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                                UserMuonTra user = new UserMuonTra(this.userTextbox.Text);
                                user.ShowDialog();
                                this.Close();
                            }
                        }


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

        //Khi người dùng ấn nút đăng ký
        private void RegButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserRegBox.Text))
            {

                PoisonMessageBox.Show(this, "Bạn cần nhập tên tài khoản", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UserRegBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PassRegBox.Text))
            {
                PoisonMessageBox.Show(this, "Bạn cần nhập mật khẩu", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PassRegBox.Focus();
            }
            else if(PassRegBox.Text != RePassReg.Text)
            {
                PoisonMessageBox.Show(this, "Mật khẩu nhập lại không trùng nhau", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RePassReg.Focus();
            }
            else
            {
                try
                {
                    DataTable dt = login.Login(this.userTextbox.Text, this.passTextbox.Text);
                    if (dt.Rows.Count == 0)
                    {
                        login.InsertREG(this.UserRegBox.Text, this.PassRegBox.Text);
                        PoisonMessageBox.Show(this, "Đăng ký tài khoản thành công\nGiờ bạn có thể đăng nhập vào hệ thống", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoginTab.SelectedIndex = 1;
                        
                    }
                    else
                    {
                        PoisonMessageBox.Show(this, "Người dùng đã tồn tại trong hệ thống", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
