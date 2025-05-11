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
    public class TestMascota
    {
        /*
        private SQLiteConnection _connection;
        private MascotaRepository _mascotaRepository;

        public TestMascota()
        {
            // Crear una nueva conexión SQLite en memoria para las pruebas
            _connection = new SQLiteConnection(":memory:");
            _mascotaRepository = new MascotaRepository(_connection);

            // Crear la tabla de usuarios en la base de datos SQLite
            _connection.CreateTable<MascotaDTO>();

        }
        
        [Fact]
        public void AddMascota_DevuelveIdValido()
        {
            // Arrange
            var mascota = new MascotaModel { Id = "001", Nombre = "Firulais", Especie = "Perro", UsuarioId = "123" };

            // Act
            var resultado = _mascotaRepository.Add(mascota);
            var mascotaGuardada = _mascotaRepository.GetById("001");

            // Assert
            Assert.Equal(1, resultado); // Verificamos que se insertó correctamente
            Assert.NotNull(mascotaGuardada); // Verificamos que la mascota esté guardada
            Assert.Equal("Firulais", mascotaGuardada.Nombre); // Verificamos que el nombre sea correcto
        }

        [Fact]
        public void UpdateMascota_CambiaNombre()
        {
            var mascota = CrearMascota("003", "Lucas");
            _mascotaRepository.Add(mascota);

            mascota.Nombre = "Lucas Actualizado";
            var actualizado = _mascotaRepository.Update(mascota);

            var resultado = _mascotaRepository.GetById("003");

            Assert.Equal(1, actualizado);
            Assert.Equal("Lucas Actualizado", resultado.Nombre);
        }

        [Fact]
        public void DeleteMascota_EliminaCorrectamente()
        {
            var mascota = CrearMascota("004", "Rocky");
            _mascotaRepository.Add(mascota);

            var eliminado = _mascotaRepository.Delete(mascota);
            var buscada = _mascotaRepository.GetById("004");

            Assert.Equal(1, eliminado);
            Assert.Null(buscada);
        }

        [Fact]
        public void GetByUsuarioId_DevuelveMascotasDelUsuario()
        {
            _mascotaRepository.Add(CrearMascota("005", "Perla", "U1"));
            _mascotaRepository.Add(CrearMascota("006", "Bella", "U1"));
            _mascotaRepository.Add(CrearMascota("007", "Nala", "U2"));

            var delUsuarioU1 = _mascotaRepository.GetByUsuarioId("U1");

            Assert.Equal(2, delUsuarioU1.Count);
        }

        
        private MascotaModel CrearMascota(string id = "001", string nombre = "Firulais", string usuarioId = "123")
        {
            return new MascotaModel
            {
                Id = id,
                Nombre = nombre,
                Especie = "Perro",
                Origen = "Local",
                Descripcion = "Amigable",
                Comportamiento = "Juguetón",
                Alimentacion = "Croquetas",
                CuidadosEspeciales = "Ninguno",
                EnfermedadesComunes = "Ninguna",
                UrlImage = "https://url.com/foto.jpg",
                Estado = true,
                Sincronizado = false,
                UsuarioId = usuarioId
            };

        }
        */
    }
}
