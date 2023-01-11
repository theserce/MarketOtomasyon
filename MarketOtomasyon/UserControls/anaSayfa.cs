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
    public partial class anaSayfa : UserControl
    {
        SqlDataAdapter sda;
        DataTable dt, dt2, dt3, dt4;
        public anaSayfa()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void anaSayfa_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"select URUN_ADI, count(*) AS 'SAYI' FROM URUNLER GROUP BY URUN_ADI", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sda = new SqlDataAdapter(@"select (sum(SATIS_DETAY.SATIS_FIYATI * SATIS_DETAY.ADET)) - (SUM(BIRIM_GIRDI_FIYATI* STOK)) as 'kar' from URUNLER inner join SATIS_DETAY on URUNLER.URUN_ID = SATIS_DETAY.URUN_ID", con);
            dt2 = new DataTable();
            sda.Fill(dt2);
            dataGridView2.DataSource = dt2;
            sda = new SqlDataAdapter(@"select URUN_ADI, STOK from URUNLER where STOK < STOK_ESIK", con);
            dt3 = new DataTable();
            sda.Fill(dt3);
            dataGridView3.DataSource = dt3;
            sda = new SqlDataAdapter(@"select URUN_ADI, COUNT(ADET) from SATIS_DETAY group by URUN_ADI order by COUNT(ADET) desc", con);
            dt4 = new DataTable();
            sda.Fill(dt4);
            dataGridView4.DataSource = dt4;
        }
    }
}
