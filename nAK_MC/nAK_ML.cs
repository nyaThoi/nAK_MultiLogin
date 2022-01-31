using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace nAK_MC
{
    public partial class nAK_MC : Form
    {
        public nAK_MC()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Config._load();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void start_btn_Click(object sender, EventArgs e)
        {
            string[] subs = AC_Manager.GetItemText(AC_Manager.SelectedItem).Split(',');
            if (subs[0] != string.Empty)
            {
                Task.Run(() => StartBypass(subs[0], @subs[1], subs[2], subs[3]));
            }
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            Config._save();
        }
        private void restore_btn_Click(object sender, EventArgs e)
        {
            Config._load();
            AC_Manager.Items.Clear();
            foreach (var item in Config.mCUsers)
            {
                AC_Manager.Items.Add($"{item.Username},{item.Password},{item.Server},{item.Path}");
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            if (user_tB.Text.Length > 64 || user_tB.Text.Length < 4)
            {
                MessageBox.Show("Username invalid",
                                "Error");
                return;
            }
            if (pw_tB.Text.Length > 20 || pw_tB.Text.Length < 4)
            {
                MessageBox.Show("Password invalid",
                                "Error");
                return;
            }
            if (path_tB.Text == string.Empty)
            {
                MessageBox.Show("Gamepath invalid",
                                "Error");
                return;
            }
            if (sr_cB.Text == "DE" || sr_cB.Text == "US" || sr_cB.Text == "FR")
            {
                AC_Manager.Items.AddRange(new object[] {
            $"{user_tB.Text},{pw_tB.Text},{sr_cB.Text},{path_tB.Text}"});
                Config._AddItems(user_tB.Text, pw_tB.Text, sr_cB.Text, path_tB.Text);
            }
            else
                MessageBox.Show("Server invalid",
                                "Error");
        }
        private void rmv_btn_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection sI = new ListBox.SelectedObjectCollection(AC_Manager);
            string[] subs = AC_Manager.GetItemText(AC_Manager.SelectedItem).Split(',');
            sI = AC_Manager.SelectedItems;
            if (AC_Manager.SelectedIndex != -1)
            {
                for (int i = sI.Count - 1; i >= 0; i--)
                {
                    AC_Manager.Items.Remove(sI[i]);
                    if (subs[0] != string.Empty)
                    {
                        Config._RemoveItems(subs[0], subs[1], subs[2], @subs[3]);
                    }
                }
            }

        }
        private void startv2_btn_Click(object sender, EventArgs e)
        {
            Task.Run(() => _multiLogin());
        }
        private async void _multiLogin(int delay = 15000)
        {
            foreach (var item in Config.mCUsers)
            {
                await Task.Run(() => StartBypass(item.Username, item.Password, item.Server, item.Path));
                await Task.Delay(delay);
            }
        }
        private void StartBypass(string Username, string Password, string Server, string arg)
        {

            var processStartInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(System.Environment.CurrentDirectory, "nAK_Bypass.exe"),
                Arguments = string.Format($@"{Username} {Password} {Server} {arg}"),
                WorkingDirectory = System.Environment.CurrentDirectory,
                UseShellExecute = false
            };
            Process.Start(processStartInfo);
        }
    }
}