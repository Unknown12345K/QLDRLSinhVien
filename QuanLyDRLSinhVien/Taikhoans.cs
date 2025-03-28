using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeCuongProject
{
    internal class Taikhoans
    {
        public string email { get; set; }
        public string name { get; set; }
        public int ma_quyen {  get; set; }
        public string ma_nguoi_dung {  get; set; }

        public Taikhoans()
        {
        }

        public Taikhoans(string email, string name, int ma_quyen, string ma_nguoi_dung)
        {
            this.email = email;
            this.name = name;
            this.ma_quyen = ma_quyen;
            this.ma_nguoi_dung = ma_nguoi_dung;
        }

    
    }
}
