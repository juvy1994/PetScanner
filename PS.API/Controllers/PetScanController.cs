using Microsoft.AspNetCore.Mvc;

using PS.Infrastructure.DTOs;
using PS.Infrastructure.Interfaces;
using PS.Infrastructure.Interfaces.Repository;
using PS.Infrastructure.Models;

namespace PS.API.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetScanController : ControllerBase
    {
        private readonly IImageAnalysisService _imageService;
        private readonly IChatService _chatService;
        private readonly IOpenAiVisionService _aiVisionService;
        private readonly IMetricasRepository _metricasRepo;

        public PetScanController(IImageAnalysisService imageService, IChatService chatService, IOpenAiVisionService aiVisionService, IMetricasRepository metricasRepo)
        {
            _imageService = imageService;
            _chatService = chatService;
            _aiVisionService = aiVisionService;
            _metricasRepo = metricasRepo;
        }

        [HttpPost("scan")]
        public async Task<IActionResult> ScanOpenAI([FromForm] ScanOpenAIRequest request)
        {
            var imageUrl = await _imageService.UploadToBlobAsync(request.Photo);
            var breed = await _aiVisionService.DetectBreedFromImageAsync(imageUrl);
            var petInfo = await _chatService.GetPetDescriptionAsync(breed);

            if (petInfo == null)
            {
                return Ok(new
                {
                    breed,
                    description = "Error al obtener descripción"
                });
            }
            petInfo.UrlImage = imageUrl ?? string.Empty;

            await _metricasRepo.CrearAsync(new Metrica
            {
                Id = Guid.NewGuid(),
                Especie = petInfo.especie,
                NombreRaza = petInfo.nombre_raza,
                Origen = petInfo.origen,
                Usuario = Guid.Empty,
                FechaRegistro = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow,
                Estado = true
            });


            return Ok(petInfo);
        }
    }
}
