using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Data;
using VeterinariaApi.Models;

namespace VeterinariaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MascotaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascota>>> Get()
        {
            return await _context.Mascotas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Mascota>> Post(Mascota mascota)
        {
            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();
            return Ok(mascota);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Mascota mascota)
        {
            if (id != mascota.Id)
                return BadRequest();

            var existente = await _context.Mascotas.FindAsync(id);
            if (existente == null)
                return NotFound();

            existente.Nombre = mascota.Nombre;
            existente.Especie = mascota.Especie;
            existente.Raza = mascota.Raza;
            existente.Edad = mascota.Edad;
            existente.FotoPath = mascota.FotoPath;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
                return NotFound();

            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
