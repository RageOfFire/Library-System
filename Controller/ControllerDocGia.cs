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
    public class ControllerDocGia
    {
        Database db = new Database();
        public void InsertDG(string madocgia, string tendocgia, string diachi, int sothe)
        {
            string sql_add = "INSERT INTO DocGia VALUES(N'" + madocgia + "',N'" + tendocgia + "',N'" + diachi + "',N'" + sothe + "')";
            db.ExecuteNonQuery(sql_add);
        }
        public void UpdateDG(string madocgia, string tendocgia, string diachi, int sothe)
        {
            string sql_update = "UPDATE DocGia SET Ten_doc_gia = N'" + tendocgia + "',DiaChi = N'" + diachi + "', SoThe = '" + sothe + "' WHERE Ma_doc_gia = N'" + madocgia + "'";
            db.ExecuteNonQuery(sql_update);
        }
        public void DeleteDG(string madocgia)
        {
            string sql_delete = "DELETE DocGia WHERE Ma_doc_gia = N'" + madocgia + "'";
            db.ExecuteNonQuery(sql_delete);
        }
        public DataTable TimDG(string key)
        {
            string sql = "SELECT * FROM DocGia WHERE Ma_doc_gia LIKE '%" + key + "%' OR Ten_doc_gia LIKE '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public DataTable HienThiDG()
        {
            string sql = "SELECT * FROM DocGia";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public SqlDataReader HienthiST_CB()
        {
            string sqlst_cb = "SELECT * FROM TheThuVien";
            SqlDataReader drST;
            drST = db.Get_DR(sqlst_cb);
            return drST;
        }
    }
}
