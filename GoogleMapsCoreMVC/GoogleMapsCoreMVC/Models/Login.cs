using System.ComponentModel.DataAnnotations;

namespace GoogleMapsCoreMVC.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50)]
        public string UsernameLogin { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100)]
        public string UserPassword { get; set; }

        [StringLength(50)]
        public string? UserRol { get; set; }
    }
}
