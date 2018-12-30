using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Open.Nat;
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

        public static async Task<bool> TryCreatePortMappingAsync(Server server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            var discoverer = new NatDiscoverer();

            try
            {
                var device = await discoverer.DiscoverDeviceAsync();
                var mappings = await device.GetAllMappingsAsync();

                if (!mappings.Any(m => m.Protocol == Protocol.Udp && m.PrivatePort == server.Port && m.PublicPort == server.Port))
                {
                    var mapping = new Mapping(Protocol.Udp, server.Port, server.Port, server.Name);
                    await device.CreatePortMapAsync(mapping);
                }

                return true;
            }
            catch
            {
            }

            return false;
        }
    }
}
