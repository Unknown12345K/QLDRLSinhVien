using QuanLyDeCuongProject.Modals;
using QuanLyDeCuongProject.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;

namespace QuanLyDeCuongProject
{
    public partial class CapNhatThongTinCaNhan : Form
    {
        public CapNhatThongTinCaNhan()
        {
            InitializeComponent();
        }
        NguoiDungQuery userQuery = new NguoiDungQuery();

        private void SuaThongTinCaNhan_Load(object sender, EventArgs e)
        {
            if (Modify.taiKhoan == null)
            {
                MessageBox.Show("Bạn chưa đăng nhập tài khoản?");
                this.Close();

                return;
            }
            displayComboGender();
            displayField();
        }

        public void displayField()
        {
            txtEmail.Text = Modify.user.Email;
            txtName.Text = Modify.user.HoTen;
            txtBorn.Text = Modify.user.NgaySinh;
            txtPermission.Text = Modify.user.Quyen;
            txtAddress.Text = Modify.user.DiaChi;
            txtPhone.Text = Modify.user.SoDT;
            cbGender.Text = Modify.user.GioiTinh;

        }
        void displayComboGender()
        {
            cbGender.Items.Add("Nam");
            cbGender.Items.Add("Nữ");
        }
        private void button1_Click(object sender, EventArgs e)
        {
        
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Home h = new Home();
                h.Show();
            
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Home h = new Home();
            h.Show();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    if(txtAddress.Text.Trim().Length==0 || txtPhone.Text.Trim().Length == 0 || txtName.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin?", "Dữ liệu không hợp lệ", MessageBoxButtons.OK);
                        return;
                    }
                    NguoiDung userEdit = new NguoiDung();
                    userEdit.DiaChi = txtAddress.Text;
                    userEdit.NgaySinh = txtBorn.Value.ToString("MM/dd/yyyy");
                    userEdit.GioiTinh = cbGender.SelectedItem.ToString();
                    userEdit.SoDT = txtPhone.Text;
                    userEdit.HoTen = txtName.Text;
                    userQuery.UpdateUser(userEdit, Modify.taiKhoan.ma_nguoi_dung);
                    MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK);
                    this.Close();
                    Home h = new Home();
                    h.refershUser();
                    h.Show();
                }
                else
                {
                    MessageBox.Show("Hành động bị hủy bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cập nhật thất bài");
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
