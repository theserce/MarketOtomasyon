using Microsoft.Data.SqlClient;
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
    public partial class veresiyeOdeme : Form
    {
        public veresiyeOdeme()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    int sayi = Convert.ToInt32(textBox3.Text);
                    int toplam_tutar = Convert.ToInt32("Select [TOPLAM TUTAR] from VERESIYELER where VERESIYE_ID = '" + textBox1.Text + "'");
                    int odeme = Convert.ToInt32(toplam_tutar - sayi);
                    string komutguncelle = ("Update VERESIYELER Set [TOPLAM TUTAR] = '" + odeme + "' Where VERESIYE_ID = '" + textBox1.Text + "'");
                    SqlCommand komut = new SqlCommand(komutguncelle, con);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ödeme yapıldı.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata var: " + hata.Message);
            }
        }
    }
}
