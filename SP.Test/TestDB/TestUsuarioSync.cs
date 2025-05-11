using PS.API;
using PS.Core.Interfaces;
using PS.Core.Models;
using PS.Infrastructure.DTOs;
using PS.Infrastructure.Repositories;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Test.TestDB
{
   

    public class TestUsuarioSync
    {
        /*
        private SQLiteConnection _connection;
        private UsuarioRepository _usuarioRepository;
        private IUsuarioFirebaseService _usuarioFirebaseService;

        public TestUsuarioSync()
        {
            // 🧱 Crear la base de datos SQLite en memoria
            _connection = new SQLiteConnection(":memory:");
            _connection.CreateTable<UsuarioDTO>();

            // 📦 Crear el repositorio real con la base SQLite
            _usuarioRepository = new UsuarioRepository(_connection);

            // ☁️ Crear una implementación simulada de Firebase
            _usuarioFirebaseService = new UsuarioFirebaseServiceSimulado();
        }

        [Fact]
        public async Task SincronizarUsuarios_MarcaComoSincronizado()
        {
            // Arrange
            var usuario = new UsuarioModel
            {
                Id = "u001",
                Nombre = "Pedro",
                Estado = true,
                Sincronizado = false
            };

            _usuarioRepository.Add(usuario); // Guardamos en SQLite

            var syncService = new Servicioss(
                _usuarioRepository,
                mascotaRepository: null, // No lo usamos en esta prueba
                _usuarioFirebaseService,
                mascotaFirebaseService: null
            );

            // Act
            await syncService.SincronizarUsuariosAsync(); // Ejecutamos la sincronización

            var usuarioSincronizado = _usuarioRepository.GetById("u001");

            // Assert
            Assert.NotNull(usuarioSincronizado);
            Assert.True(usuarioSincronizado.Sincronizado); // 🔍 Verificamos que se marcó como sincronizado
        }

        public class UsuarioFirebaseServiceSimulado : IUsuarioFirebaseService
        {
            public Task DeleteUsuarioAsync(string id)
            {
                throw new NotImplementedException();
            }

            public Task<List<UsuarioModel>> GetUsuariosAsync()
            {
                throw new NotImplementedException();
            }

            public Task<bool> SaveUsuarioAsync(UsuarioModel usuario)
            {
                Console.WriteLine($"[Firebase] Usuario sincronizado: {usuario.Nombre} (Id: {usuario.Id})");
                return Task.FromResult(true);
            }

            Task IUsuarioFirebaseService.SaveUsuarioAsync(UsuarioModel usuario)
            {
                return SaveUsuarioAsync(usuario);
            }
        }
        */
    }
}

