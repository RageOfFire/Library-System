using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class ControllerLogin
    {
        Database db = new Database();
        public DataTable Login(string username, string password)
        {
            string sql_login = "SELECT * FROM NguoiDung WHERE Ten_nguoi_dung = N'" + username + "' AND Mat_khau = N'" + password + "'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql_login);
            return dt;
        }
    }
}
