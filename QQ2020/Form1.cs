using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.BackColor = Color.Red;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.BackColor = Color.Transparent; 
        }

        private void picMin_MouseEnter(object sender, EventArgs e)
        {
            picMin.BackColor = Color.FromArgb(50,255,255,255);
        }

        private void picMin_MouseLeave(object sender, EventArgs e)
        {
            picMin.BackColor = Color.Transparent;
        }

        private void picSet_MouseEnter(object sender, EventArgs e)
        {
            picSet.BackColor = Color.FromArgb(50, 255, 255, 255);
        }

        private void picSet_MouseLeave(object sender, EventArgs e)
        {
            picSet.BackColor = Color.Transparent;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFindPwd_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Gray;
        }
        private void lblFindPwd_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.DarkGray;
        }

        private void picQRCode_MouseEnter(object sender, EventArgs e)
        {
            picQRCode.Image = QQ2020.Properties.Resources.二维码_en;
        }

        private void picQRCode_MouseLeave(object sender, EventArgs e)
        {
            picQRCode.Image = QQ2020.Properties.Resources.二维码_dis;
        }

        int MoveStep = 0;

        private void picHPicture_MouseEnter(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            MoveStep = 4;
            picAdd.Location = new Point(picAdd.Location.X + MoveStep, picAdd.Location.Y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picAdd.Location.X >= 270 || picAdd.Location.X <= 180)
                return;
            else
                picAdd.Location = new Point(picAdd.Location.X + MoveStep, picAdd.Location.Y);
        }

        private void picHPicture_MouseLeave(object sender, EventArgs e)
        {
            MoveStep = -4;
            picAdd.Location = new Point(picAdd.Location.X + MoveStep, picAdd.Location.Y);
        }

        private void txtUser_MouseEnter(object sender, EventArgs e)
        {
            pnlUser.BackColor = Color.Gray;
        }

        private void txtUser_MouseLeave(object sender, EventArgs e)
        {
            pnlUser.BackColor = Color.DarkGray;
        }

        private void txtKeyBoard_MouseEnter(object sender, EventArgs e)
        {
            pnlPassword.BackColor = Color.Gray;
        }

        private void txtKeyBoard_MouseLeave(object sender, EventArgs e)
        {
            pnlPassword.BackColor = Color.DarkGray;
        }

        private void picQQHao_MouseEnter(object sender, EventArgs e)
        {
            picQQHao.Image = QQ2020.Properties.Resources.下箭头_en;
        }

        private void picQQHao_MouseLeave(object sender, EventArgs e)
        {
            picQQHao.Image = QQ2020.Properties.Resources.下箭头_dis;
        }

        private void picKeyBoard_MouseEnter(object sender, EventArgs e)
        {
            picKeyBoard.Image = QQ2020.Properties.Resources.键盘_en;
        }

        private void picKeyBoard_MouseLeave(object sender, EventArgs e)
        {
            picKeyBoard.Image = QQ2020.Properties.Resources.键盘_dis;
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.Text = "";
            picUser.Image = QQ2020.Properties.Resources.QQ_user_en;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text == "")
            {
                txtUser.Text = "QQ号码/手机/邮箱";
            }
            picUser.Image = QQ2020.Properties.Resources.QQ_user_dis;
        }

        private void txtKeyBoard_Enter(object sender, EventArgs e)
        {
            txtKeyBoard.Text = "";
            txtKeyBoard.UseSystemPasswordChar = true;
            picPassword.Image = QQ2020.Properties.Resources._189解锁__1_;
        }

        private void txtKeyBoard_Leave(object sender, EventArgs e)
        {
            if(txtKeyBoard.Text == "")
            {
                txtKeyBoard.UseSystemPasswordChar = false;
                txtKeyBoard.Text = "密码";
            }
            picPassword.Image = QQ2020.Properties.Resources._189解锁;
        }
        Point down;
        bool isdown;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isdown == true)
            this.Location = new Point(this.Location.X+(e.Location.X-down.X), this.Location.Y+(e.Location.Y-down.Y));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            down = e.Location;
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            isdown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            isdown = false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "QQ号码/手机/邮箱";
            }
            picUser.Image = QQ2020.Properties.Resources.QQ_user_dis;
            if (txtKeyBoard.Text == "")
            {
                txtKeyBoard.UseSystemPasswordChar = false;
                txtKeyBoard.Text = "密码";
            }
            picPassword.Image = QQ2020.Properties.Resources._189解锁;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }
    }
}
