using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoogleMapsCoreMVC.Models
{
    public class Registros
    {
        [Key]
        public int IdReporte { get; set; }

        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public DateTime HoraReporte { get; set; }

        // Clave foránea
        public int UserId { get; set; }

        // 🔑 Propiedad de navegación
        [ForeignKey("UserId")]
        public Logins User { get; set; }
    }
}
