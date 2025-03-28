using QuanLyDeCuongProject.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyDeCuongProject
{
    public partial class SINHVIEN : Form
    {
        Helpers helper = new Helpers();
        public SINHVIEN()
        {
            InitializeComponent();
        }
        string maND;
        SqlConnection cn = new SqlConnection($@"Data Source={Const.ServerName};Initial Catalog=QuanLyDeCuong;Integrated Security=True"); 
        public DataTable LayDL(string cm)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm, cn);
            da.Fill(dt);
            return dt;
        }
        void hienthi(DataTable dt)
        {
            listSV.Items.Clear();
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listSV.Items.Add(dt.Rows[i]["MaSV"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["Hoten"].ToString());
            
            }
            lbSL.Text = $"{dt.Rows.Count} Sinh viên";
        }
        private void SINHVIEN_Load(object sender, EventArgs e)
        {
            if (Modify.taiKhoan == null)
            {
                MessageBox.Show("Bạn chưa đăng nhập tài khoản?");
                this.Close();

                return;
            }
            if (!helper.checkPermission(5, Modify.taiKhoan.ma_quyen))
            {
                
                this.Close();
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            helper.XulySangToi(true, btnthem, btncapnhat, btnxoa, btghi);
            // +++++++ PHÂN QUYỀN ++++++++++++
            cbbgt.Items.Add("Nu");
            cbbgt.Items.Add("Nam");

            DataTable dt1 = LayDL("select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten  from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma");
            DataTable dt = LayDL("select * from LOP");
            cbLOP.DataSource = dt;
            cbLOP.DisplayMember = "TenLop";
            cbLOP.ValueMember = "MaLop";

            DataTable dt2 = LayDL("select * from NGANH");
            cbnganh.DataSource = dt2;
            cbnganh.DisplayMember = "TenNganh";
            cbnganh.ValueMember = "MaNganh";

            DataTable dt3 = LayDL("select * from HinhThucDaoTao");
            cbhtdt.DataSource = dt3;
            cbhtdt.DisplayMember = "Ten";
            cbhtdt.ValueMember = "Ma";
            hienthi(dt1);

        }

        private void listSV_Click(object sender, EventArgs e)
        {
            int vt = listSV.SelectedItems[0].Index;
            string sql = $"select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten  from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma and sv.MaSV='{listSV.Items[vt].SubItems[0].Text}'";
            DataTable dt = LayDL(sql);
            txtMssv.Text = dt.Rows[0]["MaSV"].ToString();
            txtHoten.Text = dt.Rows[0]["HoTen"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtSDT.Text = dt.Rows[0]["SoDT"].ToString();
            txtDiachi.Text = dt.Rows[0]["DiaChi"].ToString();
            dtns.Value = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());

            cbbgt.Text = dt.Rows[0]["GioiTinh"].ToString();

            cbnganh.Text = dt.Rows[0]["TenNganh"].ToString();
            cbhtdt.Text = dt.Rows[0]["Ten"].ToString();
            cbLOP.Text = dt.Rows[0]["TenLop"].ToString();

        }
        public void reset()
        {
            txtMssv.Text = "";
            txtHoten.Text = "";
            dtns.Text = "";
            cbbgt.Text = "";            
            txtSDT.Text = "";
            cbnganh.Text = "";
            txtEmail.Text = "";
            cbLOP .Text = "";
            cbhtdt.Text = "";
            txtDiachi.Text = "";
            
            
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!helper.checkPermission(6, Modify.taiKhoan.ma_quyen))
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            helper.XulySangToi(false, btnthem, btncapnhat, btnxoa, btghi);
            
            // +++++++ PHÂN QUYỀN ++++++++++++

            string sql = "select top 1 MaSV from SINHVIEN ORDER BY MaSV DESC";
            DataTable dt = LayDL(sql);
            string newMaSV = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
            txtMssv.Text = "0"+newMaSV;

            string sql1 = "select top 1 MaNguoiDung from NguoiDung ORDER BY MaNguoiDung DESC";
            DataTable dt1 = LayDL(sql1);
            string newMaND = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
            string a = dt1.Rows[0][0].ToString();
            maND = "ND" + (int.Parse(a.Substring(a.Length - 2, 2)) + 1).ToString("0000");
            txtHoten.Text = "";
            dtns.Text = "";
            cbbgt.Text = "";
            txtSDT.Text = "";
            cbnganh.Text = "";
            txtEmail.Text = "";
            cbLOP.Text = "";
            cbhtdt.Text = "";
            txtDiachi.Text = "";


        }

        private void btghi_Click(object sender, EventArgs e)
        {
            if (txtDiachi.Text.Length == 0 || txtMssv.Text.Length == 0 || dtns.Text.Length == 0 || txtSDT.Text.Length == 0 || txtHoten.Text.Length == 0 || txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            helper.XulySangToi(true, btnthem, btncapnhat, btnxoa, btghi);
            string mssv = txtMssv.Text, hoten = txtHoten.Text, ngay = dtns.Value.ToString("MM/dd/yyyy"), sdt = txtSDT.Text, nganh = cbnganh.SelectedValue.ToString(), email = txtEmail.Text, lop = cbLOP.SelectedValue.ToString(), diachi = txtDiachi.Text, htdt = cbhtdt.SelectedValue.ToString();
            string gt = cbbgt.SelectedItem.ToString();
            if (!helper.IsValidEmail(email))
            {
                MessageBox.Show("Định dạng email không đúng , vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtEmail.Focus();
                return;
            }
            string sql = $"select * from NguoiDung where email='{email}'";
            DataTable dt = LayDL(sql);
            if(dt.Rows.Count > 0 )
            {
                MessageBox.Show("Email Đã Tồn Tại Trong Hệ Thống!");
                helper.XulySangToi(false, btnthem, btncapnhat, btnxoa, btghi);
                return;
            }
            sql = $"select * from NguoiDung where SoDT='{sdt}'";
            dt = LayDL(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Số Điện Thoạiư Đã Tồn Tại Trong Hệ Thống!");
                helper.XulySangToi(false, btnthem, btncapnhat, btnxoa, btghi);
                return;
            }
            try
            {
                if (maND.Length != 0)
                {
                    string sql0 = $"insert into NguoiDung(MaNguoiDung,HoTen,NgaySinh,GioiTinh,SoDT,Email,DiaChi,MaQuyen) Values('{maND}','{hoten}','{ngay}','{gt}','{sdt}','{email}',N'{diachi}',4)";
                    sql = $"insert into SINHVIEN(MaSV, MaND,MaNganh,HinhThucDaoTao,MaLop) Values('{mssv}', '{maND}','{nganh}','{htdt}','{lop}');";
                    SqlCommand cd = new SqlCommand(sql0, cn);
                    cn.Open();
                    cd.ExecuteNonQuery();
                    cn.Close();

                    cd = new SqlCommand(sql, cn);
                    cn.Open();
                    cd.ExecuteNonQuery();
                    cn.Close();


                    MessageBox.Show("Lưu Thành Công!");
                    DataTable dt1 = LayDL("select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten  from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma");
                    hienthi(dt1);
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi DataBase" + ex.Message);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            /*string malop = cbloptimkiem.SelectedValue.ToString();
            string masv = txtmssvtimkiem.Text;
            string sql = "select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma and l.MaLop = '"+malop+"' and sv.MaSV = '"+masv+"'";
            DataTable dt = LayDL(sql);
            hienthi(dt);*/
            
        }
        


        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sv = txtMssv.Text.Trim();
            string hoten = txtHoten.Text.Trim();

            if (string.IsNullOrEmpty(sv) || string.IsNullOrEmpty(hoten))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận từ người dùng
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên {hoten} (Mã sv: {sv}) không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string sqltl = $"select truonglop from Lop";
                DataTable dttl = LayDL(sqltl);
          
                for (int i = 0; i < dttl.Rows.Count; i++)
                {
                    if (dttl.Rows[i][0].ToString().Equals(txtMssv.Text))
                    {
                        MessageBox.Show("Sinh viên này là Trưởng lớp");
                        return;
                    }
                }

                string sql = $"delete SINHVIEN where MaSV='{txtMssv.Text}';";
                string sql2 = $"select nd.MaNguoiDung  from NguoiDung nd, SINHVIEN sv where nd.MaNguoiDung = sv.MaND and sv.MaSV = '" + txtMssv.Text + "'";
                DataTable dtldl = LayDL(sql2);

                string sql3 = $"delete NguoiDung where MaNguoiDung='{dtldl.Rows[0][0].ToString()}';";

                SqlCommand cd = new SqlCommand(sql, cn);
                cn.Open();
                cd.ExecuteNonQuery();
                cn.Close();

                SqlCommand cd1 = new SqlCommand(sql3, cn);
                cn.Open();
                cd1.ExecuteNonQuery();
                cn.Close();

                DataTable dt1 = LayDL("select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten  from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma");
                hienthi(dt1);
                reset();
                MessageBox.Show("Xoa Thanh Cong");
                return;

            }
            catch (Exception ex) {
                MessageBox.Show("Loi Xoa " +ex.Message);
            }
            
        }

        private void cbloc_SelectedIndexChanged_1(object sender)
        {
            
        }

        private void cbloc_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void txtmssvtimkiem_TextChanged(object sender, EventArgs e)
        {
           string sql = $"select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma and nd.Hoten LIKE N'%{txttimkiem.Text}%'";
            DataTable dt = LayDL(sql);
            hienthi(dt);
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (txtDiachi.Text.Length == 0 || txtMssv.Text.Length == 0 || dtns.Text.Length == 0 || txtSDT.Text.Length == 0 || txtHoten.Text.Length == 0 || txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            string mssv = txtMssv.Text;
            string hoten = txtHoten.Text;
            string email = txtEmail.Text;
            string sdt = txtSDT.Text;
            string diachi = txtDiachi.Text;
            string nganh = cbnganh.SelectedValue.ToString();
            string lop = cbLOP.SelectedValue.ToString();
            string htdt = cbhtdt.SelectedValue.ToString();
            DateTime ngaysinh = dtns.Value;
            string gt = cbbgt.SelectedItem.ToString();
            if (!helper.IsValidEmail(email))
            {
                MessageBox.Show("Định dạng email không đúng , vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtEmail.Focus();
                return;
            }
            try
            { 
                string sqlNguoiDung = $@"UPDATE NguoiDung SET HoTen = '{hoten}', NgaySinh = '{ngaysinh.ToString("MM/dd/yyyy")}', GioiTinh = '{gt}', SoDT = '{sdt}', Email = '{email}', DiaChi = N'{diachi}' WHERE MaNguoiDung = (SELECT MaND FROM SINHVIEN WHERE MaSV = '{mssv}')";
                string sqlSinhVien = $@"UPDATE SINHVIEN SET MaNganh = '{nganh}', HinhThucDaoTao = '{htdt}', MaLop = '{lop}' WHERE MaSV = '{mssv}'";
                SqlCommand cmdNguoiDung = new SqlCommand(sqlNguoiDung, cn);
                cn.Open();
                cmdNguoiDung.ExecuteNonQuery();
                cn.Close();
                
                SqlCommand cmdSinhVien = new SqlCommand(sqlSinhVien, cn);
                cn.Open();
                cmdSinhVien.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Cập nhật thành công!");
                reset();
                DataTable dt = LayDL("select MaSV, HoTen, Email, SoDT, DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma");
                hienthi(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void listSV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

    /*private void cbbgt_SelectedIndexChanged(object sender, EventArgs e)
    {
        string malop = cbloc.SelectedValue.ToString();
        if (malop != "System.Data.DataRowView")
        {

            string sql = $"select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma and l.MaLop = '{malop}'";
            DataTable dt = LayDL(sql);
            hienthi(dt);
        }
    }*/
    
}
