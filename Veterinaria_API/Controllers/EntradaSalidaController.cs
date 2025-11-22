using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Data;
using VeterinariaApi.Models;

namespace VeterinariaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntradaSalidaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntradaSalidaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntradaSalida>>> Get()
        {
            return await _context.EntradasSalidas.OrderByDescending(e => e.FechaEntrada).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<EntradaSalida>> Post(EntradaSalida registro)
        {
            _context.EntradasSalidas.Add(registro);
            await _context.SaveChangesAsync();
            return Ok(registro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registro = await _context.EntradasSalidas.FindAsync(id);
            if (registro == null)
                return NotFound();

            _context.EntradasSalidas.Remove(registro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
