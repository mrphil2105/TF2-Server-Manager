using System.IO;
using System.Net;
using Newtonsoft.Json;
using ServerManager.JsonConverters;

namespace ServerManager.Core
{
    public class Server
    {
        public const int FIRST_PORT = 28015;
        public const int CLIENT_PORT_OFFSET = 5;

        public Server()
        {
            Name = string.Empty;
            Folder = string.Empty;
            Address = IPAddress.Any;
            Port = FIRST_PORT;
            Map = "ctf_2fort";
            MaxPlayers = 24;
        }

        public string Name { get; set; }

        public string Folder { get; set; }

        [JsonConverter(typeof(StringIPAddressConverter))]
        public IPAddress Address { get; set; }

        public int Port { get; set; }

        public string Map { get; set; }

        public int MaxPlayers { get; set; }

        [JsonIgnore]
        public int ClientPort => Port + CLIENT_PORT_OFFSET;

        [JsonIgnore]
        public string Directory => string.IsNullOrEmpty(Folder) ? null : Path.Combine(Program.Settings.General.ServersDirectory, Folder);

        [JsonIgnore]
        public string SteamCMDPath => string.IsNullOrEmpty(Folder) ? null : Path.Combine(Program.Settings.General.ServersDirectory, Folder, "SteamCMD", "steamcmd.exe");

        [JsonIgnore]
        public string SRCDSPath => string.IsNullOrEmpty(Folder) ? null : Path.Combine(Program.Settings.General.ServersDirectory, Folder, "Server", "srcds.exe");
    }
}
