using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyfinCLI
{
    internal class JellyfinApi
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
            .Build();

        internal string GetAuthorizationHeaderString()
        {
            string version = "1.0.1";
            string client = "DotNetCliApp";
            string device = Environment.GetEnvironmentVariable("computername") ?? string.Empty;
            string deviceId = Guid.NewGuid().ToString();
            string token = config["AppSettings:JellyfinApiKey"] ?? string.Empty;
            return $"MediaBrowser Client={client}, Device={device}, DeviceId={deviceId}, Version={version}, Token={token}";
        }

    internal async Task<string> InvokeJellyfinApi(string route, string method, string? body)
        {
            string jellyfinResponse = string.Empty;
            
            string server = config["AppSettings:JellyfinServer"] ?? string.Empty;
            string url = $"{server}/jellyfin/{route}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", GetAuthorizationHeaderString());

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        if (responseBody != null)
                        {
                            jellyfinResponse = responseBody;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Request Failed.  Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Request error: {ex.Message}");
                }
            }
            return jellyfinResponse;
        }
    }
}
