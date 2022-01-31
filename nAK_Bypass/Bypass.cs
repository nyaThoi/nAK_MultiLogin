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

namespace nAK_Bypass
{
    public partial class Bypass : Form
    {
        private ChromiumWebBrowser browser;

        public Bypass()
        {
            InitializeComponent();

            if (Command.Server == "US")
                _lpa = US_URL;
            //browser.Load(URL.US_URL);
            if (Command.Server == "DE")
                _lpa = DE_URL;
            //browser.Load(URL.DE_URL);
            if (Command.Server == "FR")
                _lpa = FR_URL;
            //browser.Load(URL.FR_URL);
            if (Command.Server == "ES")
                _lpa = ES_URL;
            //browser.Load(URL.ES_URL);

            browser = new ChromiumWebBrowser(_lpa);
            this.Controls.Add(browser);
            //browser.Hide();

            Task.Run(() => Login());

        }
        #region Some Launcher Links
        /// <summary>
        /// DE Launcher URL
        /// </summary>
        public const string DE_URL = "https://www.aeriagames.com/dialog/oauth?response_type=code&client_id=cd9391da898949ca3be24b54ecad7bad0531f0feb&state=xyz&lang=de";
        /// <summary>
        /// US Launcher URL
        /// </summary>
        public const string US_URL = "https://www.aeriagames.com/dialog/oauth?response_type=code&client_id=18457ae92576b65ab92213612f6cc02d051ef19d2&state=xyz&lang=us";
        /// <summary>
        /// FR Launcher URL
        /// </summary>
        public const string FR_URL = "https://www.aeriagames.com/dialog/oauth?response_type=code&client_id=54f8336864c92199433c23b143cf0fa4051ef1a81&state=xyz&lang=fr";
        /// <summary>
        /// ES Launcher URL
        /// </summary>
        public const string ES_URL = "https://www.aeriagames.com/dialog/oauth?response_type=code&client_id=b79ffdae0ebc7624d4c7b34234688171054082acb&state=xyz&lang=es";
        #endregion
        public string _lpa = string.Empty;
        private async void Login()
        {
            string _token = string.Empty;
            browser.Load(_lpa);
            await Task.Delay(Command.Delay);

            var js = browser.CanExecuteJavascriptInMainFrame;

            if (js)
            {
                //edit-id
                await browser.EvaluateScriptAsync($"document.getElementById('edit-id').value = '{Command.Username}';");
                //edit-pass
                await browser.EvaluateScriptAsync($"document.getElementById('edit-pass').value = '{Command.Password}';");
                //account_login_submit
                await browser.EvaluateScriptAsync("document.getElementById('account_login_submit').click();");
                await Task.Delay(Command.Delay);
                while (browser.IsLoading)
                await Task.Delay(Command.Delay);
                //auth/reauth account
                await browser.EvaluateScriptAsync("document.querySelector('#buttons > a').click();");
                await Task.Delay(Command.Delay);

                _token = HttpUtility.ParseQueryString(browser.Address).Get("code");
                if (_token == null)
                {
                    MessageBox.Show($"Somethings error to get Token", "Error");
                    return;
                }
                var tk = MD5Token(_token);
                Console.WriteLine($"Succesfull to get Token: {tk} with {Command.Username}");
            }
            if (_token != string.Empty)
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(Command.Gamepath, "Launcher.exe"),
                    Arguments = string.Format("-game.bin -a {0} -p Oauth2", _token),
                    WorkingDirectory = Command.Gamepath,
                    UseShellExecute = false
                };
                Process.Start(processStartInfo);
            }

            this.Close();
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

        private void Bypass_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
    public class Command
    {
        public static string Username = string.Empty;
        public static string Password = string.Empty;
        public static string Server = string.Empty;
        public static string Gamepath = string.Empty;
        public static int Delay = 5000;
    }

}
