using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PS.Infrastructure.Interfaces.Repository;
using PS.Infrastructure.Models;

namespace PS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetricasController : ControllerBase
    {
        private readonly IMetricasRepository _repo;

        public MetricasController(IMetricasRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metrica>>> GetAll()
        {
            var metricas = await _repo.ObtenerTodasAsync();
            return Ok(metricas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Metrica>> GetById(Guid id)
        {
            var metrica = await _repo.ObtenerPorIdAsync(id);
            if (metrica == null) return NotFound();
            return Ok(metrica);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Metrica metrica)
        {
            metrica.Id = Guid.NewGuid();
            metrica.FechaRegistro = DateTime.UtcNow;
            metrica.FechaModificacion = DateTime.UtcNow;
            metrica.Usuario = Guid.Empty;
            await _repo.CrearAsync(metrica);
            return CreatedAtAction(nameof(GetById), new { id = metrica.Id }, metrica);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Metrica metrica)
        {
            if (id != metrica.Id) return BadRequest();
            metrica.FechaModificacion = DateTime.UtcNow;
            await _repo.ActualizarAsync(metrica);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repo.EliminarAsync(id);
            return NoContent();
        }
    }
}
