using Microsoft.Data.SqlClient;
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

namespace MarketOtomasyon.UserControls
{
    public partial class rapor : UserControl
    {
        public rapor()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        SqlDataAdapter sda; 
        DataTable dt;


        private void rapor_Load(object sender, EventArgs e)
        {
             sda = new SqlDataAdapter(@"select URUN_ADI, count(*) AS 'SAYI' FROM URUNLER GROUP BY URUN_ADI order by COUNT(*) desc", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
