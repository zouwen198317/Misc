using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;



namespace textrender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile(@"c:\Nafees Nastaleeq(Updated).ttf");
            //FontFamily family = new FontFamily("Nafees Nastaleeq", pfc);
            //Font font = new Font(family, 14);
            Font font = new Font("Verdana", 14);
            //Font font = new Font(FontFamily.GenericMonospace, 72)
            string str = System.IO.File.ReadAllText("c:\\program files\\shsoft\\uc\\uniquran\\1-big ending.txt");
            //g.DrawString("میرا", font, Brushes.Red, new PointF(0f, 0f));
            g.DrawString(str, font, Brushes.Red, new PointF(0f, 0f));
            pictureBox1.Image = bmp;

            //textBox1.Text = System.IO.File.ReadAllText("c:\\program files\\shsoft\\uc\\uniquran\\1-big ending.txt");

        }
    }
}