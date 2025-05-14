using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMotoZone.API.Data;
using SmartMotoZone.API.Models;

namespace SmartMotoZone.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        // GET: api/moto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetMotos()
        {
            return await _context.Motos.ToListAsync();
        }

        // GET: api/moto/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetMoto(int id)
        {
            var moto = await _context.Motos.FindAsync(id);

            if (moto == null)
            {
                return NotFound();
            }
           
            return moto;
        }

        // GET: api/moto/zona/{zona}
        [HttpGet("zona/{zona}")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetMotosPorZona(string zona)
        {
            var motos = await _context.Motos
                .Where(m => m.ZonaAtual.ToLower() == zona.ToLower())
                .ToListAsync();

            if (!motos.Any())
            {
                return NotFound("Nenhuma moto encontrada nesta zona.");
            }

            return Ok(motos);
        }

        // GET: api/moto/status?status=Disponível
        [HttpGet("status")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetMotosPorStatus([FromQuery] string status)
        {
            var motos = await _context.Motos
                .Where(m => m.Status.ToLower() == status.ToLower())
                .ToListAsync();

            if (!motos.Any())
            {
                return NotFound("Nenhuma moto encontrada com esse status.");
            }

            return Ok(motos);
        }

        // POST: api/moto
        [HttpPost]
        public async Task<ActionResult<Moto>> PostMoto(Moto moto)
        {
            moto.UltimaAtualizacao = DateTime.UtcNow;

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMoto), new { id = moto.Id }, moto);
        }

        // PUT: api/moto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoto(int id, Moto moto)
        {
            if (id != moto.Id)
            {
                return BadRequest();
            }

            var motoExistente = await _context.Motos.FindAsync(id);
            if (motoExistente == null)
            {
                return NotFound();
            }

            motoExistente.Modelo = moto.Modelo;
            motoExistente.Placa = moto.Placa;
            motoExistente.Status = moto.Status;
            motoExistente.ZonaAtual = moto.ZonaAtual;
            motoExistente.UltimaAtualizacao = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/moto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoto(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotoExists(int id)
        {
            return _context.Motos.Any(e => e.Id == id);
        }
    }
}