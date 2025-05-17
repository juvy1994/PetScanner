using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PS.UI.Maui.Services
{
    public class HttpClienteService
    {
        private readonly HttpClient _httpClient;


        public HttpClienteService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://petscan-hkbtgngtbecxf5ag.centralus-01.azurewebsites.net/api/pets/scan")
            };

        }

        public async Task<PetBreedInfoDto> EnviarFotoAsync(FileResult foto)
        {
            var stream = await foto.OpenReadAsync();
            var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            content.Add(fileContent, "Photo", foto.FileName);

            var response = await _httpClient.PostAsync("scan", content);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var resultado = JsonSerializer.Deserialize<PetBreedInfoDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return resultado;
        }
    }
}
