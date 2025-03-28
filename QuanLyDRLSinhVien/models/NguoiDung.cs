using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeCuongProject.Modals
{
    internal class NguoiDung
    {
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Quyen { get; set; }

        public NguoiDung() { }
        public NguoiDung(string hoten, string ngSinh, string gioiTinh, string sdt, string email, string diachi, string quyen)
        {
            HoTen = hoten;
            NgaySinh = ngSinh;
            GioiTinh = gioiTinh;
            SoDT = sdt;
            Email = email;
            DiaChi = diachi;
            Quyen = quyen;
        }
    }
}
