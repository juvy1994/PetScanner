using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Interfaces
{
    public interface IImageAnalysisService
    {
        Task<string> UploadToBlobAsync(IFormFile file);
        Task<string> AnalysizeBreedFromImageUrlAsync(string imageUrl);
    }
}
