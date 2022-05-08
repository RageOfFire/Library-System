using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class UserMuonTra : Form
    {
        public UserMuonTra()
        {
            InitializeComponent();
        }
        UserMuonTraController user = new UserMuonTraController();
        DataTable dt = new DataTable();
        private void UserThuVien_Layout(object sender, LayoutEventArgs e)
        {
            dt = user.HienThi();
            MuonTraUserGridView.DataSource = dt;
            for (int i = 0; i < MuonTraUserGridView.Rows.Count; i++)
            {
                MuonTraUserGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }
    }
}
