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
            return await _context.Mascotas.AsNoTracking().ToListAsync();
        }

        [HttpGet("usuario/{usuario}")]
        public async Task<ActionResult<IEnumerable<Mascota>>> GetPorUsuario(string usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario))
                return BadRequest("Usuario requerido.");

            var lista = await _context.Mascotas
                .AsNoTracking()
                .Where(m => m.Usuario == usuario)
                .ToListAsync();

            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<Mascota>> Post([FromBody] Mascota mascota)
        {
            if (mascota == null)
                return BadRequest("Datos inválidos.");

            if (string.IsNullOrWhiteSpace(mascota.Usuario))
                return BadRequest("El campo Usuario es obligatorio.");

            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = mascota.Id }, mascota);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Mascota mascota)
        {
            if (id != mascota.Id)
                return BadRequest("Id no coincide.");

            var existente = await _context.Mascotas.FindAsync(id);
            if (existente == null)
                return NotFound();

            existente.Nombre = mascota.Nombre;
            existente.Especie = mascota.Especie;
            existente.Raza = mascota.Raza;
            existente.Edad = mascota.Edad;
            existente.FotoPath = mascota.FotoPath;
            // Si quieres permitir cambiar el propietario:
            // existente.Usuario = mascota.Usuario;

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
