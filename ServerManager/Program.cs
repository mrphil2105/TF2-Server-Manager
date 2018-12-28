using System;
using System.Windows.Forms;
using ServerManager.Core;
using ServerManager.Forms;
using ServerManager.Configuration;

namespace ServerManager
{
    public static class Program
    {
        public static Settings Settings { get; set; }

        public static ServersManager ServersManager { get; private set; }

        [STAThread]
        public static void Main()
        {
            Settings = new Settings();
            Settings.TryLoad();
            Settings.Save();

            ServersManager = new ServersManager();
            ServersManager.TryLoadServers();
            ServersManager.SaveServers();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
