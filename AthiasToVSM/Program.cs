using EmberLib.Glow;
using EmberPlusProviderClassLib;
using EmberPlusProviderClassLib.EmberHelpers;
using System.Net.Http;
using System.Net.Http.Json;

namespace AthiasToVSM
{
    internal class Program
    {
        static string[] asset = new string[] { "9853158885094f329329ab359fb856b7", "fe657d2c65e148c5b9a0fa8d50e13445", "2b2a6b37cffd4f299f39e4963689a9c5", "ef7cefdb7cde431ba58759633229b1bd" };



    // ...

    static async Task PatchAssetAsync(int index, object payload)
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Patch, $"http://10.31.11.220/api/v2/assets/{asset[index]}")
        {
            Content = JsonContent.Create(payload)
        };
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

        static void SetActive(int index)
        {
            for (int i = 0; i < asset.Length; i++)
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
        
        private static async Task<GlowValue[]> Kamerarajz(GlowValue[] arg)
        {
            SetActive(0);
            return Array.Empty<GlowValue>();
        }
        private static async Task<GlowValue[]> OCP(GlowValue[] arg)
        {
            SetActive(1);
            return Array.Empty<GlowValue>();
        }

        private static async Task<GlowValue[]> Idokep(GlowValue[] arg)
        {
            SetActive(2);
            return Array.Empty<GlowValue>();
        }
        private static async Task<GlowValue[]> Ido(GlowValue[] arg)
        {
            SetActive(3);
            return Array.Empty<GlowValue>();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initiate EmBER+ tree
            var _emberTree = new EmberPlusProvider(
                9091,
                "Athias controller",
                "Athias controller");

            _emberTree.CreateIdentityNode(
                1,
                "Athias",
                "Athias controller",
                "HBJ",
                "v1.0.0");

            // General utility node
            var utilityNode = _emberTree.AddChildNode(2,"pages");
            utilityNode.AddFunction(1, "OCP",null, null, OCP);
            utilityNode.AddFunction(2, "Idokep", null, null, Idokep);
            utilityNode.AddFunction(3, "Ido", null, null, Ido);
            utilityNode.AddFunction(4, "DCP", null, null, Kamerarajz);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}