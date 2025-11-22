using System.ComponentModel.DataAnnotations;

namespace VeterinariaApi.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        public string NombreMascota { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
    }
}
