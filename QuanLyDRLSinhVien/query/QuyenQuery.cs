using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeCuongProject.Queries
{
    internal class QuyenQuery
    {
        DataBase database = new DataBase();
        public QuyenQuery()
        {

        }


        public DataTable getPermissionByUser(int per)
        {
            return database.ExecuteQuery($"select MaPermission from Quyen q, Quyen_Permission pq where pq.MaQuyen = q.MaQuyen and q.MaQuyen={per}");
        }
        public DataTable GetAllQuyen()
        {
            return database.ExecuteQuery("select * from Quyen");
        }
    }
}
