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

namespace MarketOtomasyon.UserControls
{
    public partial class veresiye : UserControl
    {
        public veresiye()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        SqlDataAdapter sda;
        DataTable dt;

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void veresiye_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"select * from VERESIYELER", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void kayitlari_getir()
        {
            string getir = "Select * From VERESIYELER";
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
                    string kaydet = "SET IDENTITY_INSERT VERESIYELER ON insert into VERESIYELER (VERESIYE_ID, MUSTERI_ID, [TOPLAM TUTAR]) values (@p1, @p2, @p3) SET IDENTITY_INSERT VERESIYELER OFF";
                    SqlCommand komut = new SqlCommand(kaydet, con);
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", textBox3.Text);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt Eklendi.");

                    kayitlari_getir();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox1.Focus();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata var!" + hata.Message);
            }


        }

        public void kayitlari_sil(int id)
        {
            string sil = "Delete From VERESIYELER Where VERESIYE_ID = @id";
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
                kayitlari_sil(id);
                MessageBox.Show("Kayıt Silindi.");
                kayitlari_getir();
            }

        }

        int i = 0;


        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            string komutguncelle = ("Update VERESIYELER Set MUSTERI_ID = '" + textBox2.Text + "', [TOPLAM TUTAR] = '" + textBox3.Text + "' Where VERESIYE_ID = '" + textBox1.Text + "'");
            SqlCommand komut = new SqlCommand(komutguncelle, con);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi.");
            kayitlari_getir();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili_alan = dataGridView1.SelectedCells[0].RowIndex;
            string veresiye_id = dataGridView1.Rows[secili_alan].Cells[0].Value.ToString();
            string musteri_id = dataGridView1.Rows[secili_alan].Cells[1].Value.ToString();
            string toplam_tutar = dataGridView1.Rows[secili_alan].Cells[2].Value.ToString();

            textBox1.Text = veresiye_id;
            textBox2.Text = musteri_id;
            textBox3.Text = toplam_tutar;

        }
    }
}
