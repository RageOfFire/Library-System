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
            DataTable dt = login.Login(this.userTextbox.Text, this.passTextbox.Text);
            if(dt.Rows.Count > 0)
            {
                MessageBox.Show("Vjp", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Khong Vip", "Bùi Hồng Sơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
