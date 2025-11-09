using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoogleMapsCoreMVC.Models
{
    [Table("Registros")]
    public class Registro
    {
        [Key]
        public int IdReporte { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Latitud { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Longitud { get; set; }

        public DateTime HoraReporte { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Login Login { get; set; }
    }
}
