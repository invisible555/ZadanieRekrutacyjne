using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace zadanierekrutacyjne
{
    internal class CatFact : ICatFact
    {
        private const string urlAddress = "https://catfact.ninja/fact";
        private readonly HttpClient _httpClient;
        public CatFact(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
      

        public async Task<CatFactResponse> GetCatFactAsync()
        {
            var catFact = await _httpClient.GetAsync(urlAddress);
            if (!catFact.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching cat fact: {catFact.StatusCode}");
            }
            var jsonObject = await catFact.Content.ReadAsStringAsync();
            var fact = JsonSerializer.Deserialize<CatFactResponse>(jsonObject);


            return fact;
        }
    }
}
