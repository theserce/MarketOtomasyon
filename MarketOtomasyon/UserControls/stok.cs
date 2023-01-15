using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace MarketOtomasyon.UserControls
{
    public partial class stok : UserControl
    {
        public stok()
        {
            InitializeComponent();
        }

        SqlDataAdapter sda;
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

        }

        private void stok_Load(object sender, EventArgs e)
        {
            // sda = new SqlDataAdapter(@"select * from STOKLAR", con);
            sda = new SqlDataAdapter(@"select STOKLAR.STOK_ID, STOKLAR.URUN_ID, STOKLAR.STOK_ADEDI, STOKLAR.TEDARIKCI_ID, STOKLAR.GIRIS_TARIHI, URUNLER.IRSALIYE_NO from STOKLAR INNER JOIN URUNLER ON STOKLAR.URUN_ID = URUNLER.URUN_ID ORDER BY STOK_ID; ", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void kayitlari_getir()
        {
            string getir = "select STOKLAR.STOK_ID, STOKLAR.URUN_ID, STOKLAR.STOK_ADEDI, STOKLAR.TEDARIKCI_ID, STOKLAR.GIRIS_TARIHI, URUNLER.IRSALIYE_NO from STOKLAR INNER JOIN URUNLER ON STOKLAR.URUN_ID = URUNLER.URUN_ID ORDER BY STOK_ID;";

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
                    string kaydet = "SET IDENTITY_INSERT STOKLAR ON insert into STOKLAR (STOK_ID,  URUN_ID, STOK_ADEDI, TEDARIKCI_ID, GIRIS_TARIHI) values (@p1, @p2, @p3 ,@p4,@p5) SET IDENTITY_INSERT STOKLAR OFF";
                    SqlCommand komut = new SqlCommand(kaydet, con);

                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", textBox3.Text);
                    komut.Parameters.AddWithValue("@p4", textBox4.Text);
                    komut.Parameters.AddWithValue("@p5", textBox5.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt ekleme basarili");

                    kayitlari_getir();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                  
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
            string sil = "Delete From STOKLAR Where STOK_ID = @id";
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

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string komutguncelle = ("Update STOKLAR Set URUN_ID = '" + textBox2.Text + "', STOK_ADEDI = '" + textBox3.Text + "', TEDARIKCI_ID = '" + textBox4.Text + "', GIRIS_TARIHI = '" + textBox5.Text + "' Where STOK_ID = '" + textBox1.Text + "'");
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

        private void button3_Click(object sender, EventArgs e)
        {
            //var fileContent = string.Empty;
            //var filePath = string.Empty;

            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.InitialDirectory = "c:\\";
            //    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //    openFileDialog.FilterIndex = 2;
            //    openFileDialog.RestoreDirectory = true;

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {

            //        filePath = openFileDialog.FileName;

            //        var fileStream = openFileDialog.OpenFile();

            //        using (StreamReader reader = new StreamReader(fileStream))
            //        {
            //            string line;
            //            while ((line = reader.ReadLine()) != null)
            //            {
            //                string[] items = line.Split(';');
            //                int myInteger = int.Parse(items[1]);

            //                string path = null;
            //                foreach (string item in items)
            //                {
            //                    if (item.StartsWith("item\\") && item.EndsWith(".ddj"))
            //                        path = item;
            //                }
            //            }
            //            fileContent = reader.ReadToEnd();
            //        }
            //    }
            //}

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);

            //----


            System.IO.StreamReader file = new System.IO.StreamReader("D:\\test.txt");
            string[] columnnames = file.ReadLine().Split(';');
            DataTable dt = new DataTable();
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(';');
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            file.Close();
            dataGridView1.DataSource = dt;
        }
    
    }
}
