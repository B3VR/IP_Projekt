using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Projekt.DB.Models
{
    [Table("Chats")]
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Doctor_ID { get; set; }

        [Required]
        public int Patient_ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
