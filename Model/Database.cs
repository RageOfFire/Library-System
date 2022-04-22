using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Database
    {
        // Kết nối
        public SqlConnection Connection()
        {
            return new SqlConnection(@"Data Source=SONIT\SQLEXPRESS;Initial Catalog=QLTV_BTL;Integrated Security=True");
        }
        // Phương thức ExecuteNonQuery -> Ko trả về giá trị
        public void ExecuteNonQuery(string sql)
        {
            SqlConnection conn = Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Dispose();
        }
        public DataTable GetTable(string sql)
        {
            SqlConnection conn = Connection();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public SqlDataReader Get_DR(string sql)
        {
            SqlConnection conn = Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
    }
}
