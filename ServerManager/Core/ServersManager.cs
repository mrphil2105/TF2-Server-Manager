using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServerManager.Core
{
    public class ServersManager
    {
        private const string SERVERS_FILE_NAME = "Servers.json";

        public ServersManager()
        {
            Servers = new List<Server>();
        }

        public List<Server> Servers { get; private set; }

        public void SaveServers()
        {
            string serversJson = JsonConvert.SerializeObject(Servers, Formatting.Indented);
            File.WriteAllText(SERVERS_FILE_NAME, serversJson);
        }

        public bool TryLoadServers()
        {
            if (File.Exists(SERVERS_FILE_NAME))
            {
                string serversJson = File.ReadAllText(SERVERS_FILE_NAME);
                Servers = JsonConvert.DeserializeObject<List<Server>>(serversJson);
                return true;
            }

            return false;
        }

        public Server CreateServer()
        {
            var server = new Server()
            {
                Port = GetNewPort()
            };
            Servers.Add(server);
            SaveServers();
            return server;
        }

        public void DeleteServer(Server server, bool deleteFiles)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            Servers.Remove(server);
            SaveServers();

            if (deleteFiles && Directory.Exists(server.Directory))
            {
                Directory.Delete(server.Directory, true);
            }
        }

        private int GetNewPort()
        {
            int port = Server.FIRST_PORT;
            int clientPort = port + Server.CLIENT_PORT_OFFSET;

            // We do not want to use a game port/client port if it is in use by another server.
            while (Servers.Any(s => s.Port == port || s.Port == clientPort || s.ClientPort == clientPort || s.ClientPort == port))
            {
                port += 10;
                clientPort += 10;
            }

            return port;
        }
    }
}
