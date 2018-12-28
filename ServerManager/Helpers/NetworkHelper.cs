using System.Net;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using ServerManager.Core;

namespace ServerManager.Helpers
{
    public static class NetworkHelper
    {
        public static IPAddress GetActiveLocalAddress()
        {
            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    var interfaceProperties = networkInterface.GetIPProperties();

                    if (interfaceProperties.GatewayAddresses.Count > 0)
                    {
                        foreach (var unicastAddress in interfaceProperties.UnicastAddresses)
                        {
                            if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork && !unicastAddress.IPv4Mask.Equals(IPAddress.Any))
                            {
                                return unicastAddress.Address;
                            }
                        }
                    }
                }
            }

            return null;
        }

        public static async Task<IPAddress> GetActivePublicAddressAsync()
        {
            try
            {
                var downloader = new Downloader("http://ipv4.icanhazip.com/");
                byte[] addressBytes = await downloader.DownloadAsync(CancellationToken.None);
                string addressString = Encoding.UTF8.GetString(addressBytes).Trim();

                if (IPAddress.TryParse(addressString, out var address) && address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address;
                }
            }
            catch (WebException)
            {
            }

            return null;
        }
    }
}
