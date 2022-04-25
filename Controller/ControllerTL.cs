using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class ControllerTL
    {
        Database db = new Database();
        public void InsertTL(string maTL, string tenTL)
        {
            string sql_add = "INSERT INTO TheLoai VALUES('" + maTL + "','" + tenTL + "')";
            db.ExecuteNonQuery(sql_add);
        }
        public void UpdateTL(string maTL, string tenTL)
        {
            string sql_update = "UPDATE TheLoai SET Ten_the_loai = N'" + tenTL + "' WHERE Ma_the_loai = N'" + maTL + "'";
            db.ExecuteNonQuery(sql_update);
        }
        public void DeleteTL(string maTL)
        {
            string sql_delete = "DELETE TheLoai WHERE Ma_the_loai = N'" + maTL + "'";
            db.ExecuteNonQuery(sql_delete);
        }
        public DataTable TimTL(string key)
        {
            string sql = "SELECT * FROM TheLoai WHERE Ma_the_loai LIKE '%" + key + "%' OR Ten_the_loai LIKE '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public DataTable HienThiTL()
        {
            string sql = "SELECT * FROM TheLoai";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
    }
}
