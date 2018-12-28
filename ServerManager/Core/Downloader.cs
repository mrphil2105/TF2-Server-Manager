using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ServerManager.Core
{
    public class Downloader
    {
        public event EventHandler<EventArgs> ProgressChanged;

        public Downloader(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(url));
            }

            Url = url;
        }

        public string Url { get; }

        public long BytesDownloaded { get; private set; }

        public long ContentLength { get; private set; }

        public async Task<byte[]> DownloadAsync(CancellationToken cancellationToken)
        {
            var request = WebRequest.CreateHttp(Url);
            request.Method = "GET";
            request.Timeout = 5000;

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        BytesDownloaded = 0;
                        ContentLength = response.ContentLength;

                        while (!cancellationToken.IsCancellationRequested)
                        {
                            byte[] buffer = new byte[81920];
                            int bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length);

                            if (bytesRead == 0)
                            {
                                return memoryStream.ToArray();
                            }

                            await memoryStream.WriteAsync(buffer, 0, bytesRead);
                            BytesDownloaded += bytesRead;
                            ProgressChanged?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
            }

            return null;
        }
    }
}
