using PS.UI.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.UI.Maui.ViewModels
{
    public class WaitingViewModel
    {
        private readonly HttpClienteService _httpClienteService;
        public FileResult FotoParaEnviar { get; set; }

        public WaitingViewModel(HttpClienteService httpClienteService)
        {
            _httpClienteService = httpClienteService;
        }

        public async Task<PetBreedInfoDto> ProcesarImagen()
        {
            if (FotoParaEnviar == null)
                return null;

            var resultado = await _httpClienteService.EnviarFotoAsync(FotoParaEnviar);
            return resultado;
        }

    }
}
