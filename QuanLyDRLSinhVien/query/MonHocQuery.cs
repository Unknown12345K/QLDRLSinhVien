using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeCuongProject.Query
{
    internal class MonHocQuery
    {

        DataBase db = new DataBase();

       
        public DataTable getSubject(string maMH)
        {
            try
            {
                return db.ExecuteQuery($"Select * from MONHOC where MaMH = N'{maMH}'");

            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi tham số");
            }

            return null;
        }
    }
}
