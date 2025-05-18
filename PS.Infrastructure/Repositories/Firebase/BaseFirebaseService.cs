using Firebase.Database;
using Firebase.Database.Query;
using PS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Repositories.Firebase
{
    public class BaseFirebaseService<T> : IBaseFirebaseService<T> where T : class
    {
        private readonly FirebaseClient _firebaseClient;
        private readonly string _collectionName;

        public BaseFirebaseService(FirebaseClient firebaseClient, string collectionName)
        {
            _firebaseClient = firebaseClient;
            _collectionName = collectionName;
        }

        public async Task DeleteAsync(string id)
        {
            var item = (await _firebaseClient
               .Child(_collectionName)
               .OnceAsync<T>())
               .FirstOrDefault(a => (a.Object as dynamic)?.Id == id);

            if (item != null)
            {
                await _firebaseClient
                    .Child(_collectionName)
                    .Child(item.Key)
                    .DeleteAsync();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return (await _firebaseClient
               .Child(_collectionName)
               .OnceAsync<T>())
               .Select(item => item.Object)
               .ToList();
        }

        public async Task SaveAsync(T entity)
        {
            await _firebaseClient
                .Child(_collectionName)
                .PostAsync(entity);
        }
    }
}
