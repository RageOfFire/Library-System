using System.Data;
using System.Data.SqlClient;
using Model;

namespace Controller
{
    public class ControllerLogin
    {
        Database db = new Database();
        // Đăng ký
        public void InsertREG(string username, string password)
        {
            string sql_add = "INSERT INTO NguoiDung (Ten_nguoi_dung, Mat_khau) VALUES ('" + username + "', '" + password + "')";
            db.ExecuteNonQuery(sql_add);
        }
        // Đăng nhập
        public DataTable Login(string username, string password)
        {
            string sql_login = "SELECT * FROM NguoiDung WHERE Ten_nguoi_dung = N'" + username + "' AND Mat_khau = N'" + password + "'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql_login);
            return dt;
        }
        // Kiểm tra người dùng có phải quản lý không ?
        public SqlDataReader CheckUser(string username, string password)
        {
            string sqlmt_ck = "SELECT Nhan_vien FROM NguoiDung WHERE Ten_nguoi_dung = N'" + username + "' AND Mat_khau = N'" + password + "'";
            SqlDataReader dr;
            dr = db.Get_DR(sqlmt_ck);
            return dr;
        }
    }
}
