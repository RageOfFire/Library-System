using System;
using System.Data;
using System.Windows.Forms;
using Controller;
using ReaLTaiizor.Controls;

namespace View
{
    public partial class UserMuonTra : Form
    {
        public UserMuonTra(string username)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(username))
            {
                userStatus.Text = "Chào mừng trở lại " + username;
            }
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

        private void MuonTraUserGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = e.RowIndex;
            string sach = MuonTraUserGridView.Rows[i].Cells[1].Value.ToString();
            string theloai = MuonTraUserGridView.Rows[i].Cells[2].Value.ToString();
            string tacgia = MuonTraUserGridView.Rows[i].Cells[3].Value.ToString();
            string nxb = MuonTraUserGridView.Rows[i].Cells[4].Value.ToString();
            string masach = MuonTraUserGridView.Rows[i].Cells[5].Value.ToString();
            string info = 
                "Thông tin của sách là: " +
                "\nTên sách: " + sach +
                "\nThể loại: " + theloai +
                "\nTác giả: " + tacgia +
                "\nNhà xuất bản: " + nxb;
            DialogResult rs = PoisonMessageBox.Show(this, info, "Quản lý thư viện", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                user.InsertData(masach);
                PoisonMessageBox.Show(this, "Thông tin của bạn đã được lưu lại\nHãy tới thư viện dể đăng ký mượn sách", "Quản lý thư viện", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult rs = PoisonMessageBox.Show(this, "Bạn có muốn thoát khỏi ứng dụng ?", "Quản lý thư viện", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
            }
        }
    }
}
