using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class ControllerTacGia
    {
        Database db = new Database();
        public void InsertTG(string tentacgia, string website, string ghichu)
        {
            string sql_add = "INSERT INTO TacGia (Ten_tac_gia, website, Ghi_chu) VALUES(N'" + tentacgia + "',N'" + website + "',N'" + ghichu + "')";
            db.ExecuteNonQuery(sql_add);
        }
        public void UpdateTG(string matacgia, string tentacgia, string website, string ghichu)
        {
            string sql_update = "UPDATE TacGia SET Ten_tac_gia = N'" + tentacgia + "',website = N'" + website + "', Ghi_chu = '" + ghichu + "' WHERE Ma_tac_gia = N'" + matacgia + "'";
            db.ExecuteNonQuery(sql_update);
        }
        public void DeleteTG(string matacgia)
        {
            string sql_delete = "DELETE TacGia WHERE Ma_tac_gia = N'" + matacgia + "'";
            db.ExecuteNonQuery(sql_delete);
        }
        public DataTable TimTG(string key)
        {
            string sql = "SELECT * FROM TacGia WHERE Ma_tac_gia LIKE '%" + key + "%' OR Ten_tac_gia LIKE '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public DataTable HienThiTG()
        {
            string sql = "SELECT * FROM TacGia";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
    }
}
