using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyDeCuongProject.Data;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;
using QuanLyDeCuongProject.Modals;


namespace QuanLyDeCuongProject
{
    internal class Modify
    {
        public static Taikhoans taiKhoan = null;
        public static NguoiDung user;
        DataBase db = new DataBase();
        public Modify()
        {
        }
        public Taikhoans Taikhoans(string query)
        {
            DataTable dt= db.ExecuteQuery(query);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int maquyen = int.Parse(dt.Rows[0]["MaQuyen"].ToString());
            string manguoidung = dt.Rows[0]["MaNguoiDung"].ToString();
            Taikhoans tk = new Taikhoans(dt.Rows[0]["Email"].ToString(), dt.Rows[0]["Hoten"].ToString(),maquyen,manguoidung);
            return tk;
        }
    }
}
