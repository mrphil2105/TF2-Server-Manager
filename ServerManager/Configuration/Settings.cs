using System.IO;
using Newtonsoft.Json;

namespace ServerManager.Configuration
{
    public class Settings
    {
        private const string FILE_NAME = "Settings.json";

        public Settings()
        {
            General = new GeneralSettings();
            Network = new NetworkSettings();
        }

        public GeneralSettings General { get; set; }

        public NetworkSettings Network { get; set; }

        public void Save()
        {
            string settingsJson = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(FILE_NAME, settingsJson);
        }

        public bool TryLoad()
        {
            if (File.Exists(FILE_NAME))
            {
                string settingsJson = File.ReadAllText(FILE_NAME);
                JsonConvert.PopulateObject(settingsJson, this);
                return true;
            }

            return false;
        }
    }
}
