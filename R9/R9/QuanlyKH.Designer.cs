namespace R9
{
    partial class QuanlyKH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.sodienthoai = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.loaddata = new System.Windows.Forms.Button();
            this.idPhong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ttk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sdt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mk = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.acc = new System.Windows.Forms.TextBox();
            this.btThemNTP = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tkh = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Location = new System.Drawing.Point(28, 193);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.RowTemplate.Height = 24;
            this.dgvKhachHang.Size = new System.Drawing.Size(751, 223);
            this.dgvKhachHang.TabIndex = 0;
            this.dgvKhachHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // sodienthoai
            // 
            this.sodienthoai.Location = new System.Drawing.Point(553, 165);
            this.sodienthoai.Name = "sodienthoai";
            this.sodienthoai.Size = new System.Drawing.Size(119, 22);
            this.sodienthoai.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập số điện thoại muốn tìm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(698, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tìm Kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loaddata
            // 
            this.loaddata.Location = new System.Drawing.Point(657, 422);
            this.loaddata.Name = "loaddata";
            this.loaddata.Size = new System.Drawing.Size(122, 23);
            this.loaddata.TabIndex = 4;
            this.loaddata.Text = "Tải Dữ Liệu";
            this.loaddata.UseVisualStyleBackColor = true;
            this.loaddata.Click += new System.EventHandler(this.loaddata_Click);
            // 
            // idPhong
            // 
            this.idPhong.Location = new System.Drawing.Point(16, 52);
            this.idPhong.Name = "idPhong";
            this.idPhong.Size = new System.Drawing.Size(105, 22);
            this.idPhong.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "THÊM NGƯỜI THUÊ PHÒNG";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mã Phòng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tên Tài Khoản:";
            // 
            // ttk
            // 
            this.ttk.Location = new System.Drawing.Point(359, 52);
            this.ttk.Name = "ttk";
            this.ttk.Size = new System.Drawing.Size(106, 22);
            this.ttk.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số Điện Thoại:";
            // 
            // sdt
            // 
            this.sdt.Location = new System.Drawing.Point(247, 52);
            this.sdt.Name = "sdt";
            this.sdt.Size = new System.Drawing.Size(106, 22);
            this.sdt.TabIndex = 10;
            this.sdt.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mật Khẩu:";
            // 
            // mk
            // 
            this.mk.Location = new System.Drawing.Point(471, 52);
            this.mk.Name = "mk";
            this.mk.Size = new System.Drawing.Size(96, 22);
            this.mk.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(573, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ảnh Căn Cước:";
            // 
            // acc
            // 
            this.acc.Location = new System.Drawing.Point(573, 52);
            this.acc.Name = "acc";
            this.acc.Size = new System.Drawing.Size(103, 22);
            this.acc.TabIndex = 14;
            // 
            // btThemNTP
            // 
            this.btThemNTP.Location = new System.Drawing.Point(701, 51);
            this.btThemNTP.Name = "btThemNTP";
            this.btThemNTP.Size = new System.Drawing.Size(75, 23);
            this.btThemNTP.TabIndex = 16;
            this.btThemNTP.Text = "Thêm";
            this.btThemNTP.UseVisualStyleBackColor = true;
            this.btThemNTP.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Tên Người Thuê:";
            // 
            // tkh
            // 
            this.tkh.Location = new System.Drawing.Point(136, 52);
            this.tkh.Name = "tkh";
            this.tkh.Size = new System.Drawing.Size(105, 22);
            this.tkh.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(136, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Tên Người Thuê:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 22);
            this.textBox1.TabIndex = 31;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(701, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(573, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "Ảnh Căn Cước:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(573, 129);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(103, 22);
            this.textBox2.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(471, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Mật Khẩu:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(471, 129);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(96, 22);
            this.textBox3.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(247, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "Số Điện Thoại:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(247, 129);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(106, 22);
            this.textBox4.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(359, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "Tên Tài Khoản:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(359, 129);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(106, 22);
            this.textBox5.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "Mã Phòng:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(174, 16);
            this.label15.TabIndex = 20;
            this.label15.Text = "SỬA NGƯỜI THUÊ PHÒNG";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(16, 129);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(105, 22);
            this.textBox6.TabIndex = 19;
            // 
            // QuanlyKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tkh);
            this.Controls.Add(this.btThemNTP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.acc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sdt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ttk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idPhong);
            this.Controls.Add(this.loaddata);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sodienthoai);
            this.Controls.Add(this.dgvKhachHang);
            this.Name = "QuanlyKH";
            this.Text = "QuanlyKH";
            this.Load += new System.EventHandler(this.QuanlyKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.TextBox sodienthoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button loaddata;
        private System.Windows.Forms.TextBox idPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ttk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sdt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox acc;
        private System.Windows.Forms.Button btThemNTP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tkh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox6;
    }
}