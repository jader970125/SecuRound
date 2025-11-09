using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoogleMapsCoreMVC.Models
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }

        public string UsernameLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserRol { get; set; }
        public string Email { get; set; }

        public ICollection<Agente> Agente { get; set; }
        public ICollection<Registro> Registros { get; set; }
    }
}