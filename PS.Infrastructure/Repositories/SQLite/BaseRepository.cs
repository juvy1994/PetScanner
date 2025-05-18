using PS.Core.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Repositories.SQLite
{
    public class BaseRepository<T> : IBaseRepository<T> where T : new()
    {
        protected readonly SQLiteAsyncConnection _connection;

        public BaseRepository(SQLiteAsyncConnection connection)
        {
            _connection = connection;
            _connection.CreateTableAsync<T>().Wait();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            return await _connection.InsertAsync(entity);
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            return await _connection.DeleteAsync(entity);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _connection.Table<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _connection.FindAsync<T>(id);
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            return await _connection.UpdateAsync(entity);
        }
    }
}
