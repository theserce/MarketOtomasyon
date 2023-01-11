namespace MarketOtomasyon
{
    partial class SilSifre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt1 = new System.Windows.Forms.TextBox();
            this.lblsifre = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(138, 69);
            this.txt1.Name = "txt1";
            this.txt1.PasswordChar = '*';
            this.txt1.Size = new System.Drawing.Size(125, 27);
            this.txt1.TabIndex = 0;
            // 
            // lblsifre
            // 
            this.lblsifre.AutoSize = true;
            this.lblsifre.Location = new System.Drawing.Point(178, 37);
            this.lblsifre.Name = "lblsifre";
            this.lblsifre.Size = new System.Drawing.Size(39, 20);
            this.lblsifre.TabIndex = 1;
            this.lblsifre.Text = "Şifre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tamam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SilSifre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 159);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblsifre);
            this.Controls.Add(this.txt1);
            this.Name = "SilSifre";
            this.Text = "SilSifre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txt1;
        private Label lblsifre;
        private Button button1;
    }
}