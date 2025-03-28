using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeCuongProject
{
    public partial class DangNhap : Form
    {
        Modify m;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void Sign_in_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHienMatKhau.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btSIGNIn_Click(object sender, EventArgs e)
        {
            

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            
            if (email == "") { MessageBox.Show("Vui lòng nhập email!"); }
            else if (password == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
            }
            else
            {
                Modify m = new Modify();
                Taikhoans tk =   m.Taikhoans("select Email, Hoten , MaQuyen , MaNguoiDung from NguoiDung where Email='" + email + "' and Makhau ='" + password + "'");
                if (tk == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                }
                else
                {
                    Modify.taiKhoan = tk;
                    Home home = new Home();
                  
                    this.Hide();
                    home.Show();
                  

                }
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void grB_Enter(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
