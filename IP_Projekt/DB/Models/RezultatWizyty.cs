using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Projekt.DB.Models
{
    [Table("VisitResult")]
    public class RezultatWizyty
    {
        [Key]
        public int id { get; set; }

        [Column("visitId")]
        public int wizytaId { get; set; }

        [Column("chorobaId")]
        public int stwierdzonaChorobaId { get; set; }
        [Column("przebiegWizyty")]
        public string przebiegWizyty { get; set; }
        [Column("przepisaneLeki")]
        public string przepisaneLeki { get; set; }
    }
}
