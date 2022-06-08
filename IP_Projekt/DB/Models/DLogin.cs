using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Projekt.DB.Models
{
    [Table("D_Login")]
    public class DLogin
    {
        [Key]
        public int D_ID { get; set; }
        public string D_log { get; set; }
        public string D_pass { get; set; }
    }
}
