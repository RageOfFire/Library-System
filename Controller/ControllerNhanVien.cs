using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class ControllerNhanVien
    {
        Database db = new Database();
        public void InsertNV(string manv, string tennv, string ngaysinh, int sdt)
        {
            string sql_add = "INSERT INTO NhanVien VALUES(N'" + manv + "',N'" + tennv + "',N'" + ngaysinh + "',N'" + sdt + "')";
            db.ExecuteNonQuery(sql_add);
        }
        public void UpdateNV(string manv, string tennv, string ngaysinh, int sdt)
        {
            string sql_update = "UPDATE NhanVien SET Ho_ten = N'" + tennv + "',Ngay_sinh = N'" + ngaysinh + "', Sdt = '" + sdt + "' WHERE Ma_nhan_vien = N'" + manv + "'";
            db.ExecuteNonQuery(sql_update);
        }
        public void DeleteNV(string manv)
        {
            string sql_delete = "DELETE NhanVien WHERE Ma_nhan_vien = N'" + manv + "'";
            db.ExecuteNonQuery(sql_delete);
        }
        public DataTable TimNV(string key)
        {
            string sql = "SELECT * FROM NhanVien WHERE Ma_nhan_vien LIKE '%" + key + "%' OR Ho_ten LIKE '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public DataTable HienThiNV()
        {
            string sql = "SELECT * FROM NhanVien";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
    }
}
