namespace MarketOtomasyon
{
    public partial class Form1 : Form
    {
        int mov;
        int movX;
        int movY;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Kullanýcý adýnýzý girin.");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Þifrenizi girin.");
            }
            else if((textBox1.Text.Equals("admin")) && (textBox2.Text.Equals("1235")))
            {
                Form f2= new Form2();
                f2.Show();               
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