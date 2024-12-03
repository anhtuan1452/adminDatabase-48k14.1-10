using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace R9
{
    public partial class ThemChuTro : Form
    {
        string sCon = "Data Source=MSI;Initial Catalog=QLyNhaTro;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public ThemChuTro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conected DB");
            }
            //buoc 2
            //chuan bi du lieu
            // kiem tra tinh hop le cua du lieu
            // lay du lieu ve;

            string machutro = txtmachutro.Text;
            string tenchutro = txttenchutro.Text;
            string sodienthoai = txtsodienthoai.Text;
            string tentaikhoan = txttentaikhoan.Text;
            string matkhau = txtmatkhau.Text;
            string sQuery = "insert into chutro values (@mact, @tenct, @sdt, @tentk, @mk)";
            SqlCommand sqlCommand = new SqlCommand(sQuery,con);
            sqlCommand.Parameters.AddWithValue("@mact",machutro);
            sqlCommand.Parameters.AddWithValue("@tenct", tenchutro);
            sqlCommand.Parameters.AddWithValue("@sdt", sodienthoai);
            sqlCommand.Parameters.AddWithValue("@tentk", tentaikhoan);
            sqlCommand.Parameters.AddWithValue("@mk", matkhau);
            try
            {
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Them thanh cong");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi kh them dc");
            }
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Xin Chào, hẹn gặp lại","Thông báo!!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Error conected DB");
            }
            //Step 2
            string sQuery = "select * from chutro";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery,con);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "Chutro");

            dataGridView1.DataSource = ds.Tables["Chutro"];
            con.Close(); //buoc 3

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtsodienthoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txttentaikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
