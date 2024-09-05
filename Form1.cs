using DemoWinformsBTL.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWinformsBTL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show($"Welcome Back", "Welcome !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void homeToolStrip_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.MdiParent = this;
            frm.ClientSize = new System.Drawing.Size(2000, 800);
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;

            if (!frm.IsOpened)
            {
                frm.Show();
            }
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nxbToolStrip_Click(object sender, EventArgs e)
        {
            FrmPublisher frm = new FrmPublisher();
            frm.MdiParent = this;
            frm.ClientSize = new System.Drawing.Size(2000, 800);
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (!frm.IsOpened)
            {
                frm.Show();
            }
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void readerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = $"Bây Giờ Là {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}," +
                $" ngày {DateTime.UtcNow.Day}/{DateTime.UtcNow.Month}/{DateTime.UtcNow.Year}"; 
        }

        
    }
}
