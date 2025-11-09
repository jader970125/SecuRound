using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoogleMapsCoreMVC.Models
{
    public class Logins
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public string UsernameLogin { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string UserPassword { get; set; }

        [Display(Name = "Rol de usuario")]
        public string UserRol { get; set; }

        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        // Relaciones con otras tablas
        public ICollection<Agente> Agentes { get; set; }
        public ICollection<Registro> Registros { get; set; } // ✅ corregido (singular)
    }
}
