using CefSharp;
using CefSharp.WinForms;
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
            browser = new ChromiumWebBrowser(URL.US_URL);
            Controls.Add(browser);
        }

        private ChromiumWebBrowser browser;
        private void Form1_Load(object sender, EventArgs e)
        {
            browser.Hide();
            Config._load();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
        private Task LoadPageAsync(IWebBrowser browser, string address = null)
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler = (sender, args) =>
            {
                if (!args.IsLoading)
                {
                    browser.LoadingStateChanged -= handler;
                    tcs.TrySetResult(true);
                }
            };

            browser.LoadingStateChanged += handler;
            if (!string.IsNullOrEmpty(address))
                browser.Load(address);
            return tcs.Task;
        }
        private async void Login(string server, string gamepath, string username, string password, int delay = 5000)
        {
            string _lpa = string.Empty;
            string _token = string.Empty;

            if (server == "US")
                _lpa = URL.US_URL;
            //browser.Load(URL.US_URL);
            if (server == "DE")
                _lpa = URL.DE_URL;
            //browser.Load(URL.DE_URL);
            if (server == "FR")
                _lpa = URL.FR_URL;
            //browser.Load(URL.FR_URL);
            if (server == "ES")
                _lpa = URL.ES_URL;
                //browser.Load(URL.ES_URL);
            await LoadPageAsync(browser, _lpa);
            var js = browser.CanExecuteJavascriptInMainFrame;

            if(js)
            {
                //edit-id
                await browser.EvaluateScriptAsync($"document.getElementById('edit-id').value = '{username}';");
                //edit-pass
                await browser.EvaluateScriptAsync($"document.getElementById('edit-pass').value = '{password}';");
                //account_login_submit
                await browser.EvaluateScriptAsync("document.getElementById('account_login_submit').click();");
                
                await Task.Delay(delay);
                while (browser.IsLoading)
                    await Task.Delay(delay);

                _token = HttpUtility.ParseQueryString(browser.Address).Get("code");
                if (_token == null)
                {
                    Console.WriteLine($"Somethings error to get Token");
                    return;
                }
                var tk = MD5Token(_token);
                Console.WriteLine($"Succesfull to get Token: {tk}");
            }
            if (_token != string.Empty)
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(gamepath, "Launcher.exe"),
                    Arguments = string.Format("-game.bin -a {0} -p Oauth2", _token),
                    WorkingDirectory = gamepath,
                    UseShellExecute = false
                };
                Process.Start(processStartInfo);
            }
        }
        public string MD5Token(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
                sb.Append(hashBytes[i].ToString("X2"));
            return sb.ToString();
        }
        private void start_btn_Click(object sender, EventArgs e)
        {
            string[] subs = AC_Manager.GetItemText(AC_Manager.SelectedItem).Split(',');
            if (subs[0] != string.Empty)
            {
                Login(subs[2], @subs[3], subs[0], subs[1]);
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
            foreach(var item in Config.mCUsers)
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
            foreach (var item in Config.mCUsers)
            {
                Login(item.Server, @item.Path, item.Username, item.Password);
                Task.Delay(15000);
            }
        }
    }
}
