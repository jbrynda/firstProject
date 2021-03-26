using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kulecnik2._0
{
    public partial class Form1 : Form
    {
        private static List<Ball> Balls = new List<Ball>();
        public Brush brush;
        public Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            this.UpdateStyles();
        }

        private void PaintBall(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            Graphics graphics = e.Graphics;
            DrawBall(graphics);
        }
        private void MoveBall(object sender, EventArgs e)
        {
            foreach (Ball kulicka in Balls)
            {
                if(kulicka.randomMove == 0)
                {
                    kulicka.Pohyb(this.ClientSize.Width, this.ClientSize.Height);
                } else if(kulicka.randomMove == 1)
                {
                    kulicka.PohybX(this.ClientSize.Width);
                } else
                {
                    kulicka.PohybY(this.ClientSize.Height);
                }
            }

            this.Refresh();
        }

        public void DrawBall(Graphics graphics)
        {
            foreach (Ball kulicka in Balls)
            {
                brush = new SolidBrush(kulicka.ballColor);
                graphics.FillEllipse(brush, kulicka.ballPosX, kulicka.ballPosY, kulicka.ballWidth, kulicka.ballHeight);
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                int randomPosition = rnd.Next(0, 500);
                int randomSize = rnd.Next(0, 100);
                Ball kulicka = new Ball(20+randomSize, 20+randomSize, 0+randomPosition, 0+randomPosition);
                kulicka.randomMove = rnd.Next(0, 3);
                kulicka.ballColor = kulicka.DefineColor();
                Balls.Add(kulicka);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Programování\\csharp\\Kulecnik2.0\\index.html");
        }
        private void blueToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            foreach (Ball kulicka in Balls)
            {
                kulicka.ballColor = Color.Blue;
                brush = new SolidBrush(kulicka.ballColor);
                graphics.FillEllipse(brush, kulicka.ballPosX, kulicka.ballPosY, kulicka.ballWidth, kulicka.ballHeight);
            }
        }

        private void blackToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            foreach (Ball kulicka in Balls)
            {
                kulicka.ballColor = Color.Black;
                brush = new SolidBrush(kulicka.ballColor);
                graphics.FillEllipse(brush, kulicka.ballPosX, kulicka.ballPosY, kulicka.ballWidth, kulicka.ballHeight);
            }
        }

        private void redToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            
            foreach (Ball kulicka in Balls)
            {
                kulicka.ballColor = Color.Red;
                brush = new SolidBrush(kulicka.ballColor);
                graphics.FillEllipse(brush, kulicka.ballPosX, kulicka.ballPosY, kulicka.ballWidth, kulicka.ballHeight);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void quickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 10;
        }
    }
}
