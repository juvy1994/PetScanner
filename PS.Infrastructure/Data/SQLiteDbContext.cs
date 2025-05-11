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
        private readonly SQLiteConnection _connection;

        public SQLiteConnection Connection => _connection;

        public SQLiteDbContext(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<UsuarioModel>();
            _connection.CreateTable<MascotaModel>();
        }
    }
}
