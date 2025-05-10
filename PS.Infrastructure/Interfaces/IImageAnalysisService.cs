using Microsoft.AspNetCore.Http;

namespace PS.Infrastructure.Interfaces
{
    public interface IImageAnalysisService
    {
        Task<string> UploadToBlobAsync(IFormFile file);
    }
}
