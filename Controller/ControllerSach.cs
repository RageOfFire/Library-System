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
    public class ControllerSach
    {
        Database db = new Database();
        public void InsertS(string tensach, string matacgia, string matheloai, string maNXB, int namXB)
        {
            string sql_add = "INSERT INTO Sach (Ten_sach, Ma_tac_gia, Ma_the_loai, Ma_NXB, Nam_XB) VALUES(N'" + tensach + "',N'" + matacgia + "',N'" + matheloai + "',N'" + maNXB + "',N'" + namXB + "')";
            db.ExecuteNonQuery(sql_add);
        }
        public void UpdateS(string masach, string tensach, string matacgia, string matheloai, string maNXB, int namXB)
        {
            string sql_update = "UPDATE Sach SET Ten_sach = N'" + tensach + "',Ma_tac_gia = N'" + matacgia + "', Ma_the_loai = '" + matheloai + "',Ma_NXB = N'" + maNXB + "'',Nam_XB = N'"+ namXB +"' WHERE Ma_sach = N'" + masach + "'";
            db.ExecuteNonQuery(sql_update);
        }
        public void DeleteS(string masach)
        {
            string sql_delete = "DELETE Sach WHERE Ma_sach = N'" + masach + "'";
            db.ExecuteNonQuery(sql_delete);
        }
        public DataTable TimS(string key)
        {
            string sql = "SELECT * FROM Sach WHERE Ma_sach LIKE '%" + key + "%' OR Ten_sach LIKE '%"+ key +"%'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public DataTable HienThiS()
        {
            string sql = "SELECT * FROM Sach";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public SqlDataReader HienthiTG_CB()
        {
            string sqltg_cb = "SELECT * FROM TacGia";
            SqlDataReader drTG;
            drTG = db.Get_DR(sqltg_cb);
            return drTG;
        }
        public SqlDataReader HienthiTL_CB()
        {
            string sqltl_cb = "SELECT * FROM TheLoai";
            SqlDataReader drTL;
            drTL = db.Get_DR(sqltl_cb);
            return drTL;
        }
        public SqlDataReader HienthiNXB_CB()
        {
            string sqlnxb_cb = "SELECT * FROM NhaXuatBan";
            SqlDataReader drNXB;
            drNXB = db.Get_DR(sqlnxb_cb);
            return drNXB;
        }
    }
}
