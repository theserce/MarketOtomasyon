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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace MarketOtomasyon.UserControls
{
    public partial class borc : UserControl
    {
        public borc()
        {
            InitializeComponent();
        }

        SqlDataAdapter sda;
        DataTable dt,dt2;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void kaydetBtn_MouseEnter(object sender, EventArgs e)
        {
            kaydetBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void silBtn_MouseEnter(object sender, EventArgs e)
        {
            silBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void guncelleBtn_MouseEnter(object sender, EventArgs e)
        {
            guncelleBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void kaydetBtn_MouseLeave(object sender, EventArgs e)
        {
            kaydetBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void silBtn_MouseLeave(object sender, EventArgs e)
        {
            silBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void guncelleBtn_MouseLeave(object sender, EventArgs e)
        {
            guncelleBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void borc_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"select * from BORCLAR", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            sda = new SqlDataAdapter(@"select sum(TOPLAM_TUTAR) as 'TOPLAM BORC' from BORCLAR ", con);
            dt2 = new DataTable();
            sda.Fill(dt2);
            dataGridView2.DataSource = dt2;

        }

        public void kayitlari_getir()
        {
            string getir = "Select * From BORCLAR";

            SqlCommand komut = new SqlCommand(getir, con);

            SqlDataAdapter ad = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void kaydetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    string kaydet = "SET IDENTITY_INSERT BORCLAR ON insert into BORCLAR (BORC_ID ) values (@p1) SET IDENTITY_INSERT BORCLAR OFF";
                    SqlCommand komut = new SqlCommand(kaydet, con);

                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt ekleme basarili");

                    kayitlari_getir();

                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata var" + hata.Message);
            }
        }

        public void verisil(int id)
        {
            string sil = "Delete From BORCLAR Where BORC_ID = @id";
            SqlCommand komut = new SqlCommand(sil, con);
            con.Open();


            komut.Parameters.AddWithValue("@id", id);

            komut.ExecuteNonQuery();
            con.Close();
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                MessageBox.Show("Silme işlemi basarili");
                kayitlari_getir();
            }
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
        //    con.Open();
        //    string komutguncelle = ("Update STOKLAR Set URUN_ID = '" + textBox2.Text + "', STOK_ADEDI = '" + textBox3.Text + "', TEDARIKCI_ID = '" + textBox4.Text + "', GIRIS_TARIHI = '" + textBox5.Text + "' Where STOK_ID = '" + textBox1.Text + "'");
        //    SqlCommand komut = new SqlCommand(komutguncelle, con);
        //    komut.ExecuteNonQuery();
        //    MessageBox.Show("Kayıt Güncellendi.");

        //    kayitlari_getir();
        }
    }
}
