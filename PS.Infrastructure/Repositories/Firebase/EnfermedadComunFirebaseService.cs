using Firebase.Database;
using PS.Core.Interfaces;
using PS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Repositories.Firebase
{ 
    public class EnfermedadComunFirebaseService : BaseFirebaseService<EnfermedadComunModel>, IEnfermedadComunFirebaseService
    {
        public EnfermedadComunFirebaseService(FirebaseClient firebaseClient)
          : base(firebaseClient, "enfermedades_comunes")
        {
        }
    }
}
