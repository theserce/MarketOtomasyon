using MarketOtomasyon.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketOtomasyon
{
    public partial class Form2 : Form
    {
        int mov;
        int movX;
        int movY;
        public Form2()
        {
            InitializeComponent();
            anaSayfa ana = new anaSayfa();
            addUserControl(ana);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            anaSayfa ana = new anaSayfa();
            addUserControl(ana);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            satis ana = new satis();
            addUserControl(ana);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            urun ana = new urun();
            addUserControl(ana);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stok ana = new stok();
            addUserControl(ana);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            musteri ana = new musteri();
            addUserControl(ana);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tedarikci ana = new tedarikci();
            addUserControl(ana);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            satici ana = new satici();
            addUserControl(ana);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            borc ana = new borc();
            addUserControl(ana);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            odeme ana = new odeme();
            addUserControl(ana);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            veresiye ana = new veresiye();
            addUserControl(ana);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            rapor ana = new rapor();
            addUserControl(ana);
        }
    }
}
