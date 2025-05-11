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
    public class TestUsuario
    {
        /*
        private SQLiteConnection _connection;
        private UsuarioRepository _usuarioRepository;


        public TestUsuario()
        {
            // Crear una nueva conexión SQLite en memoria para las pruebas
            _connection = new SQLiteConnection(":memory:");
            _usuarioRepository = new UsuarioRepository(_connection);

            // Crear la tabla de usuarios en la base de datos SQLite
            _connection.CreateTable<UsuarioDTO>();
        }

        [Fact]
        public void AddUsuario_DevuelveIdValido()
        {
            // Arrange
            var usuario = new UsuarioModel { Id = "123", Nombre = "Juan", Estado = true, Sincronizado = false };

            // Act
            var resultado = _usuarioRepository.Add(usuario);
            var usuarioGuardado = _usuarioRepository.GetById("123");

            // Assert
            Assert.Equal(1, resultado); // La operación de inserción debería devolver 1
            Assert.NotNull(usuarioGuardado); // El usuario guardado no debe ser nulo
            Assert.Equal("Juan", usuarioGuardado.Nombre); // Verificar que el nombre sea correcto
        }
        

        [Fact]
        public void GetAllUsuarios_DevuelveUsuarios()
        {
            // Arrange
            var usuario1 = new UsuarioModel { Id = "123", Nombre = "Juan", Estado = true, Sincronizado = false };
            var usuario2 = new UsuarioModel { Id = "124", Nombre = "Pedro", Estado = true, Sincronizado = true };
            _usuarioRepository.Add(usuario1);
            _usuarioRepository.Add(usuario2);

            // Act
            var usuarios = _usuarioRepository.GetAll();
            foreach (var usuario in usuarios) {
                Console.WriteLine(usuario.Id + "--" + usuario.Nombre);
            }

            // Assert
            Assert.Equal(2, usuarios.Count); // Debería devolver 2 usuarios
            Assert.Contains(usuarios, u => u.Nombre == "Juan");
            Assert.Contains(usuarios, u => u.Nombre == "Pedro");
        }
        

        [Fact]
        public void DeleteUsuario_DevuelveTrue()
        {
            // Arrange
            var usuario = new UsuarioModel { Id = "123", Nombre = "Juan", Estado = true, Sincronizado = false };
            _usuarioRepository.Add(usuario);

            // Act
            var resultado = _usuarioRepository.Delete(usuario);

            // Assert
            Assert.Equal(1, resultado); // La operación de eliminación debe devolver 1
            var usuarioEliminado = _usuarioRepository.GetById("123");
            Assert.Null(usuarioEliminado); // Verificamos que el usuario ya no exista
        }
        */
        
    }

}
