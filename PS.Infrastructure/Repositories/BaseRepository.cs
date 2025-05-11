using PS.Core.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : new()
    {
        protected readonly SQLiteConnection _connection;

        public BaseRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<T>();
        }

        public virtual int Add(T entity)
        {
            return _connection.Insert(entity);
        }

        public virtual int Delete(T entity)
        {
            return _connection.Delete(entity);
        }

        public virtual List<T> GetAll()
        {
            return _connection.Table<T>().ToList();
        }

        public virtual T GetById(string id)
        {
            return _connection.Find<T>(id);
        }

        public virtual int Update(T entity)
        {
            return _connection.Update(entity);
        }
    }
}
