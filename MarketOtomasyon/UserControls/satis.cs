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
    public partial class satis : UserControl
    {
        public satis()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlDataAdapter sda;
        DataTable dt;
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

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void satis_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"select * from SATISLAR", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void kayitlari_getir()
        {
            string getir = "Select * From SATISLAR";
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
                    string kaydet = "SET IDENTITY_INSERT SATISLAR ON insert into SATISLAR (SATIS_ID, SATIS_TURU, MUSTERI_ID) values (@p1, @p2, @p3) SET IDENTITY_INSERT SATISLAR OFF";
                    SqlCommand komut = new SqlCommand(kaydet, con);
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", textBox3.Text);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt Eklendi.");

                    kayitlari_getir();
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show("Bir hata var!" + hata.Message);    
            }
        }

        public void kayitlari_sil(int id)
        {
            string sil = "Delete From SATISLAR Where SATIS_ID = @id";
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
                    SilSifre frm = new SilSifre();
                    frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    int id = Convert.ToInt32(drow.Cells[0].Value);
                    kayitlari_sil(id);
                    MessageBox.Show("Kayıt Silindi.");
                    kayitlari_getir();
                }
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            string komutguncelle = ("Update SATISLAR Set SATIS_TURU = '"+textBox2.Text+"', MUSTERI_ID = '"+textBox3.Text+"' Where SATIS_ID = '"+textBox1.Text+"'");
            SqlCommand komut = new SqlCommand(komutguncelle, con);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi.");
            kayitlari_getir();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili_alan = dataGridView1.SelectedCells[0].RowIndex;
            string satıs_id = dataGridView1.Rows[secili_alan].Cells[0].Value.ToString();
            string satis_turu = dataGridView1.Rows[secili_alan].Cells[8].Value.ToString();
            string musteri_id = dataGridView1.Rows[secili_alan].Cells[1].Value.ToString();

            textBox1.Text = satıs_id;
            textBox2.Text = satis_turu;
            textBox3.Text = musteri_id;

        }
    }
}
