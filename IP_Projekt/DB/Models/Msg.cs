using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Projekt.DB.Models
{
    [Table("Msg")]
    public class Msg
    {
        [Key]
        [Column("Msg_ID")]
        public int Id { get; set; }

        [Required]
        public int sender_ID { get; set; }

        [Required]
        public int receiver_ID { get; set; }

        [Required(ErrorMessage = "Wiadomość jest pusta")]
        [MaxLength(500, ErrorMessage = "Wiadomość jest za długa")]
        public string content { get; set; }

        [Column("Msg_date")]
        [Required]
        public DateTime date { get; set; }
        
        [Required]
        public int chat_ID { get; set; }

        //--------------------------------
        [Table("IdentityUserClaim", Schema = "ManagementStudio")]
        public class UserClaims : IdentityUserClaim<string>
        {
            [Key]
            public override int Id { get; set; }
        }
        //--------------------------------
    }
}
