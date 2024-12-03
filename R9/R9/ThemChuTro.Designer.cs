namespace R9
{
    partial class ThemChuTro
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
            this.label1 = new System.Windows.Forms.Label();
            this.txttenchutro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dangky = new System.Windows.Forms.Button();
            this.txttentaikhoan = new System.Windows.Forms.TextBox();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.huydangky = new System.Windows.Forms.Button();
            this.txtsodienthoai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtmachutro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Chủ Trọ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txttenchutro
            // 
            this.txttenchutro.Location = new System.Drawing.Point(327, 42);
            this.txttenchutro.Name = "txttenchutro";
            this.txttenchutro.Size = new System.Drawing.Size(187, 22);
            this.txttenchutro.TabIndex = 1;
            this.txttenchutro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên tài khoản";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật Khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dangky
            // 
            this.dangky.Location = new System.Drawing.Point(327, 180);
            this.dangky.Name = "dangky";
            this.dangky.Size = new System.Drawing.Size(75, 23);
            this.dangky.TabIndex = 5;
            this.dangky.Text = "Đăng Ký";
            this.dangky.UseVisualStyleBackColor = true;
            this.dangky.Click += new System.EventHandler(this.button1_Click);
            // 
            // txttentaikhoan
            // 
            this.txttentaikhoan.Location = new System.Drawing.Point(327, 102);
            this.txttentaikhoan.Name = "txttentaikhoan";
            this.txttentaikhoan.Size = new System.Drawing.Size(187, 22);
            this.txttentaikhoan.TabIndex = 3;
            this.txttentaikhoan.TextChanged += new System.EventHandler(this.txttentaikhoan_TextChanged);
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(327, 130);
            this.txtmatkhau.Multiline = true;
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Size = new System.Drawing.Size(187, 22);
            this.txtmatkhau.TabIndex = 4;
            this.txtmatkhau.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // huydangky
            // 
            this.huydangky.Location = new System.Drawing.Point(439, 180);
            this.huydangky.Name = "huydangky";
            this.huydangky.Size = new System.Drawing.Size(75, 23);
            this.huydangky.TabIndex = 6;
            this.huydangky.Text = "Hủy";
            this.huydangky.UseVisualStyleBackColor = true;
            // 
            // txtsodienthoai
            // 
            this.txtsodienthoai.Location = new System.Drawing.Point(327, 70);
            this.txtsodienthoai.Name = "txtsodienthoai";
            this.txtsodienthoai.Size = new System.Drawing.Size(187, 22);
            this.txtsodienthoai.TabIndex = 2;
            this.txtsodienthoai.TextChanged += new System.EventHandler(this.txtsodienthoai_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số điện thoại";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(734, 202);
            this.dataGridView1.TabIndex = 10;
            // 
            // txtmachutro
            // 
            this.txtmachutro.Location = new System.Drawing.Point(327, 14);
            this.txtmachutro.Name = "txtmachutro";
            this.txtmachutro.Size = new System.Drawing.Size(187, 22);
            this.txtmachutro.TabIndex = 12;
            this.txtmachutro.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mã Chủ Trọ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ThemChuTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtmachutro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtsodienthoai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.huydangky);
            this.Controls.Add(this.txtmatkhau);
            this.Controls.Add(this.txttentaikhoan);
            this.Controls.Add(this.dangky);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttenchutro);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Crimson;
            this.Name = "ThemChuTro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Chủ Trọ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttenchutro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button dangky;
        private System.Windows.Forms.TextBox txttentaikhoan;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.Button huydangky;
        private System.Windows.Forms.TextBox txtsodienthoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtmachutro;
        private System.Windows.Forms.Label label5;
    }
}

