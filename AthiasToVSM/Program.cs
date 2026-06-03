using EmberLib.Glow;
using EmberPlusProviderClassLib;
using EmberPlusProviderClassLib.EmberHelpers;
using System.Net.Http.Json;
using System.Text.Json;

namespace AthiasToVSM
{
    internal class Program
    {
        static AppConfig config;
        static AppConfig LoadConfig(string path = "config.json")
        {
            if (!File.Exists(path))
            {
                const string message = "config.json not found";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);
                throw new FileNotFoundException($"Config file not found at {path}");
            }

            var json = File.ReadAllText(path);
            var cfg = JsonSerializer.Deserialize<AppConfig>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return cfg;
        }


        static async Task PatchAssetAsync(int index, object payload)
        {
            using var httpClient = new HttpClient();
            var url = $"http://{config.AnthiasIP}/api/v2/assets/{config.Pages[index].Id}";

            // Convert payload to IEnumerable<KeyValuePair<string,string>>
            IEnumerable<KeyValuePair<string, string>> formData;

            if (payload is IEnumerable<KeyValuePair<string, string>> kvpEnumerable)
            {
                formData = kvpEnumerable;
            }
            else
            {
                var list = new List<KeyValuePair<string, string>>();
                if (payload != null)
                {
                    var type = payload.GetType();
                    var props = type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                    foreach (var prop in props)
                    {
                        // skip indexers
                        if (prop.GetIndexParameters().Length > 0) continue;
                        var name = prop.Name;
                        var value = prop.GetValue(payload);
                        list.Add(new KeyValuePair<string, string>(name, value?.ToString() ?? string.Empty));
                    }
                }
                formData = list;
            }

            using var content = new FormUrlEncodedContent(formData);
            // Explicitly set the Content-Type header as requested
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded")
            {
                CharSet = "utf-8"
            };

            var request = new HttpRequestMessage(HttpMethod.Patch, url)
            {
                Content = content
            };

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        static void SetActiveByIndex(int index)
        {
            for (int i = 0; i < config.Pages.Count; i++)
            {
                if (i == index)
                {
                    PatchAssetAsync(i, new { is_enabled = true }).GetAwaiter().GetResult();
                }
                else
                {
                    PatchAssetAsync(i, new { is_enabled = false }).GetAwaiter().GetResult();
                }
            }
        }


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            config = LoadConfig();
            // Initiate EmBER+ tree
            var _emberTree = new EmberPlusProvider(
                config.Port,
                config.Identifier,
                "Anthias controller");

            _emberTree.CreateIdentityNode(
                1,
                "Anthias controller",
                "Anthias controller over Ember+",
                "HBJ",
                "v2.1.0");

            // General utility node
            var utilityNode = _emberTree.AddChildNode(2, "pages");
            int id = 1;
            foreach (var item in config.Pages)
            {
                // capture current index for the handler
                int index = id - 1;
                utilityNode.AddFunction(id++, item.Name, null, null, (GlowValue[] _) =>
                {
                    SetActiveByIndex(index);
                    return Task.FromResult(Array.Empty<GlowValue>());
                });
            }




            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(config));
        }
    }
}