using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R9
{
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýPhòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sửaNgườiThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xóaNgườiThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void xóaChủTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýNgườiThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var QLyKH = new QuanlyKH(); // Form dành cho chủ trọ
            QLyKH.Show();
        }
    }
}
