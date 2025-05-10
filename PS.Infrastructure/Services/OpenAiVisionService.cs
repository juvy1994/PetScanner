using Microsoft.Extensions.Configuration;

using Newtonsoft.Json.Linq;

using PS.Infrastructure.Interfaces;
using PS.Infrastructure.Shared;

using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PS.Infrastructure.Services
{
    public class OpenAiVisionService: IOpenAiVisionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly bool _useMocks;
        private readonly Random _random = new();

        public OpenAiVisionService(IConfiguration configuration)
        {
            _apiKey = configuration["OpenAI:ApiKey"];
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.openai.com/v1/")
            };

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);

            _useMocks = bool.TryParse(configuration["UseMocks"], out var mock) && mock;
        }

        public async Task<string> DetectBreedFromImageAsync(string imageUrl)
        {
            if (_useMocks)
            {
                return await DetectDevBreedFromImageAsync(imageUrl);
            }
            else
            {
                return await DetectProdBreedFromImageAsync(imageUrl);
            }
        }

        private async Task<string> DetectDevBreedFromImageAsync(string imageUrl)
        {
            var esGato = _random.Next(0, 2) == 0;
            var raza = esGato
                ? BreedData.RazasGatos[_random.Next(BreedData.RazasGatos.Length)]
                : BreedData.RazasPerros[_random.Next(BreedData.RazasPerros.Length)];

            var delay = _random.Next(500, 2000);
            await Task.Delay(delay);

            return $"Mockup Data - {raza}";
        }

        private async Task<string> DetectProdBreedFromImageAsync(string imageUrl)
        {
            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                new
                {
                    role = "user",
                    content = new object[]
                    {
                        new { type = "text", text = "¿Qué raza de animal aparece en esta imagen? Solo responde con el nombre exacto de la raza y si no sabes que raza es, responde con una raza aproximada. Ejemplo: 'Maine Coon'." },
                        new { type = "image_url", image_url = new { url = imageUrl } }
                    }
                }
            },
                max_tokens = 50
            };

            var response = await _httpClient.PostAsJsonAsync("chat/completions", requestBody);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return "Desconocido";
            }

            var json = await response.Content.ReadAsStringAsync();
            var parsed = JObject.Parse(json);
            var answer = parsed["choices"]?[0]?["message"]?["content"]?.ToString()?.Trim();

            return answer ?? "Desconocido";
        }
    }
}
