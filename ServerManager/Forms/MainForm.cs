using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using ServerManager.UI;
using ServerManager.Core;
using ServerManager.Helpers;
using ServerManager.Extensions;

namespace ServerManager.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            foreach (var server in Program.ServersManager.Servers)
            {
                AddServerTab(server);
            }
        }

        private void UpdateControls()
        {
            btnDelete.Enabled = Program.ServersManager.Servers.Count > 0;
            btnLeft.Enabled = tabServers.SelectedIndex > 0;
            btnRight.Enabled = tabServers.SelectedIndex != Program.ServersManager.Servers.Count - 1;
            toolLinkCopyPublicEndPoint.Enabled = Program.ServersManager.Servers.Count > 0;
        }

        private void AddServerTab(Server server)
        {
            var tabPage = new TabPage(server.Name);
            tabPage.Controls.Add(new ServerControl(server)
            {
                Dock = DockStyle.Fill
            });
            tabServers.TabPages.Add(tabPage);
            UpdateControls();
        }

        private ServerControl GetServerControl(int index)
        {
            return (ServerControl)tabServers.TabPages[index].Controls[0];
        }

        private void UpdateServerControls()
        {
            foreach (TabPage tabPage in tabServers.TabPages)
            {
                ((ServerControl)tabPage.Controls[0]).UpdateControls();
            }
        }

        private void MoveServer(bool right)
        {
            int newIndex = tabServers.SelectedIndex + (right ? 1 : -1);

            var server = Program.ServersManager.Servers[tabServers.SelectedIndex];
            Program.ServersManager.Servers[tabServers.SelectedIndex] = Program.ServersManager.Servers[newIndex];
            Program.ServersManager.Servers[newIndex] = server;
            Program.ServersManager.SaveServers();

            var tabPage = tabServers.TabPages[tabServers.SelectedIndex];
            tabServers.TabPages[tabServers.SelectedIndex] = tabServers.TabPages[newIndex];
            tabServers.TabPages[newIndex] = tabPage;

            tabServers.SelectedIndex = newIndex;
            UpdateControls();
        }

        private async void OnClick(object sender, EventArgs e)
        {
            if (sender == btnAdd)
            {
                var server = Program.ServersManager.CreateServer();
                AddServerTab(server);
                tabServers.SelectedIndex = Program.ServersManager.Servers.Count - 1;
            }
            else if (sender == btnDelete)
            {
                ButtonDelete();
            }
            else if (sender == btnLeft)
            {
                MoveServer(false);
            }
            else if (sender == btnRight)
            {
                MoveServer(true);
            }
            else if (sender == menuClickBrowseFiles)
            {
                Directory.CreateDirectory(Program.Settings.General.ServersDirectory);

                using (Process.Start("explorer.exe", Program.Settings.General.ServersDirectory))
                {
                }
            }
            else if (sender == menuClickExit)
            {
                Close();
            }
            else if (sender == menuClickSettings)
            {
                using (var settingsForm = new SettingsForm())
                {
                    if (settingsForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateServerControls();
                    }
                }
            }
            else if (sender == menuClickAbout)
            {
                using (var aboutForm = new AboutForm())
                {
                    aboutForm.ShowDialog();
                }
            }
            else if (sender == toolLinkCopyPublicEndPoint)
            {
                IPAddress address;

                if ((address = await NetworkHelper.GetActivePublicAddressAsync()) == null)
                {
                    this.ShowError("Unable to determine your public ip address, please make sure you are connected to the internet.", "Missing Public Address");
                    return;
                }

                var server = Program.ServersManager.Servers[tabServers.SelectedIndex];
                Clipboard.SetText($"{address}:{server.Port}");
                this.ShowMessage("The public server ip address and port have been copied to the clipboard.", "Public Server IP:Port Copied");
            }
        }

        private void ButtonDelete()
        {
            var serverControl = GetServerControl(tabServers.SelectedIndex);

            if (serverControl.State != ServerControl.EState.Stopped)
            {
                string pascalSpacedState = serverControl.State.ToPascalSpacedString();
                this.ShowError($"You cannot delete a server while it is {pascalSpacedState.ToLower()}.", $"{pascalSpacedState} Server");
                return;
            }

            var dialogResult = DialogResult.No;
            var server = Program.ServersManager.Servers[tabServers.SelectedIndex];

            if (Directory.Exists(server.Directory))
            {
                dialogResult = this.ShowQuestion("Do you want to delete the server files as well?", "Delete Server Files?", true);
            }

            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            Program.ServersManager.DeleteServer(server, dialogResult == DialogResult.Yes);
            tabServers.TabPages[tabServers.SelectedIndex].Dispose();
            UpdateControls();
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }
    }
}
