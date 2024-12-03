using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R9
{
    public partial class QuanlyKH : Form
    {
        string scon = "Data Source=MSI;Initial Catalog=QLyNhaTro;Integrated Security=True";
        private int GetNewCustomerId()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(scon))
                {
                    conn.Open();

                    string query = "SELECT dbo.atNTP()"; // Gọi hàm atNTP() từ SQL Server
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        return (int)cmd.ExecuteScalar(); // Trả về giá trị ID mới
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return -1; // Trả về -1 nếu có lỗi
            }
        }
        private void AddCustomer(
        int roomId,
        string customerName,
        byte[] idCardImage,
        string phoneNumber,
        string accountName,
        string password,
        int accountType)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(scon))
                {
                    conn.Open();

                    // Gọi hàm atNTP() để lấy ID mới
                    int customerId = GetNewCustomerId();
                    if (customerId == -1) // Kiểm tra lỗi từ hàm GetNewCustomerId
                    {
                        MessageBox.Show("Không thể lấy ID mới.");
                        return;
                    }

                    // Sử dụng SqlCommand để gọi thủ tục
                    using (SqlCommand cmd = new SqlCommand("ThemNguoiThuePhong", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm tham số
                        cmd.Parameters.AddWithValue("@NTP_IDNguoithuephong", customerId);
                        cmd.Parameters.AddWithValue("@P_id", roomId);
                        cmd.Parameters.AddWithValue("@NTP_tenkhach", customerName);
                        cmd.Parameters.AddWithValue("@NTP_anhcancuoc", idCardImage);
                        cmd.Parameters.AddWithValue("@NTP_sodienthoai", phoneNumber);
                        cmd.Parameters.AddWithValue("@NTP_tentaikhoan", accountName);
                        cmd.Parameters.AddWithValue("@NTP_matkhau", password);
                        cmd.Parameters.AddWithValue("@NTP_loaitaikhoan", accountType);

                        // Thực thi thủ tục
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm người thuê phòng thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm người thuê phòng.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        public QuanlyKH()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void QuanlyKH_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(scon))
                {
                    string query = "EXEC LayNguoiThueChoChuTro";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    // Tạo một cột mới để hiển thị dữ liệu (có thể là văn bản hoặc hình ảnh)
                    dt.Columns.Add("CanCuoc", typeof(string)); // Sử dụng string để hiển thị văn bản

                    // Duyệt qua từng dòng trong DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["NTP_anhcancuoc"] != DBNull.Value)
                        {
                            // Lấy dữ liệu nhị phân từ cột NTP_anhcancuoc
                            byte[] imageBytes = (byte[])row["NTP_anhcancuoc"];

                            // Kiểm tra nếu dữ liệu là chuỗi văn bản
                            string textData = Encoding.ASCII.GetString(imageBytes); // Chuyển byte[] thành chuỗi văn bản

                            if (textData.StartsWith("placeholder")) // Kiểm tra nếu dữ liệu là văn bản
                            {
                                row["CanCuoc"] = textData; // Hiển thị văn bản thay vì ảnh
                            }
                            else
                            {
                                // Nếu dữ liệu là hình ảnh hợp lệ, bạn có thể chuyển đổi nó thành Image như bạn đã làm trước
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    try
                                    {
                                        row["CanCuoc"] = Image.FromStream(ms); // Chuyển byte[] thành Image
                                    }
                                    catch (ArgumentException)
                                    {
                                        row["CanCuoc"] = null; // Nếu không phải ảnh hợp lệ, gán null
                                    }
                                }
                            }
                        }
                        else
                        {
                            row["CanCuoc"] = null; // Gán null nếu không có dữ liệu
                        }
                    }

                    // Gán DataTable cho DataGridView
                    dgvKhachHang.DataSource = dt;
                    if (!dgvKhachHang.Columns.Contains("btnXoa"))
                    {
                        // Tạo cột button "Xóa" mới
                        DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                        btnColumn.HeaderText = "Xóa";
                        btnColumn.Name = "btnXoa";
                        btnColumn.Text = "Xóa";
                        btnColumn.UseColumnTextForButtonValue = true; // Để nút hiển thị chữ "Xóa"

                        // Thêm nút "Xóa" vào cuối DataGridView
                        dgvKhachHang.Columns.Add(btnColumn);
                        // Trong Form_Load hoặc Constructor
                        this.dgvKhachHang.CellContentClick += new DataGridViewCellEventHandler(dgvKhachHang_CellContentClick);
                    }
                        


                    // Ẩn cột nhị phân gốc (NTP_anhcancuoc)
                    dgvKhachHang.Columns["NTP_anhcancuoc"].Visible = false;

                    // Gán cột "CanCuoc" làm cột hiển thị
                    dgvKhachHang.Columns["CanCuoc"].HeaderText = "Hình Ảnh / Văn Bản";
                    dgvKhachHang.Columns["CanCuoc"].Width = 100; // Tùy chỉnh kích thước cột
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }
        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào cột nút "Xóa"
            if (e.ColumnIndex == dgvKhachHang.Columns["btnXoa"].Index && e.RowIndex >= 0)
            {
                // Lấy ID của khách hàng từ dòng hiện tại
                int customerId = Convert.ToInt32(dgvKhachHang.Rows[e.RowIndex].Cells["NTP_IDNguoithuephong"].Value);

                // Hỏi người dùng có chắc chắn muốn xóa không
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xóa Khách Hàng", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Xóa khách hàng từ cơ sở dữ liệu
                    DeleteCustomer(customerId);
                }
            }
        }

        private void DeleteCustomer(int customerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(scon))
                {
                    conn.Open();

                    string query = "DELETE FROM NguoiThuePhong WHERE NTP_IDNguoithuephong = @customerId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa khách hàng thành công!");
                            // Cập nhật lại DataGridView
                            QuanlyKH_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa khách hàng.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khách hàng: {ex.Message}");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy DataTable từ DataGridView
                DataTable dt = (DataTable)dgvKhachHang.DataSource;

                // Sử dụng DataView để lọc dữ liệu
                DataView dv = new DataView(dt);
                string sdt=sodienthoai.Text;
                dv.RowFilter = string.Format("NTP_sodienthoai LIKE '%{0}%'", sdt); // Lọc theo số điện thoại

                // Cập nhật lại DataGridView với dữ liệu đã lọc
                dgvKhachHang.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}");
            }
        }

        private void loaddata_Click(object sender, EventArgs e)
        {
            QuanlyKH_Load(sender,e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện
                int roomId = int.Parse(idPhong.Text);
                string customerName = tkh.Text;
                byte[] idCardImage = new byte[] { 0x00 }; // Đường dẫn ảnh
                string phoneNumber = sdt.Text;
                string accountName = ttk.Text;
                string password = mk.Text; // Mã hóa mật khẩu đã xử lý trong SQL
                int accountType = 1;

                // Gọi hàm thêm khách hàng
                AddCustomer(roomId, customerName, idCardImage, phoneNumber, accountName, password, accountType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
