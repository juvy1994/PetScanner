using Firebase.Database;
using Firebase.Database.Query;
using PS.Core.Interfaces;
using PS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Repositories
{
    public class MascotaFirebaseService : IMascotaFirebaseService
    {
        private readonly FirebaseClient _firebaseClient;

        public MascotaFirebaseService()
        {
            _firebaseClient = new FirebaseClient("https://petscannerdb-default-rtdb.firebaseio.com/");
        }

        public async Task DeleteMascotaAsync(string id)
        {
            await _firebaseClient
              .Child("mascotas")
              .Child(id)
              .DeleteAsync();
        }

        public async Task<List<MascotaModel>> GetMascotasAsync()
        {
            var mascotas = await _firebaseClient
               .Child("mascotas")
               .OnceAsync<MascotaModel>();

            return mascotas.Select(m =>
            {
                var mascota = m.Object;
                mascota.Id = m.Key;
                return mascota;
            }).ToList();
        }

        public async Task SaveMascotaAsync(MascotaModel mascota)
        {
            await _firebaseClient
               .Child("mascotas")
               .Child(mascota.Id)
               .PutAsync(mascota);
        }
    }
}
