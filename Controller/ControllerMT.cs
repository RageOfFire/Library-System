﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class ControllerMT
    {
        Database db = new Database();
        public void InsertMT(string maMT, int soThe, string maNhanVien, string ngayMuon)
        {
            string sql_add = "INSERT INTO MuonTra VALUES('" + maMT + "','" + soThe + "','"+ maNhanVien +"','"+ ngayMuon +"')";
            db.ExecuteNonQuery(sql_add);
        }
        public void UpdateMT(string maMT, int soThe, string maNhanVien, string ngayMuon)
        {
            string sql_update = "UPDATE MuonTra SET Sothe = N'"+ soThe +"', Ma_nhan_vien = N'"+ maNhanVien +"', Ngay_muon = N'"+ ngayMuon +"' WHERE Ma_muon_tra = N'" + maMT + "'";
            db.ExecuteNonQuery(sql_update);
        }
        public void DeleteMT(string maMT)
        {
            string sql_delete = "DELETE MuonTra WHERE Ma_muon_tra = N'" + maMT + "'";
            db.ExecuteNonQuery(sql_delete);
        }
        public DataTable TimMT(string key)
        {
            string sql = "SELECT * FROM MuonTra WHERE Ma_muon_tra LIKE '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public DataTable HienThiMT()
        {
            string sql = "SELECT * FROM MuonTra";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
        public SqlDataReader HienthiNV_CB()
        {
            string sqlmt_cb = "SELECT * FROM NhanVien";
            SqlDataReader drMT;
            drMT = db.Get_DR(sqlmt_cb);
            return drMT;
        }
        public SqlDataReader HienthiST_CB()
        {
            string sqls_cb = "SELECT * FROM TheThuVien";
            SqlDataReader drS;
            drS = db.Get_DR(sqls_cb);
            return drS;
        }
    }
}
