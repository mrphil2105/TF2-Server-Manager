using System.Windows.Forms;
using ServerManager.Interfaces;
using ServerManager.Configuration;

namespace ServerManager.UI.Settings
{
    public partial class NetworkControl : UserControl, ISettingsUserControl
    {
        public NetworkControl()
        {
            InitializeComponent();

            chkPortMapping.Checked = Program.Settings.Network.AutoPortMapping;
        }

        public NetworkSettings Settings => new NetworkSettings()
        {
            AutoPortMapping = chkPortMapping.Checked
        };

        public bool CheckUserInput(Form form)
        {
            return true;
        }
    }
}
