using PS.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Data
{
    public class SQLiteDbContext
    {
        private readonly SQLiteAsyncConnection _connection;

        public SQLiteAsyncConnection Connection => _connection;

        public SQLiteDbContext(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<UsuarioModel>().Wait();
            _connection.CreateTableAsync<MascotaModel>().Wait();
            _connection.CreateTableAsync<EnfermedadComunModel>().Wait();
        }
    }
}
