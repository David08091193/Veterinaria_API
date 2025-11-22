using System.ComponentModel.DataAnnotations;

namespace VeterinariaApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        public string Contraseña { get; set; } = string.Empty;

        public string Rol { get; set; } = "Usuario"; // Usuario, Veterinario, Administrador
    }

    public class LoginRequest
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Rol { get; set; } = "Usuario";
    }
}
