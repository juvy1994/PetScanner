using PS.API;
using PS.Core.Interfaces;
using PS.Core.Models;
using PS.Infrastructure.DTOs;
using PS.Infrastructure.Repositories;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Test.TestDB
{
    public class TestMascotaSync
    {
        /*
        private SQLiteConnection _connection;
        private MascotaRepository _mascotaRepository;
        private IMascotaFirebaseService _mascotaFirebaseService;

        public TestMascotaSync()
        {
            // 🧱 Crear la base de datos SQLite en memoria
            _connection = new SQLiteConnection(":memory:");
            _connection.CreateTable<MascotaDTO>();

            // 📦 Crear el repositorio real con la base SQLite
            _mascotaRepository = new MascotaRepository(_connection);

            // ☁️ Crear una implementación simulada de Firebase
            _mascotaFirebaseService = new MascotaFirebaseServiceSimulado();
        }

        [Fact]
        public async Task SincronizarMascotas_MarcaComoSincronizado()
        {
            // Arrange
            var mascota = new MascotaModel
            {
                Id = "m001",
                Nombre = "Firulais",
                Especie = "Perro",
                Origen = "Adoptado",
                Descripcion = "Muy juguetón",
                Comportamiento = "Amigable",
                Alimentacion = "Croquetas",
                CuidadosEspeciales = "Ninguno",
                EnfermedadesComunes = "Pulgas",
                UsuarioId = "u001",
                Sincronizado = false
            };

            _mascotaRepository.Add(mascota); // Guardamos en SQLite

            var syncService = new Servicioss(
                usuarioRepository: null,
                mascotaRepository: _mascotaRepository,
                usuarioFirebaseService: null,
                mascotaFirebaseService: _mascotaFirebaseService
            );

            // Act
            await syncService.SincronizarMascotasAsync(); // Ejecutamos la sincronización

            var mascotaSincronizada = _mascotaRepository.GetById("m001");

            // Assert
            Assert.NotNull(mascotaSincronizada);
            Assert.True(mascotaSincronizada.Sincronizado); // 🔍 Verificamos que se marcó como sincronizado
        }

        public class MascotaFirebaseServiceSimulado : IMascotaFirebaseService
        {
            public Task DeleteMascotaAsync(string id)
            {
                throw new NotImplementedException();
            }

            public Task<List<MascotaModel>> GetMascotasAsync()
            {
                throw new NotImplementedException();
            }

            public Task<bool> SaveMascotaAsync(MascotaModel mascota)
            {
                Console.WriteLine($"[Firebase] Mascota sincronizada: {mascota.Nombre} (Id: {mascota.Id})");
                return Task.FromResult(true);
            }

            Task IMascotaFirebaseService.SaveMascotaAsync(MascotaModel mascota)
            {
                return SaveMascotaAsync(mascota);
            }
        }
        */
    }
}
