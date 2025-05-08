using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Interfaces
{
    public interface IChatService
    {
        Task<string> GetPetDescriptionAsync(string breed);
    }
}
