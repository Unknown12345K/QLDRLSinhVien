using QuanLyDeCuongProject.Data;
using QuanLyDeCuongProject.Modals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeCuongProject.Query
{
    internal class NguoiDungQuery
    {
        DataBase db = new DataBase();

        public void UpdateUser(NguoiDung user, string maND)
        {

            try
            {
                 db.ExecuteNonQuery($"update NguoiDung set HoTen=N'{user.HoTen}', NgaySinh='{user.NgaySinh}', GioiTinh=N'{user.GioiTinh}', SoDT='{user.SoDT}', DiaChi=N'{user.DiaChi}' where MaNguoiDung='{maND}'");

            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi truyền  tham số");
            }
        }

        public  DataTable getDetailUser(string maND)
        {
            try
            {
                return db.ExecuteQuery($"select * from NguoiDung ng, Quyen q where ng.MaQuyen = q.MaQuyen and MaNguoiDung='{maND}'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truyền  tham số");

            }
            return null;
            
        }

        public DataTable getPassword(string maND)
        {
            try
            {
                return db.ExecuteQuery($"select Makhau from NguoiDung where  MaNguoiDung='{maND}'");
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi truyền  tham số");
            }
            return null;
        }

        public void UpdatePassword(string newPassword, string maND)
        {
            try
            {
                db.ExecuteNonQuery($"update NguoiDung set Makhau='{newPassword}' where MaNguoiDung='{maND}'");
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi truyền  tham số");
            }
        }
    }
}
