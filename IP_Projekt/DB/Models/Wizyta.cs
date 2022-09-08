using IP_Projekt.DB.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Projekt.DB.Models
{
    [Table("Wizyta")]
    public class Wizyta
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column("lekarz_id")]
        public string lekarzId { get; set; }
        [Required]
        [Column("pacjent_id")]
        public string pacjentId { get; set; }
        [Required]
        [Column("data")]
        public DateTime data { get; set; }
        [Required]
        [Column("status")]
        public statusWizytyEnum status { get; set; }
        [Column("opis_objawow")]
        public string opisObjawow { get; set; }
        [Column("doctor_name")]
        public string doctorName { get; set; }
        [Column("patient_name")]
        public string patientName { get; set; }

    }
}
