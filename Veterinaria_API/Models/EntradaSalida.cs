using System.ComponentModel.DataAnnotations;

namespace VeterinariaApi.Models
{
    public class EntradaSalida
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreMascota { get; set; } = string.Empty;

        [Required]
        public DateTime FechaEntrada { get; set; }

        public DateTime FechaSalida { get; set; }

        [Required]
        public string Motivo { get; set; } = string.Empty;
    }
}
