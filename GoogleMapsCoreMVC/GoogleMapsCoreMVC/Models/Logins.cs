using GoogleMapsCoreMVC.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoogleMapsCoreMVC.Models
{
    public class Logins
    {
        [Key]
        public int UserId { get; set; }
        public string UsernameLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserRol { get; set; }
        public string Email { get; set; }

        // Relaciones
        public ICollection<Agente> Agentes { get; set; }
        public ICollection<Registros> Registros { get; set; }
    }
}
