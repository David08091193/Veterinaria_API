using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Models;

namespace VeterinariaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Aquí vamos a ir agregando tus modelos como tablas
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<EntradaSalida> EntradasSalidas { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }







    }
}
