using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Resourcepackv1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            this.BackgroundImage = Properties.Resources.jp2kutas;
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            Random random = new Random();
            int x = random.Next(0, 1270);
            int y = random.Next(0, 920);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            List<Bitmap> lisimage = new List<Bitmap>();
            lisimage.Add(Properties.Resources.jp2kutas);
            var indexbackimage = DateTime.Now.Second % lisimage.Count;
            this.BackgroundImage = lisimage[indexbackimage];
        }
    }
}
