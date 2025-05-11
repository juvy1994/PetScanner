using PS.Core.Interfaces;
using PS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.UI.Maui.Services
{
    public class SyncService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IUsuarioFirebaseService _usuarioFirebaseService;
        private readonly IMascotaFirebaseService _mascotaFirebaseService;

        public SyncService(
            IUsuarioRepository usuarioRepository,
            IMascotaRepository mascotaRepository,
            IUsuarioFirebaseService usuarioFirebaseService,
            IMascotaFirebaseService mascotaFirebaseService)
        {
            _usuarioRepository = usuarioRepository;
            _mascotaRepository = mascotaRepository;
            _usuarioFirebaseService = usuarioFirebaseService;
            _mascotaFirebaseService = mascotaFirebaseService;
        }

    
    }
}
