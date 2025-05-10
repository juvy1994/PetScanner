using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using PS.Infrastructure.Interfaces;
using PS.Infrastructure.Mocks;

using System.Net.Http.Headers;
using System.Text;

namespace PS.Infrastructure.Services
{
    public class ChatService : IChatService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _assistantId;
        private readonly bool _useMocks;

        public ChatService(IConfiguration config)
        {
            _config = config;
            _apiKey = _config["OpenAI:ApiKey"];
            _assistantId = _config["OpenAI:VeterinariaAssistantId"];
            _useMocks = bool.TryParse(_config["UseMocks"], out var mock) && mock;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.openai.com/v1/")
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants=v2");
        }

        public async Task<PetBreedInfoDto?> GetPetDescriptionAsync(string breed)
        {
            if (_useMocks)
            {
                return await GetDevPetDescriptionAsync(breed);
            }
            else
            {
                return await GetProdPetDescriptionAsync(breed);
            }
        }

        private async Task<PetBreedInfoDto?> GetDevPetDescriptionAsync(string breed)
        {
            var delay = new Random().Next(10000, 21000); 
            await Task.Delay(delay);

            return PetBreedInfoMockGenerator.Generate(breed);
        }

        private async Task<PetBreedInfoDto?> GetProdPetDescriptionAsync(string breed)
        {
            var threadResponse = await _httpClient.PostAsync("threads", new StringContent("{}", Encoding.UTF8, "application/json"));
            var threadJson = await threadResponse.Content.ReadAsStringAsync();
            var threadId = JObject.Parse(threadJson)["id"]?.ToString();

            var message = new
            {
                role = "user",
                content = $"Dame una descripción y recomendaciones para la raza {breed}"
            };

            var messageResponse = await _httpClient.PostAsync(
                $"threads/{threadId}/messages",
                new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
            );

            var run = new { assistant_id = _assistantId };

            var runResponse = await _httpClient.PostAsync(
                $"threads/{threadId}/runs",
                new StringContent(JsonConvert.SerializeObject(run), Encoding.UTF8, "application/json")
            );

            var runJson = await runResponse.Content.ReadAsStringAsync();
            var runId = JObject.Parse(runJson)["id"]?.ToString();

            string runStatus = "queued";
            int maxAttempts = 30;
            int attempt = 0;

            while ((runStatus == "queued" || runStatus == "in_progress") && attempt < maxAttempts)
            {
                await Task.Delay(1000);
                var checkResponse = await _httpClient.GetAsync($"threads/{threadId}/runs/{runId}");
                var checkJson = await checkResponse.Content.ReadAsStringAsync();

                if (JObject.Parse(checkJson)["status"]?.ToString() == "failed")
                {
                    var runDetails = JObject.Parse(checkJson);
                    var errorMessage = runDetails["last_error"]?["message"]?.ToString();
                    var errorCode = runDetails["last_error"]?["code"]?.ToString();
                    Console.WriteLine($"Error OpenAI: {errorCode} - {errorMessage}");
                    return null;
                }

                runStatus = JObject.Parse(checkJson)["status"]?.ToString();
                attempt++;
            }

            if (runStatus != "completed")
                return null;

            var messagesResponse = await _httpClient.GetAsync($"threads/{threadId}/messages");
            var messagesJson = await messagesResponse.Content.ReadAsStringAsync();
            var allMessages = JObject.Parse(messagesJson)["data"];

            var lastMessage = allMessages?
                .FirstOrDefault(m => m["role"]?.ToString() == "assistant");

            var contentArray = lastMessage?["content"] as JArray;
            var content = contentArray?[0]?["text"]?["value"]?.ToString();

            if (string.IsNullOrWhiteSpace(content))
                return null;

            try
            {
                var petInfo = JsonConvert.DeserializeObject<PetBreedInfoDto>(content);
                return petInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al deserializar JSON del assistant: " + ex.Message);
                return null;
            }
        }

    }
}
