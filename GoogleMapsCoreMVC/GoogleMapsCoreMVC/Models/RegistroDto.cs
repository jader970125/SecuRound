using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoogleMapsCoreMVC.Models
{
    public class Registros
    {
        [Key]
        public int IdReporte { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Latitud { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Longitud { get; set; }

        public DateTime HoraReporte { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public Login User { get; set; }
    }
}
