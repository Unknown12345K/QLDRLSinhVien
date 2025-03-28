using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeCuongProject.Query
{
    internal class NganhQuery
    {


        DataBase database = new DataBase();
        public DataTable GetAllNganh()
        {
            return database.ExecuteQuery("select * from NGANH");
        }

        public DataTable LayTheoMaKhoa(string makhoa)
        {
            return database.ExecuteQuery($"select * from NGANH N, KHOA K where N.MaKhoa = K.MaKhoa and K.MaKhoa = '{makhoa}'");
        }
        public DataTable LayTheoMaNganh(string maNganh)
        {
            return database.ExecuteQuery($"select * from NGANH where MaNganh='{maNganh}'");
        }
        public void DeleteNganh(string maNganh)
        {
            database.ExecuteNonQuery($"Delete Nganh where MaNganh='{maNganh}'");
        }
    }
}
