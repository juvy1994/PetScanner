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
    public class UsuarioFirebaseService : IUsuarioFirebaseService
    {
        private readonly FirebaseClient _firebaseClient;

        public UsuarioFirebaseService()
        {
            _firebaseClient = new FirebaseClient("https://petscannerdb-default-rtdb.firebaseio.com/");
        }

        public async Task DeleteUsuarioAsync(string id)
        {
            await _firebaseClient
                .Child("usuarios")
                .Child(id)
                .DeleteAsync();
        }

        public async Task<List<UsuarioModel>> GetUsuariosAsync()
        {
            var usuarios = await _firebaseClient
               .Child("usuarios")
               .OnceAsync<UsuarioModel>();

            return usuarios.Select(u =>
            {
                var usuario = u.Object;
                usuario.Id = u.Key;
                return usuario;
            }).ToList();
        }

        public async Task SaveUsuarioAsync(UsuarioModel usuario)
        {
            await _firebaseClient
               .Child("usuarios")
               .Child(usuario.Id)
               .PutAsync(usuario);
        }
    }
}
