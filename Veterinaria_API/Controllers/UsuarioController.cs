using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Data;
using VeterinariaApi.Models;

namespace VeterinariaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registrar(Usuario usuario)
        {
            if (await _context.Usuarios.AnyAsync(u => u.NombreUsuario == usuario.NombreUsuario))
                return Conflict("El usuario ya existe.");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest req)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == req.NombreUsuario && u.Contraseña == req.Contraseña);

            if (user == null) return Unauthorized("Credenciales inválidas.");

            return Ok(new LoginResponse
            {
                NombreUsuario = user.NombreUsuario,
                Rol = user.Rol
            });
        }
    }
}
