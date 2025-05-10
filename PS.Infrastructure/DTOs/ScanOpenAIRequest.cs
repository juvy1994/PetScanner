using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PS.Infrastructure.DTOs
{
    public class ScanOpenAIRequest
    {
        [FromForm(Name = "photo")]
        public IFormFile Photo { get; set; }
    }
}
