using System;
using System.Windows.Forms;
using ServerManager.Helpers;
using ServerManager.Extensions;
using ServerManager.Interfaces;
using ServerManager.Configuration;

namespace ServerManager.UI.Settings
{
    public partial class GeneralControl : UserControl, ISettingsUserControl
    {
        public GeneralControl()
        {
            InitializeComponent();

            txtDirectory.Text = Program.Settings.General.ServersDirectory;
            chkHideConsole.Checked = Program.Settings.General.HideConsole;
        }

        public GeneralSettings Settings => new GeneralSettings()
        {
            ServersDirectory = txtDirectory.Text,
            HideConsole = chkHideConsole.Checked
        };

        public bool CheckUserInput(Form form)
        {
            if (string.IsNullOrWhiteSpace(txtDirectory.Text))
            {
                form.ShowError("Please select a directory for the servers.", "General: Missing Servers Directory");
                return false;
            }

            if (!FileHelper.IsDirectoryValid(txtDirectory.Text))
            {
                form.ShowError("The servers directory is invalid.", "General: Invalid Servers Directory");
                return false;
            }

            return true;
        }

        private void OnClick(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog()
            {
                Description = "Select a directory for the servers.",
                SelectedPath = txtDirectory.Text
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtDirectory.Text = dialog.SelectedPath;
                }
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BeginInvoke(() => btnBrowseDirectory.PerformClick());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
