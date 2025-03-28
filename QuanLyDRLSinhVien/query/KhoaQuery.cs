using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeCuongProject.Query
{
    internal class KhoaQuery
    {
        DataBase database = new DataBase();
        public DataTable GetAllKhoa()
        {
            return database.ExecuteQuery("select * from KHOA ");
        }
    }
}
