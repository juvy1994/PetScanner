using Microsoft.AspNetCore.Mvc;

using PS.Infrastructure.DTOs;
using PS.Infrastructure.Interfaces;

namespace PS.API.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetScanController : ControllerBase
    {
        private readonly IImageAnalysisService _imageService;
        private readonly IChatService _chatService;
        private readonly IOpenAiVisionService _aiVisionService;

        public PetScanController(IImageAnalysisService imageService, IChatService chatService, IOpenAiVisionService aiVisionService)
        {
            _imageService = imageService;
            _chatService = chatService;
            _aiVisionService = aiVisionService;
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
            return Ok(petInfo);
        }
    }
}
