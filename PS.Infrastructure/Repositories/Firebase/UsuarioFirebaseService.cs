using Firebase.Database;
using Firebase.Database.Query;
using PS.Core.Interfaces;
using PS.Core.Models;
using PS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Repositories.Firebase
{
    public class UsuarioFirebaseService : BaseFirebaseService<UsuarioModel>, IUsuarioFirebaseService
    {
        public UsuarioFirebaseService(FirebaseClient firebaseClient)
           : base(firebaseClient, "usuarios")
        {
        }
    }
}
