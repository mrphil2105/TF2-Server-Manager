using System;
using System.Windows.Forms;
using ServerManager.Interfaces;
using ServerManager.UI.Settings;
using ServerManager.Configuration;

namespace ServerManager.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly UserControl[] _settingsControls;

        public SettingsForm()
        {
            InitializeComponent();

            _settingsControls = new UserControl[]
            {
                new GeneralControl(),
                new NetworkControl()
            };
            pnlSettings.Controls.Add(_settingsControls[0]);

            Disposed += (sender, e) =>
            {
                foreach (var control in _settingsControls)
                {
                    control.Dispose();
                }
            };
        }

        private void OnClick(object sender, EventArgs e)
        {
            foreach (ISettingsUserControl control in _settingsControls)
            {
                if (!control.CheckUserInput(this))
                {
                    return;
                }
            }

            Program.Settings = new Settings()
            {
                General = ((GeneralControl)_settingsControls[0]).Settings,
                Network = ((NetworkControl)_settingsControls[1]).Settings
            };
            Program.Settings.Save();
            DialogResult = DialogResult.OK;
        }

        private void OnAfterSelect(object sender, TreeViewEventArgs e)
        {
            int index = treeSettings.Nodes.IndexOf(e.Node);
            pnlSettings.Controls.Clear();
            pnlSettings.Controls.Add(_settingsControls[index]);
        }
    }
}
