using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class ControllerNXB
    {
        Database db = new Database();
        public void InsertNXB(string maNXB, string tenNXB, string diachi, string email, string thongtin)
        {
            string sql_add = "INSERT INTO NhaXuatBan VALUES(N'" + maNXB + "',N'" + tenNXB + "',N'" + diachi + "',N'" + email + "',N'"+ thongtin +"')";
            db.ExecuteNonQuery(sql_add);
        }
        public void UpdateNXB(string maNXB, string tenNXB, string diachi, string email, string thongtin)
        {
            string sql_update = "UPDATE NhaXuatBan SET Ten_NXB = N'" + tenNXB + "',DiaChi = N'" + diachi + "', email = '" + email + "', ThongTin = '"+ thongtin +"' WHERE Ma_NXB = N'" + maNXB + "'";
            db.ExecuteNonQuery(sql_update);
        }
        public void DeleteNXB(string maNXB)
        {
            string sql_delete = "DELETE NhaXuatBan WHERE Ma_NXB = N'" + maNXB + "'";
            db.ExecuteNonQuery(sql_delete);
        }
        public DataTable TimNXB(string key)
        {
            string sql = "SELECT * FROM NhaXuatBan WHERE Ma_NXB LIKE '%" + key + "%' OR Ten_NXB LIKE '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public DataTable HienThiNXB()
        {
            string sql = "SELECT * FROM NhaXuatBan";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
    }
}
