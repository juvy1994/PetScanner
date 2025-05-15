using Microsoft.EntityFrameworkCore;

using PS.Infrastructure.Models;

namespace PS.Infrastructure.Data
{
    public class PetScanDbContext : DbContext
    {
        public PetScanDbContext(DbContextOptions<PetScanDbContext> options) : base(options) { }

        public DbSet<Metrica> Metricas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Metrica>(entity =>
            {
                entity.ToTable("metricas");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.NombreRaza).HasColumnName("nombre_raza");
                entity.Property(e => e.Especie).HasColumnName("especie");
                entity.Property(e => e.Origen).HasColumnName("origen");
                entity.Property(e => e.Usuario).HasColumnName("usuario");
                entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
                entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
                entity.Property(e => e.Estado).HasColumnName("estado");
            });
            modelBuilder.Entity<Metrica>().HasKey(m => m.Id);
        }
    }
}
