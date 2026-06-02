using System.Text.Json.Serialization;

namespace AthiasToVSM
{
    public class Page
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
    }

    public class AppConfig
    {
        [JsonPropertyName("port")]
        public int Port { get; set; } = 9091;

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; } = "Athias controller";

        [JsonPropertyName("anthiasIP")]
        public string AnthiasIP { get; set; } = "0.0.0.0";

        [JsonPropertyName("pages")]
        public List<Page> Pages { get; set; } = new List<Page>();
    }
}