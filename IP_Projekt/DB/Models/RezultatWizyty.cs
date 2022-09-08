using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Projekt.DB.Models
{
    [Table("RezultatWizyty")]
    public class RezultatWizyty
    {
        [Key]
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int wizytaId;
        public int stwierdzonaChorobaId;
        public string przebiegWizyty;
        public string przepisaneLeki;
    }
}
