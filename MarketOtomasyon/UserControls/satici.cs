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
    public partial class satici : UserControl
    {
        public satici()
        {
            InitializeComponent();
        }

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
    }
}
