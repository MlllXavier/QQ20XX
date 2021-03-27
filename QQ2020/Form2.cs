using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QQ2020
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 240, 240, 240);
            lblSearch.ForeColor = Color.FromArgb(200, 230, 255);

            Bitmap bmp = new Bitmap(QQ2020.Properties.Resources.lilin);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int x = Math.Abs(i - bmp.Width / 2);
                    int y = Math.Abs(j - bmp.Height / 2);
                    if ((x * x + y * y) > bmp.Width * bmp.Width/4)
                    {
                        bmp.SetPixel(i, j, Color.Transparent);
                    }
                }
            }
            userControl15.ImgUser = bmp;

            Bitmap bmp2 = new Bitmap(QQ2020.Properties.Resources.quntouxiang);
            for (int i = 0; i < bmp2.Width; i++)
            {
                for (int j = 0; j < bmp2.Height; j++)
                {
                    int x = Math.Abs(i - bmp2.Width / 2);
                    int y = Math.Abs(j - bmp2.Height / 2);
                    if ((x * x + y * y) > bmp2.Width * bmp2.Width / 4)
                    {
                        bmp2.SetPixel(i, j, Color.Transparent);
                    }
                }
            }
            userControl14.ImgUser = bmp2;

            Bitmap bmp3 = new Bitmap(QQ2020.Properties.Resources.yezhulin);
            for (int i = 0; i < bmp3.Width; i++)
            {
                for (int j = 0; j < bmp3.Height; j++)
                {
                    int x = Math.Abs(i - bmp3.Width / 2);
                    int y = Math.Abs(j - bmp3.Height / 2);
                    if ((x * x + y * y) > bmp3.Width * bmp3.Width / 4)
                    {
                        bmp3.SetPixel(i, j, Color.Transparent);
                    }
                }
            }
            userControl18.ImgUser = bmp3;

            Bitmap bmp4 = new Bitmap(QQ2020.Properties.Resources.mytouxiang);
            for (int i = 0; i < bmp4.Width; i++)
            {
                for (int j = 0; j < bmp4.Height; j++)
                {
                    int x = Math.Abs(i - bmp4.Width / 2);
                    int y = Math.Abs(j - bmp4.Height / 2);
                    if ((x * x + y * y) > bmp4.Width * bmp4.Width / 4)
                    {
                        bmp4.SetPixel(i, j, Color.Transparent);
                    }
                }
            }
            pictureBox1.Image = bmp4;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0, 0, 277, 697);
            LinearGradientBrush lgb = new LinearGradientBrush(rec, Color.FromArgb(18, 185, 255), Color.FromArgb(180, 32, 255), LinearGradientMode.Horizontal);
            g.FillRectangle(lgb, rec);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Form3 f3 = new Form3();
        private void picWeather_MouseEnter(object sender, EventArgs e)
        {
            f3.Show();
            f3.Location = new Point(this.Location.X + this.Width + 5, this.Location.Y);
        }

        private void picWeather_MouseLeave(object sender, EventArgs e)
        {
            f3.Hide();
        }

        private void userControl11_MouseEnter(object sender, EventArgs e)
        {
            userControl11.BackColor = Color.FromArgb(12, 0, 0, 0);
        }

        private void userControl11_MouseLeave(object sender, EventArgs e)
        {
            userControl11.BackColor = Color.Transparent;
        }

        Point down;
        bool isdown;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            down = e.Location;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                isdown = true;
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                isdown = false;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdown == true)
                this.Location = new Point(this.Location.X + (e.Location.X - down.X), this.Location.Y + (e.Location.Y - down.Y));
        }
    }
}
