namespace ServerManager.Configuration
{
    public class GeneralSettings
    {
        public GeneralSettings()
        {
            ServersDirectory = "Servers";
        }

        public string ServersDirectory { get; set; }

        public bool HideConsole { get; set; }
    }
}
