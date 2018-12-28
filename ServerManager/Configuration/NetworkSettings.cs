namespace ServerManager.Configuration
{
    public class NetworkSettings
    {
        public NetworkSettings()
        {
            AutoPortMapping = true;
        }

        public bool AutoPortMapping { get; set; }
    }
}
