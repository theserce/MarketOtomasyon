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
    public partial class satici : UserControl
    {
        public satici()
        {
            InitializeComponent();
        }

        SqlDataAdapter sda;
        DataTable dt;
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

        private void satici_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"select * from SATICI", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void kayitlari_getir()
        {
            string getir = "Select * From SATICI";

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
                    string kaydet = "SET IDENTITY_INSERT SATICI ON insert into SATICI ([SATICI_ID], KULLANICIADI, SIFRE, UNVAN) values (@p1, @p2, @p3 ,@p4) SET IDENTITY_INSERT SATICI OFF";
                    SqlCommand komut = new SqlCommand(kaydet, con);

                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", textBox3.Text);
                    komut.Parameters.AddWithValue("@p4", textBox4.Text);

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
            string sil = "Delete From SATICI Where [SATICI_ID] = @id";
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
            con.Open();
            string komutguncelle = ("Update SATICI Set KULLANICIADI = '" + textBox2.Text + "', SIFRE = '" + textBox3.Text + "', UNVAN = '" + textBox4.Text + "' Where [SATICI_ID] = '" + textBox1.Text + "'");
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

            textBox1.Text = aa;
            textBox2.Text = bb;
            textBox3.Text = cc;
            textBox4.Text = dd;

        }
    }
}
