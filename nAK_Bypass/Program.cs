using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nAK_Bypass
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 3)
            {
                //args[0] Username args[1] Password args[2] Server args[3] Gamepath
                Command.Username = args[0];
                Command.Password = args[1];
                Command.Server = args[2];
                Command.Gamepath = args[3];
                for (int i = 4; i < args.Length; i++)
                {
                    Command.Gamepath += " ";
                    Command.Gamepath += args[i];
                }

            }
            else
            {
                MessageBox.Show($@"Somethings error on the Argument\nnAK_Bypass.exe Username Password Server D:\SteamLibrary\steamapps\common\Aura Kingdom", "Argument Error");
                Environment.Exit(0);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Bypass());
        }
    }
}
