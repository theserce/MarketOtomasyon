using Microsoft.Data.SqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MarketOtomasyon
{
    public partial class Form1 : Form
    {
        Thread th;
        int mov;
        int movX;
        int movY;
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void acForm(object obj)
        {
            Application.Run(new Form2());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici_adi, sifre;
            kullanici_adi= textBox1.Text;
            sifre= textBox2.Text;

            string querry = "SELECT * FROM SATICI WHERE KULLANICIADI = '" + textBox1.Text + "' AND SIFRE = '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(querry, con);

            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            if (textBox1.Text == "")
            {
                MessageBox.Show("Kullanýcý adýnýzý girin.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Þifrenizi girin.");
            }
            else if (dtable.Rows.Count > 0)
            {
                kullanici_adi = textBox1.Text;
                sifre = textBox2.Text;

                this.Close();
                th = new Thread(acForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Hatalý Giriþ!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}