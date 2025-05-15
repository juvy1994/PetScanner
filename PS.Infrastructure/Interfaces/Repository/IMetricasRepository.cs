using PS.Infrastructure.Models;

namespace PS.Infrastructure.Interfaces.Repository
{
    public interface IMetricasRepository
    {
        Task<List<Metrica>> ObtenerTodasAsync();
        Task<Metrica?> ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Metrica metrica);
        Task ActualizarAsync(Metrica metrica);
        Task EliminarAsync(Guid id);
    }
}
