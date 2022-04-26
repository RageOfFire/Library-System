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
    public class ControllerCTMT
    {
        Database db = new Database();
        public void InsertCTMT(string maMT, string maS, string ghiChu, string daTra, string ngayTra)
        {
            string sql_add = "INSERT INTO CTMuonTra VALUES('" + maMT + "','" + maS + "','"+ ghiChu +"','"+ daTra +"','"+ ngayTra +"')";
            db.ExecuteNonQuery(sql_add);
        }
        public void UpdateCTMT(string maMT, string maS, string ghiChu, string daTra, string ngayTra)
        {
            string sql_update = "UPDATE CTMuonTra SET Ma_muon_tra = N'" + maMT + "', Ma_sach = N'"+ maS +"', Ghi_chu = N'"+ ghiChu +"', Da_tra = N'"+ daTra +"', Ngay_tra = N'"+ ngayTra +"' WHERE Ma_muon_tra = N'" + maMT + "'";
            db.ExecuteNonQuery(sql_update);
        }
        public void DeleteCTMT(string maMT)
        {
            string sql_delete = "DELETE CTMuonTra WHERE Ma_muon_tra = N'" + maMT + "'";
            db.ExecuteNonQuery(sql_delete);
        }
        public DataTable TimCTMT(string key)
        {
            string sql = "SELECT * FROM CTMuonTra WHERE Ma_muon_tra LIKE '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public DataTable HienThiCTMT()
        {
            string sql = "SELECT * FROM CTMuonTra";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public SqlDataReader HienthiMT_CB()
        {
            string sqlmt_cb = "SELECT * FROM MuonTra";
            SqlDataReader drMT;
            drMT = db.Get_DR(sqlmt_cb);
            return drMT;
        }
        public SqlDataReader HienthiS_CB()
        {
            string sqls_cb = "SELECT * FROM Sach";
            SqlDataReader drS;
            drS = db.Get_DR(sqls_cb);
            return drS;
        }
    }
}
