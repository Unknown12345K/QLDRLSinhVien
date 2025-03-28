using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using QuanLyDeCuongProject.Consts;
namespace QuanLyDeCuongProject
{
   
    internal class CSDL
    {
       

        public static string svName = @"ADMIN\SQLEXPRESS";
        public static string dbName = "QuanLyDeCuong";

        public static string MaGV = "";
        public static string TenHienThi = "";
        public static string LoaiTaiKhoan = "";
        public static string TK = "";
        public static string MK = "";
        public static SqlConnection cn;

        public static void KetNoi()
        {
            string sql = $@"Data Source={Const.ServerName};Initial Catalog=QuanLyDeCuong;Integrated Security=True";
            cn = new SqlConnection(sql);

        }
        public static DataTable LayDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter data = new SqlDataAdapter(sql, cn);
           
            data.Fill(dt);
            return dt;
        }
        public static void XuLy(string sql)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            CSDL.GhiLenhXuLySQL(sql);
        }

        // Ghi các lệnh xử lý sql ở file XuLySQL.txt trong ổ D
        public static void GhiLenhXuLySQL(string sql)
        {
           
        }
    }
}
