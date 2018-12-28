using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using ServerManager.Core;
using ServerManager.Helpers;
using ServerManager.Extensions;

namespace ServerManager.Forms
{
    public partial class UpdateForm : Form
    {
        private readonly Server _server;
        private readonly SteamCMDParser _steamCMDParser;

        private Process _steamCMDProcess;

        public UpdateForm(Server server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            InitializeComponent();

            _server = server;
            _steamCMDParser = new SteamCMDParser(this);

            Disposed += (sender, e) =>
            {
                KillProcesses();
                _steamCMDProcess?.Dispose();
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            btnRun.PerformClick();
        }

        private void UpdateControls(bool running)
        {
            btnRun.Enabled = !running;
            btnStop.Enabled = running;
        }

        private async Task RunProcessAsync()
        {
            string serverDirectory = Path.GetDirectoryName(_server.SRCDSPath);
            Directory.CreateDirectory(serverDirectory);

            _steamCMDProcess?.Dispose();
            _steamCMDProcess = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = _server.SteamCMDPath,
                    Arguments = @"+login anonymous +force_install_dir ..\Server +app_update 232250 +quit",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };
            _steamCMDProcess.Exited += OnProcessExited;
            _steamCMDProcess.Start();

            string line;

            while ((line = await _steamCMDProcess.StandardOutput.ReadLineAsync()) != null)
            {
                WriteMessage(line);
                _steamCMDParser.ParseLine(line);
                lblStatus.Text = "Status : " + _steamCMDParser.UpdateState;

                if (_steamCMDParser.Processed <= _steamCMDParser.Total)
                {
                    lblProgress.Text = ProgressHelper.FormatProgressLine(_steamCMDParser.Processed, _steamCMDParser.Total);
                    prgProgress.Value = ProgressHelper.GetProgressPercentage(_steamCMDParser.Processed, _steamCMDParser.Total);
                }
            }
        }

        // We need to kill SteamCMD like this, as it sometimes spawns subprocesses.
        private void KillProcesses()
        {
            var processes = Process.GetProcessesByName("steamcmd");

            foreach (var process in processes)
            {
                // Make sure we are killing the SteamCMD of this updater only.
                if (process.MainModule.FileName == _server.SteamCMDPath)
                {
                    process.Kill();
                    process.Dispose();
                }
            }
        }

        private void WriteMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                txtOutput.AppendText($"{message}{Environment.NewLine}");
            }
        }

        private void OnProcessExited(object sender, EventArgs e)
        {
            this.Invoke(() =>
            {
                UpdateControls(false);
                WriteMessage("SteamCMD has exited.");

                if (_steamCMDParser.UpdateState != "Success" && _steamCMDParser.UpdateState != "Error")
                {
                    lblStatus.Text = "Status : Stopped";
                }
            });
        }

        private async void OnClick(object sender, EventArgs e)
        {
            if (sender == btnRun)
            {
                if (!File.Exists(_server.SteamCMDPath))
                {
                    var dialogResult = this.ShowQuestion("SteamCMD has not been downloaded for this server and is required, " +
                        "do you want to download it now?", "Download SteamCMD?");

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (var downloadForm = new DownloadForm(_server))
                        {
                            if (downloadForm.ShowDialog() != DialogResult.OK)
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                UpdateControls(true);
                lblStatus.Text = "Status : Starting";
                WriteMessage("Starting SteamCMD...");
                await RunProcessAsync();
            }
            else
            {
                KillProcesses();
            }
        }
    }
}
