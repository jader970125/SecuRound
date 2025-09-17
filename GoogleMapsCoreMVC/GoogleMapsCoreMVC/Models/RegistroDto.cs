using System;

namespace GoogleMapsCoreMVC.Models
{
    public class RegistroDto
    {
        public int IdReporte { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DateTime HoraReporte { get; set; }
        public int UserId { get; set; }
        public string NombreAgente { get; set; } // nombre completo o username
        public string Email { get; set; }
        public string UserRol { get; set; }
    }
}
