using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Data;
using VeterinariaApi.Models;

namespace VeterinariaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialMedicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialMedicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialMedico>>> Get()
        {
            return await _context.HistorialesMedicos.ToListAsync();
        }

        [HttpGet("por-mascota/{nombre}")]
        public async Task<ActionResult<IEnumerable<HistorialMedico>>> GetPorMascota(string nombre)
        {
            return await _context.HistorialesMedicos
                .Where(h => h.NombreMascota == nombre)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<HistorialMedico>> Post(HistorialMedico historial)
        {
            _context.HistorialesMedicos.Add(historial);
            await _context.SaveChangesAsync();
            return Ok(historial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var historial = await _context.HistorialesMedicos.FindAsync(id);
            if (historial == null)
                return NotFound();

            _context.HistorialesMedicos.Remove(historial);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
