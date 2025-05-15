using Microsoft.EntityFrameworkCore;

using PS.Infrastructure.Data;
using PS.Infrastructure.Interfaces.Repository;
using PS.Infrastructure.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure.Repositories.SqlServer
{
    public class MetricasRepository : IMetricasRepository
    {
        private readonly PetScanDbContext _context;

        public MetricasRepository(PetScanDbContext context)
        {
            _context = context;
        }

        public async Task<List<Metrica>> ObtenerTodasAsync()
        {
            return await _context.Metricas.ToListAsync();
        }

        public async Task<Metrica?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Metricas.FindAsync(id);
        }

        public async Task CrearAsync(Metrica metrica)
        {
            _context.Metricas.Add(metrica);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Metrica metrica)
        {
            _context.Metricas.Update(metrica);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var metrica = await _context.Metricas.FindAsync(id);
            if (metrica is not null)
            {
                _context.Metricas.Remove(metrica);
                await _context.SaveChangesAsync();
            }
        }
    }
}
