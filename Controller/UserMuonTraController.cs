using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class UserMuonTraController
    {
        Database db = new Database();
        public DataTable HienThi()
        {
            string sql = "SELECT Ten_sach, Ten_tac_gia, Ten_NXB, Ten_the_loai FROM Sach, TacGia, NhaXuatBan, TheLoai WHERE Sach.Ma_tac_gia = TacGia.Ma_tac_gia AND Sach.Ma_NXB = NhaXuatBan.Ma_NXB AND Sach.Ma_the_loai = TheLoai.Ma_the_loai";
            DataTable dt = new DataTable();
            dt = db.GetTable(sql);
            return dt;
        }
    }
}
