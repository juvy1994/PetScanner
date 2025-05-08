using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PS.Infrastructure.Interfaces;
using PS.Infrastructure.Services;

namespace PS.API.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetScanController : ControllerBase
    {
        private readonly IImageAnalysisService _imageService;
        private readonly IChatService _chatService;

        public PetScanController(IImageAnalysisService imageService, IChatService chatService)
        {
            _imageService = imageService;
            _chatService = chatService;
        }
    }
}
