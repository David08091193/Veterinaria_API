using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Data;
using VeterinariaApi.Models;

namespace VeterinariaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CitaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> Get()
        {
            return await _context.Citas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cita>> Post(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return Ok(cita);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
                return NotFound();

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("por-usuario/{usuario}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetPorUsuario(string usuario)
        {
            return await _context.Citas
                .Where(c => c.Usuario == usuario)
                .ToListAsync();
        }

        [HttpGet("fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetPorFecha(DateTime fecha)
        {
            return await _context.Citas
                .Where(c => c.Fecha.Date == fecha.Date)
                .ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cita cita)
        {
            if (id != cita.Id)
                return BadRequest();

            var citaExistente = await _context.Citas.FindAsync(id);
            if (citaExistente == null)
                return NotFound();

            citaExistente.Fecha = cita.Fecha;
            citaExistente.Hora = cita.Hora;
            citaExistente.Motivo = cita.Motivo;

            await _context.SaveChangesAsync();
            return NoContent();
        }




    }
}
