using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Diagnostics;
using System.Net.Sockets;
using System.Windows.Forms;
using ServerManager.Core;
using ServerManager.Forms;
using ServerManager.Helpers;
using ServerManager.Extensions;

namespace ServerManager.UI
{
    public partial class ServerControl : UserControl
    {
        private const string HIDE_CONSOLE_TEXT = "&Hide Console";
        private const string SHOW_CONSOLE_TEXT = "S&how Console";

        private readonly Server _server;
        private readonly ServerRunner _serverRunner;

        public ServerControl(Server server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            InitializeComponent();

            _server = server;
            _serverRunner = new ServerRunner(server);
            _serverRunner.Stopped += OnStopped;

            Disposed += (sender, e) => _serverRunner.Dispose();

            txtName.Text = server.Name;
            txtFolder.Text = server.Folder;
            txtAddress.Text = server.Address.ToString();
            numPort.Value = server.Port;
            txtMap.Text = server.Map;
            numSlots.Value = server.MaxPlayers;
            btnApplyGeneralSettings.Enabled = false;

            if (_serverRunner.TryRecoverProcess(out bool consoleVisible))
            {
                UpdateControls(EState.Running);
                btnHideShowConsole.Text = consoleVisible ? HIDE_CONSOLE_TEXT : SHOW_CONSOLE_TEXT;
            }
            else
            {
                UpdateControls(EState.Stopped);
            }
        }

        public EState State { get; private set; }

        public void UpdateControls()
        {
            UpdateControls(State);
        }

        private void UpdateControls(EState state)
        {
            State = state;

            grpGeneralSettings.Enabled = state == EState.Stopped;
            lblStatus.Text = "Status : " + state.ToPascalSpacedString();

            btnRunUpdater.Enabled = state == EState.Stopped && !string.IsNullOrEmpty(_server.Folder);
            btnStart.Enabled = state == EState.Stopped && File.Exists(_server.SRCDSPath);
            btnStop.Enabled = state == EState.Running;
            btnConnect.Enabled = state == EState.Running;
            btnHideShowConsole.Enabled = state == EState.Running;

            if (state != EState.Running)
            {
                btnHideShowConsole.Text = Program.Settings.General.HideConsole ? SHOW_CONSOLE_TEXT : HIDE_CONSOLE_TEXT;
            }
        }

        private void OnStopped(object sender, EventArgs e)
        {
            this.Invoke(() => UpdateControls(EState.Stopped));
        }

        private async void OnClick(object sender, EventArgs e)
        {
            if (sender == btnApplyGeneralSettings)
            {
                ButtonApplyGeneralSettings();
            }
            else if (sender == btnRunUpdater)
            {
                UpdateControls(EState.Updating);
                var updateForm = new UpdateForm(_server);
                updateForm.FormClosed += (sender_, e_) => UpdateControls(EState.Stopped);
                updateForm.Show();
            }
            else if (sender == btnStart)
            {
                if (Program.Settings.Network.AutoPortMapping)
                {
                    UpdateControls(EState.PortMapping);

                    if (!await NetworkHelper.TryCreatePortMappingAsync(_server))
                    {
                        this.ShowError("Unable to create port mapping, either your router is not available or has port mapping disabled/unsupported. " +
                            "To fix this issue you might need to make a port forward in your router configuration (find a tutorial for your router online). " +
                            "People outside of your local network will be unable to join your server without a port mapping/forward. " +
                            "You can disable automatic port mapping in Help > Settings > Network.", "Port Mapping Failed");
                    }
                }

                UpdateControls(EState.Running);
                _serverRunner.StartProcess();
            }
            else if (sender == btnStop)
            {
                _serverRunner.KillProcess();
            }
            else if (sender == btnConnect)
            {
                var address = _server.Address;

                if (address.Equals(IPAddress.Any))
                {
                    if ((address = NetworkHelper.GetActiveLocalAddress()) == null)
                    {
                        this.ShowError("Unable to connect because your local ip address could not be determined.", "Missing Local Address");
                        return;
                    }
                }

                Process.Start($"steam://connect/{address}:{_server.Port}");
            }
            else if (sender == btnHideShowConsole)
            {
                if (btnHideShowConsole.Text == HIDE_CONSOLE_TEXT)
                {
                    _serverRunner.HideConsole();
                    btnHideShowConsole.Text = SHOW_CONSOLE_TEXT;
                }
                else
                {
                    _serverRunner.ShowConsole();
                    btnHideShowConsole.Text = HIDE_CONSOLE_TEXT;
                }
            }
        }

        private void ButtonApplyGeneralSettings()
        {
            #region Input Checking
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                this.ShowError("Please enter a name for the server.", "Missing Name");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFolder.Text))
            {
                this.ShowError("Please enter a folder for the server.", "Missing Folder");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                this.ShowError("Please enter an ip address for the server.", "Missing Address");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMap.Text))
            {
                this.ShowError("Please enter a map for the server.", "Missing Map");
                return;
            }

            char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

            if (txtFolder.Text.IndexOfAny(invalidFileNameChars) >= 0)
            {
                this.ShowError("The folder contains invalid characters.", "Invalid Folder Characters");
                return;
            }

            if (Program.ServersManager.Servers.Any(s => s != _server && s.Folder.Equals(txtFolder.Text, StringComparison.OrdinalIgnoreCase)))
            {
                this.ShowError("The folder is in use by another server.", "Folder Taken");
                return;
            }

            if (!IPAddress.TryParse(txtAddress.Text, out var address) || address.AddressFamily != AddressFamily.InterNetwork)
            {
                this.ShowError("The ip address is invalid.", "Invalid Address");
                return;
            }

            int port = (int)numPort.Value;
            int clientPort = (int)numPort.Value + Server.CLIENT_PORT_OFFSET;

            // We do not want to use a game port/client port if it is in use by another server.
            if (Program.ServersManager.Servers.Any(s => s != _server && (s.Port == port || s.Port == clientPort || s.ClientPort == clientPort ||
                s.ClientPort == port)))
            {
                this.ShowError($"The port is in use by another server. (Please note: each server also uses a client port that is {Server.CLIENT_PORT_OFFSET} " +
                    $"greater than its game port. For example: {Server.FIRST_PORT} and {Server.FIRST_PORT + Server.CLIENT_PORT_OFFSET})", "Port Taken");
                return;
            }

            if (txtMap.Text.IndexOfAny(invalidFileNameChars) >= 0)
            {
                this.ShowError("The map contains invalid characters.", "Invalid Map Characters");
                return;
            }

            if (txtMap.Text.IndexOf(' ') >= 0)
            {
                this.ShowError("The map cannot contain spaces.", "Invalid Map Characters");
                return;
            }
            #endregion

            string oldDirectory = _server.Directory;

            _server.Name = txtName.Text;
            _server.Folder = txtFolder.Text;
            _server.Address = address;
            _server.Port = port;
            _server.Map = txtMap.Text;
            _server.MaxPlayers = (int)numSlots.Value;

            // Move the directory if it changed, but only if the old one exists.
            if (!_server.Directory.Equals(oldDirectory, StringComparison.OrdinalIgnoreCase) && Directory.Exists(oldDirectory))
            {
                try
                {
                    Directory.Move(oldDirectory, _server.Directory);
                }
                catch (IOException)
                {
                    this.ShowError("Unable to rename the server folder, please make sure it is not in use by another program.", "Folder Rename Failed");
                }
            }

            Program.ServersManager.SaveServers();
            UpdateControls();
            Parent.Text = _server.Name;
            btnApplyGeneralSettings.Enabled = false;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is NumericUpDown)
            {
                btnApplyGeneralSettings.Enabled = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.BeginInvoke(() => btnApplyGeneralSettings.PerformClick());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            btnApplyGeneralSettings.Enabled = true;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            btnApplyGeneralSettings.Enabled = true;
        }

        public enum EState
        {
            Stopped,
            Updating,
            PortMapping,
            Running
        }
    }
}
