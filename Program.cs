using System.Text.Json;

namespace JellyfinCLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {           
            JellyfinApi api = new JellyfinApi();

            if (args.Length > 0 && args[0].ToLower() == "scheduledtasks")
            {
                var json = await api.InvokeJellyfinApi("scheduledtasks", "get", "");
                List<TaskInfo>? result = JsonSerializer.Deserialize<List<TaskInfo>>(json);
                string jsonOutput = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(jsonOutput);
            }
        }
    }
}
