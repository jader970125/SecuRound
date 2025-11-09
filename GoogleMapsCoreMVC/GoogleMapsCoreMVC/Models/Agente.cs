using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoogleMapsCoreMVC.Models
{
    [Table("Agentes")]
    public class Agente
    {
        [Key]
        public int IdAgente { get; set; }

        public string NameAgente { get; set; }
        public string LastNameAgente { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Login Login { get; set; }
    }
}
