using QuanLyDeCuongProject.Data;
using QuanLyDeCuongProject.Modals;
using QuanLyDeCuongProject.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyDeCuongProject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        NguoiDungQuery userQuery = new  NguoiDungQuery();
        
        private void Home_Load(object sender, EventArgs e)
        {
            if(Modify.taiKhoan == null )
            {
                MessageBox.Show("Bạn chưa đăng nhập tài khoản?");
                this.Close();
                
                return;
            }
            refershUser();


        }

        public void refershUser()
        {
            DataTable dt = userQuery.getDetailUser(Modify.taiKhoan.ma_nguoi_dung);
            string hoten = dt.Rows[0]["HoTen"].ToString(),
                ngaySinh = dt.Rows[0]["NgaySinh"].ToString(),
                gioitinh = dt.Rows[0]["GioiTinh"].ToString(),
                sdt = dt.Rows[0]["SoDT"].ToString(),
                dc = dt.Rows[0]["DiaChi"].ToString(),
                quyen = dt.Rows[0]["TenQuyen"].ToString(),
                email = dt.Rows[0]["Email"].ToString();
            Modify.user = new NguoiDung(hoten, ngaySinh, gioitinh, sdt, email, dc, quyen);



            displayDetailUser(Modify.user);
        }
         void displayDetailUser(NguoiDung user)
        {
            lbAddress.Text = user.DiaChi;
            lbEmail.Text = user.Email;
            lbName.Text = user.HoTen;
            lbSDT.Text = user.SoDT;
            lbNS.Text = user.NgaySinh;
            lbQuyen.Text = user.Quyen;
            lbGT.Text = user.GioiTinh;

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MonHoc_Click(object sender, EventArgs e)
        {
            if(Modify.taiKhoan.ma_quyen != 4)
            {
                  this.Hide();
                QLMonHoc mon_hoc_frm = new QLMonHoc();
                mon_hoc_frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void QLDeCuong_Click(object sender, EventArgs e)
        {

            this.Hide();
            DeCuong de_cuong_frm = new DeCuong();
            de_cuong_frm.ShowDialog();
            this.Show();

        }

        private void QLNganh_Click(object sender, EventArgs e)
        {

            if (Modify.taiKhoan.ma_quyen != 4 && Modify.taiKhoan.ma_quyen != 2)
            {
                this.Hide();
                QL_Nganh nganh_frm = new QL_Nganh();
                nganh_frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }

        private void QLPhanQuyen_Click(object sender, EventArgs e)
        {
            if (Modify.taiKhoan.ma_quyen != 4 && Modify.taiKhoan.ma_quyen != 2)
            {
                this.Hide();
                QuanLyPhanQuyen phan_quyen_frm = new QuanLyPhanQuyen();
                phan_quyen_frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void QLGiangVien_Click(object sender, EventArgs e)
        {
            if (Modify.taiKhoan.ma_quyen != 4 && Modify.taiKhoan.ma_quyen != 2)
            {
                this.Hide();
                GIANGVIEN giang_vien_frm = new GIANGVIEN();
                giang_vien_frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void QLSinhVien_Click(object sender, EventArgs e)
        {
            if (Modify.taiKhoan.ma_quyen != 4)
            {
                this.Hide();
                SINHVIEN sinh_vien_frm = new SINHVIEN();
                sinh_vien_frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoiMatKhau frm_password = new DoiMatKhau();
            frm_password.ShowDialog();
            this.Show();

        }

        private void label13_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
                       "Bạn có chắc chắn muốn đăng xuất?",
                       "Xác nhận đăng xuất",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);
            if(confirmResult == DialogResult.Yes)
            {
                Modify.taiKhoan = null;
                this.Close();
                DangNhap frm_signIn = new DangNhap();
                frm_signIn.ShowDialog();
               
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            CapNhatThongTinCaNhan frm_edit = new CapNhatThongTinCaNhan();
            frm_edit.ShowDialog();
           
       
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
