using System;
using System.Net;
using Newtonsoft.Json;

namespace ServerManager.JsonConverters
{
    public class StringIPAddressConverter : JsonConverter<IPAddress>
    {
        public override IPAddress ReadJson(JsonReader reader, Type objectType, IPAddress existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return IPAddress.Parse((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, IPAddress value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
