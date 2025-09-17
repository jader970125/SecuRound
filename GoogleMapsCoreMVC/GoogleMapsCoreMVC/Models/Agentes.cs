using GoogleMapsCoreMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoogleMapsCoreMVC.Models
{
    public class Agente
    {
        [Key]
        public int IdAgente { get; set; }
        public string NameAgente { get; set; }
        public string LastNameAgente { get; set; }
        public string CargoAgente { get; set; }

        // FK hacia Login
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Logins Login { get; set; }
    }
}
