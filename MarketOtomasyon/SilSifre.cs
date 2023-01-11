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
    public partial class SilSifre : Form
    {
        public SilSifre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt1.Text == "sil")
            {
                MessageBox.Show("Şifre doğru.");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
        }
    }
}
