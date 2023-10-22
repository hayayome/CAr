using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 자동차_슈퍼_레이스
{
    public partial class Form1 : Form
    {
        private int timer = 0;
        public Form1()
        {
            InitializeComponent();

            this.KeyDown += Form1_KeyDown;

            BtnStart.MouseHover += BtnPause_MouseHover;
            BtnStart.MouseLeave += BtnPause_MouseLeave;
            BtnStart.Click += BtnStart_Click;

            BtnPause.MouseHover += BtnPause_MouseHover;
            BtnPause.MouseLeave += BtnPause_MouseLeave;
            BtnPause.Click += BtnPause_Click;

            timer1.Tick += timer_Tick;
            timer1.Interval = 1000;

            List<Image> Hurdles = new List<Image>()
            {
                Properties.Resources.정지,
                Properties.Resources.스쿨존,
                Properties.Resources.주차금지,
                Properties.Resources.표지판
            };
        }

        private void BtnPause_MouseHover(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                button.BackColor = Color.Red;
            }
        }

        private void BtnPause_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                button.BackColor = Color.Transparent;
            }
        }

        //private void BtnStart_MouseLeave(object sender, EventArgs e)
        //{
        //    BtnStart.BackColor = Color.Transparent;
        //}

        //private void BtnStart_MouseHover(object sender, EventArgs e)
        //{
        //    BtnStart.BackColor = Color.SkyBlue;
        //}

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    pbxCar.Left += 5;
                    break;
                case Keys.Left:
                    pbxCar.Left -= 5;
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer++;
            UpdateTimeLabel();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void UpdateTimeLabel()
        {
            int minutes = timer / 60;
            int second = timer % 60;
            lbltime.Text = $"{minutes:D2}:{second:D2}";
        }
    }
}
