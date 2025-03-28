using QuanLyDeCuongProject.Queries;
using QuanLyDeCuongProject.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeCuongProject
{
    internal class Helpers
    {
        QuyenQuery quyenQuery = new QuyenQuery();
        MonHocQuery monHocQuery = new MonHocQuery();


        public bool checkPermission(int permission, int permissonUser)
        {
            
            DataTable dt = quyenQuery.getPermissionByUser(permissonUser);
           
            for(int i=0; i<dt.Rows.Count; i++)
            {
               
                if (int.Parse(dt.Rows[i][0].ToString()) == permission)
                {
                    return true;
                }
            }
            return false;
        }
         public void XulySangToi(bool check,Button btnAdd, Button btnEdit, Button btnDelete, Button btnSave = null)
        {
            btnAdd.Enabled = check;
            btnEdit.Enabled = check;
            btnDelete.Enabled = check;
            if(btnSave != null)
            {
                btnSave.Enabled = !check;

            }
        }
        public bool IsValidEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);
        }

        public void createFile(string madc, string tenDc, string maMH, string hoten)
        {
            DataTable dt = monHocQuery.getSubject(maMH);

            string soTC = dt.Rows[0]["SoTC"].ToString(),
                tietTH = dt.Rows[0]["SoTietTH"].ToString(),
                tietLT = dt.Rows[0]["SoTietLT"].ToString();


            int num = ((int.Parse(soTC) + int.Parse(tietLT) )* 100 / (int.Parse(tietTH) + int.Parse(tietLT)));


            File.Create($"{madc}.txt").Close(); // Create file
             using (StreamWriter sw = File.AppendText($"{madc}.txt"))
             {
                 sw.WriteLine($"CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAMUBND TỈNH TIỀN GIANG       " +
                     $"\r\n\r\n\r\n\r\n\r\nTRƯỜNG ĐẠI HỌC TIỀN GIANG                             " +
                     $"\t\t\t\tĐộc lập  -  Tự do -   Hạnh phúc" +
                     $"\r\n\t\t\t\t\t\t\t\t   Tiền Giang, ngày   tháng 10  năm 2023" +
                     $"\r\nĐỀ CƯƠNG CHI TIẾT HỌC PHẦN " +
                     $"\r\nTÊN HỌC PHẦN:  {tenDc}" +
                     $"\r\n\r\n\r\n\r\nMã học phần: {maMH} " +
                     $"\r\n1. Đơn vị quản lý học phần " +
                     $"\r\n-Tên Khoa: Khoa Kỹ thuật Công nghệ" +
                     $"\r\n-Tên Bộ môn: Bộ môn Công nghệ thông tin " +
                     $"\r\n2. Thông tin chung về học phần " +
                     $"\r\n- Mã học phần:{maMH} " +
                     $"\r\n- Tên học phần:  {tenDc} " +
                     $"\r\n- Số tín chỉ: {soTC} " +
                     $"\r\n- Số tiết (LT, TL, TH, TT, ĐA):  {tietLT}, 0, {tietTH}, 0, 0 " +
                     $"\r\n- Thuộc CTĐT: Đại học Công nghệ thông tin " +
                     $"\r\n3. Học phần có liên hệ" +
                     $"\r\n- Học phần tiên quyết: Không có " +
                     $"\r\n- Học phần học trước: Không có " +
                     $"\r\n- Học phần song hành: Không có " +
                     $"\r\n4. Phương thức kiểm tra, đánh giá học phần " +
                     $"\r\n5.  Đánh giá quá trình" +
                     $"\r\n- Trọng số: {100 - num}%  " +
                     $"\r\n- Số cột điểm: 1 " +
                     $"\r\n-  Thang điểm: 10 " +
                     $"\r\n6. Đánh giá cuối kỳ" +
                     $"\r\n- Trọng số: {num}%   " +
                     $"\r\n- Hình thức đánh giá: Báo cáo đồ án ngành" +
                     $" \r\n\t\t\t\t\t\t\t\t\t\tGIANG VIEN" +
                     $"\r\n\t\t\t\t\t\t\t\t\t\t{hoten}"); 

             // Write text to .txt file
             }
        }
    }
}
