using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace MarketOtomasyon.UserControls
{
    public partial class musteri : UserControl
    {
        public musteri()
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


        public void kayitlari_getir()
        {
            string getir = "Select * From MUSTERILER";

            SqlCommand komut = new SqlCommand(getir, con);

            SqlDataAdapter ad = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    string kaydet = "SET IDENTITY_INSERT MUSTERILER ON insert into MUSTERILER (MUSTERI_ID, ADI, SOYADI, TELEFON,  ODENEN_BORC) values (@p1, @p2, @p3 ,@p4,@p5) SET IDENTITY_INSERT MUSTERILER OFF";
                    SqlCommand komut = new SqlCommand(kaydet, con);

                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", textBox3.Text);
                    komut.Parameters.AddWithValue("@p4", textBox4.Text);
                    komut.Parameters.AddWithValue("@p5", textBox5.Text);

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
            string sil = "Delete From MUSTERILER Where MUSTERI_ID = @id";
            SqlCommand komut = new SqlCommand(sil, con);
            con.Open();


            komut.Parameters.AddWithValue("@id", id);

            komut.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                MessageBox.Show("Silme işlemi basarili");
                kayitlari_getir();
            }
        }

        private void musteri_Load_1(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"select * from MUSTERILER", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string komutguncelle = ("Update MUSTERILER Set ADI = '" + textBox2.Text + "', SOYADI = '" + textBox3.Text + "', TELEFON = '" + textBox4.Text + "', ODENEN_BORC = '" + textBox5.Text + "' Where MUSTERI_ID = '" + textBox1.Text + "'");
            SqlCommand komut = new SqlCommand(komutguncelle, con);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi.");

            kayitlari_getir();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili_alan = dataGridView1.SelectedCells[0].RowIndex;
            string aa = dataGridView1.Rows[secili_alan].Cells[0].Value.ToString();
            string bb = dataGridView1.Rows[secili_alan].Cells[1].Value.ToString();
            string cc = dataGridView1.Rows[secili_alan].Cells[2].Value.ToString();
            string dd = dataGridView1.Rows[secili_alan].Cells[3].Value.ToString();
            string ee = dataGridView1.Rows[secili_alan].Cells[4].Value.ToString();

            textBox1.Text = aa;
            textBox2.Text = bb;
            textBox3.Text = cc;
            textBox4.Text = dd;
            textBox5.Text = ee;
        }
    }
}
