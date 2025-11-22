using System.ComponentModel.DataAnnotations;

namespace VeterinariaApi.Models
{
    public class HistorialMedico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreMascota { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Diagnostico { get; set; } = string.Empty;

        [Required]
        public string Tratamiento { get; set; } = string.Empty;

        public string Observaciones { get; set; } = string.Empty;
    }
}
