using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traetory
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Point[] p;
        private int V;
        private double Angle;
        private int g = 10;
        private double MaxL;
        private double MaxH;
        private double x, y;
        private double T;


        public Form1()
        {
            InitializeComponent();
            label1.Text = "V";
            label2.Text = "Angle";
            Height = 800;
            button3.Location = new Point(label3.Location.X + 100,label3.Location.Y);
            pictureBox1.Location = new Point(0, Height - 10);
            pictureBox1.Size = new Size(Width, 5);
            pictureBox2.Location = new Point(0, pictureBox1.Location.Y - pictureBox2.Height);
            label3.Text = "";
            label4.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";

            graphics = this.CreateGraphics();
            graphics.TranslateTransform(0, pictureBox2.Location.Y);


            try
            {
                V = int.Parse(textBox1.Text);
                Angle = int.Parse(textBox2.Text);
                Angle = (Angle * Math.PI) / 180;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            if (textBox2.Text == "90")
            {
                MaxH = ((V * V * Math.Sin(Angle) * Math.Sin(Angle)) / (2 * g));
                graphics.DrawLine(new Pen(Color.Black), 20, pictureBox1.Location.Y, 20, -(float)MaxH);
                pictureBox2.Location = new Point(20,pictureBox1.Location.Y);
                pictureBox2.Location = new Point(20, -(int)MaxH);

            }
            else
            {
                MaxL = ((V * V * Math.Sin(2 * Angle)) / g);
                MaxH = ((V * V * Math.Sin(Angle) * Math.Sin(Angle)) / (2 * g));

                Point[] p = new Point[(int)MaxL];


                for (int i = 0; i < p.Length; i++)
                {
                    x = i;
                    y = MaxH + x * Math.Tan(Angle) - ((g * x * x) / (2 * V * V * Math.Cos(Angle) * Math.Cos(Angle)));
                    p[i] = new Point((int)x, -(int)y - p[0].Y + 10);
                }

                graphics.DrawLines(new Pen(Color.Black), p);

                for (int i = 0; i < p.Length; i++)
                {
                    pictureBox2.Location = new Point(p[i].X + 2, pictureBox1.Location.Y + p[i].Y - 50);
                    label3.Text = $"X : {pictureBox2.Location.X}";
                    label4.Text = $"Y : {pictureBox2.Location.Y}";
                }
                graphics.Clear(this.BackColor);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Size = new Size(this.Width, 5);
        }
    }
}
