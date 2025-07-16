using System.Runtime.InteropServices.Marshalling;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace zadanierekrutacyjne
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddScoped<ICatFact, CatFact>();
            builder.Services.AddSingleton<HttpClient>();
            using IHost host = builder.Build();

            var catFact = host.Services.GetRequiredService<ICatFact>();
            var response = await catFact.GetCatFactAsync();
            var text = response.Fact;
            await SaveFactToProjectFolderAsync("zadanierekrutacyjne.csproj", "catfacts.txt", text);

            Console.WriteLine(text);

        }
        private static async Task SaveFactToProjectFolderAsync(string csprojName, string fileName, string content)
        {
            string projectDir = AppDomain.CurrentDomain.BaseDirectory;
            while (!File.Exists(Path.Combine(projectDir, csprojName)) && projectDir != Path.GetPathRoot(projectDir))
                projectDir = Directory.GetParent(projectDir).FullName;

            string filePath = Path.Combine(projectDir, fileName);
            await File.AppendAllLinesAsync(filePath, new[] { content });
        }
    }
}