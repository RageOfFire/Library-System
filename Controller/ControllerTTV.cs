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
    public class ControllerTTV
    {
        Database db = new Database();
        public void InsertTTV(int sothe, string ngayBatDau, string ngayHetHan, string ghiChu)
        {
            string sql_add = "INSERT INTO TheThuVien VALUES(N'" + sothe + "',N'" + ngayBatDau + "',N'" + ngayHetHan + "',N'" + ghiChu + "')";
            db.ExecuteNonQuery(sql_add);
        }
        public void UpdateTTV(int sothe, string ngayBatDau, string ngayHetHan, string ghiChu)
        {
            string sql_update = "UPDATE TheThuVien SET Ngay_bat_dau = N'" + ngayBatDau + "',Ngay_het_han = N'" + ngayHetHan + "', GhiChu = '" + ghiChu + "' WHERE SoThe = N'" + sothe + "'";
            db.ExecuteNonQuery(sql_update);
        }
        public void DeleteTTV(int sothe)
        {
            string sql_delete = "DELETE TheThuVien WHERE SoThe = N'" + sothe + "'";
            db.ExecuteNonQuery(sql_delete);
        }
        public DataTable TimTTV(string key)
        {
            string sql = "SELECT * FROM TheThuVien WHERE Sothe LIKE '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public DataTable HienThiTTV()
        {
            string sql = "SELECT * FROM TheThuVien";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
    }
}
