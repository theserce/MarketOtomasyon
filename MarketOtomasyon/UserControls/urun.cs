using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace MarketOtomasyon.UserControls
{
    public partial class urun : UserControl
    {
        public urun()
        {
            InitializeComponent();
        }

        SqlDataAdapter sda; 
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

        }

        private void urun_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"select * from URUNLER", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void kayitlari_getir()
        { 
            string getir = "Select * From URUNLER";

            SqlCommand komut = new SqlCommand(getir,con);

            SqlDataAdapter ad = new SqlDataAdapter(komut);

            DataTable dt = new DataTable(); 
            ad.Fill(dt);
            dataGridView1.DataSource= dt;

            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    string kaydet = "SET IDENTITY_INSERT URUNLER ON insert into URUNLER (URUN_ID, URUN_KODU, URUN_ADI, IRSALIYE_NO,  BIRIM_GIRDI_FIYATI, SATIS_FIYATI, STOK, STOK_ESIK ) values (@p1, @p2, @p3 ,@p4,@p6,@p7,@p8,@p9) SET IDENTITY_INSERT URUNLER OFF";
                    SqlCommand komut = new SqlCommand(kaydet, con);

                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", textBox3.Text);
                    komut.Parameters.AddWithValue("@p4", textBox4.Text);
                  
                    komut.Parameters.AddWithValue("@p6", textBox6.Text);
                    komut.Parameters.AddWithValue("@p7", textBox7.Text);
                    komut.Parameters.AddWithValue("@p8", textBox8.Text);
                    komut.Parameters.AddWithValue("@p9", textBox9.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt ekleme basarili");

                    kayitlari_getir();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox1.Focus();


                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata var" + hata.Message);
            }
         }

        public void verisil(int id)
        {
            string sil = "Delete From URUNLER Where URUN_ID = @id";
            SqlCommand komut = new SqlCommand(sil, con);
            con.Open();

           
            komut.Parameters.AddWithValue("@id", id);
            
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                MessageBox.Show("Silme işlemi basarili");
                kayitlari_getir();
            }
        }

        int i = 0;
        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            string komutguncelle = ("Update URUNLER Set URUN_KODU = '" + textBox2.Text + "', URUN_ADI = '" + textBox3.Text + "', BIRIM_GIRDI_FIYATI = '" + textBox6.Text + "', SATIS_FIYATI = '" + textBox7.Text + "', STOK = '" + textBox8.Text + "', STOK_ESIK = '" + textBox9.Text + "' Where URUN_ID = '" + textBox1.Text + "'");
            SqlCommand komut = new SqlCommand(komutguncelle, con);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi.");
            con.Close() ;
            kayitlari_getir();

            



            // con.Open();
            // string kayitguncelle = ("Update URUNLER Set  URUN_KODU = @ukodu, URUN_ADI = @uadi, IRSALIYE_NO = @ino, BIRIM_GIRDI_FIYATI = @bgf, SATIS_FIYATI = @sfiyati, STOK = @stok, STOK_ESIK =@sesik Where  URUN_ID = @id");

            // SqlCommand komut = new SqlCommand(kayitguncelle, con);

            // //komut.Parameters.AddWithValue("@id", textBox1.Text);
            // komut.Parameters.AddWithValue("@ukodu", textBox2.Text);
            // komut.Parameters.AddWithValue("@uadi", textBox3.Text);
            // komut.Parameters.AddWithValue("@ino", textBox4.Text);
            //// komut.Parameters.AddWithValue("@bno", textBox5.Text);
            // komut.Parameters.AddWithValue("@bgf", textBox6.Text);
            // komut.Parameters.AddWithValue("@sfiyati", textBox7.Text);
            // komut.Parameters.AddWithValue("@stok", textBox8.Text);
            // komut.Parameters.AddWithValue("@sesik", textBox9.Text);
            // komut.Parameters.AddWithValue("@id",dataGridView1.Rows[i].Cells[0].Value);

            // komut.ExecuteNonQuery();
            // MessageBox.Show("Kayitlar Basariyla  Guncellendi.");
            // con.Close();
            // kayitlari_getir();
        }


  
       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili_alan = dataGridView1.SelectedCells[0].RowIndex;
            string urun_id = dataGridView1.Rows[secili_alan].Cells[0].Value.ToString();
            string urun_kodu = dataGridView1.Rows[secili_alan].Cells[1].Value.ToString();
            string urun_adi = dataGridView1.Rows[secili_alan].Cells[2].Value.ToString();
           // string irsaliye_no = dataGridView1.Rows[secili_alan].Cells[3].Value.ToString();
            string birim_girdi_fiyati = dataGridView1.Rows[secili_alan].Cells[5].Value.ToString();
            string satis_fiyati = dataGridView1.Rows[secili_alan].Cells[6].Value.ToString();
            string stok1 = dataGridView1.Rows[secili_alan].Cells[7].Value.ToString();
             string stok_esik = dataGridView1.Rows[secili_alan].Cells[8].Value.ToString();

            textBox1.Text = urun_id;
            textBox2.Text = urun_kodu;
            textBox3.Text = urun_adi;
            //textBox4.Text = irsaliye_no;
            textBox6.Text = birim_girdi_fiyati;
            textBox7.Text = satis_fiyati;
            textBox8.Text = stok1;
            textBox9.Text = stok_esik;
        }
    }
}
