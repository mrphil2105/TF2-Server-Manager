using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;
using ServerManager.Core;
using ServerManager.Helpers;
using ServerManager.Extensions;

namespace ServerManager.Forms
{
    public partial class DownloadForm : Form
    {
        private const string STEAM_CMD_URL = "http://media.steampowered.com/installer/steamcmd.zip";

        private readonly Server _server;
        private readonly Downloader _downloader;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public DownloadForm(Server server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            InitializeComponent();

            _server = server;
            _downloader = new Downloader(STEAM_CMD_URL);
            _downloader.ProgressChanged += OnProgressChanged;
            _cancellationTokenSource = new CancellationTokenSource();

            Disposed += (sender, e) =>
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            btnDownload.PerformClick();
        }

        private void UpdateControls(bool running)
        {
            lblStatus.Text = "Status : " + (running ? "Downloading" : "Error");
            btnDownload.Enabled = !running;
            btnCancel.Enabled = running;
        }

        private async Task<bool> DownloadExtractAsync()
        {
            byte[] fileBytes = null;

            try
            {
                fileBytes = await _downloader.DownloadAsync(_cancellationTokenSource.Token);
            }
            catch (WebException webException)
            {
                this.ShowError($"Unable to download SteamCMD: {webException.Message}", "Download Failed");
            }

            if (fileBytes != null)
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_server.SteamCMDPath));

                    using (var memoryStream = new MemoryStream(fileBytes))
                    using (var zipFile = new ZipArchive(memoryStream))
                    using (var entryStream = zipFile.GetEntry("steamcmd.exe").Open())
                    using (var fileStream = new FileStream(_server.SteamCMDPath, FileMode.Create, FileAccess.Write))
                    {
                        await entryStream.CopyToAsync(fileStream);
                        return true;
                    }
                }
                catch
                {
                    this.ShowError("An error has occurred when extracting SteamCMD.", "Extraction Failed");
                }
            }

            return false;
        }

        private void OnProgressChanged(object sender, EventArgs e)
        {
            lblProgress.Text = ProgressHelper.FormatProgressLine(_downloader.BytesDownloaded, _downloader.ContentLength);
            prgProgress.Value = ProgressHelper.GetProgressPercentage(_downloader.BytesDownloaded, _downloader.ContentLength);
        }

        private async void OnClick(object sender, EventArgs e)
        {
            if (sender == btnDownload)
            {
                UpdateControls(true);
                bool completed = await DownloadExtractAsync();

                if (completed || _cancellationTokenSource.IsCancellationRequested)
                {
                    DialogResult = completed ? DialogResult.OK : DialogResult.Cancel;
                }
                else
                {
                    UpdateControls(false);
                }
            }
            else
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
}
