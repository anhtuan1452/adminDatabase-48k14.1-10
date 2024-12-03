using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace R9
{
    public partial class Login : Form
    {
        string sCon = "Data Source=MSI;Initial Catalog=QLyNhaTro;Integrated Security=True";


        private bool KiemTraDangNhap(string username, string password, string role)
        {
             string query = "";
            if (role == "Chủ trọ")
            {
                query = "SELECT COUNT(*) FROM ChuTro WHERE CT_tentaikhoan = @Username AND CT_matkhau = @Password";
            }
            else if (role == "Người thuê phòng")
            {
                query = "SELECT COUNT(*) FROM NguoiThuePhong WHERE Username = @Username AND Password = @Password";
            }

            using (SqlConnection conn = new SqlConnection(sCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int result = (int)cmd.ExecuteScalar(); //
                    return result > 0; // Nếu kết quả > 0, tài khoản hợp lệ
                }
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();
            string role = radioButton1.Checked ? "Chủ trọ" : "Người thuê phòng";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValid = KiemTraDangNhap(username, password, role);
            if (isValid)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển đến form phù hợp
                if (role == "Chủ trọ")
                {
                    var chuTroForm = new Menu1(); // Form dành cho chủ trọ
                    chuTroForm.Show();
                }
                else
                {
                    return ;
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
