using System.Runtime.InteropServices.Marshalling;

namespace zadanierekrutacyjne
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            var catFact = new CatFact(new HttpClient());
            var response = await catFact.GetCatFactAsync();
            var text = response.Fact;
            string projectDir = AppDomain.CurrentDomain.BaseDirectory;
            while (!File.Exists(Path.Combine(projectDir, "zadanierekrutacyjne.csproj")) && projectDir != Path.GetPathRoot(projectDir))
                projectDir = Directory.GetParent(projectDir).FullName;
            await File.AppendAllLinesAsync(Path.Combine(projectDir, "catfacts.txt"), new[] { text });

            



            Console.WriteLine(text);

        }
    }
}