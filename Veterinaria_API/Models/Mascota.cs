// VeterinariaApi.Models/Mascota.cs
namespace VeterinariaApi.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = "";
        public string Especie { get; set; } = "";
        public string Raza { get; set; } = "";
        public string Edad { get; set; } = "";

        public string FotoPath { get; set; } = "";

        // Usuario propietario de la mascota
        public string Usuario { get; set; } = "";
    }
}
