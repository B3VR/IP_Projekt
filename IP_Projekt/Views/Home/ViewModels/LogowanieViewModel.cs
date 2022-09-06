using IP_Projekt.DB.Models;
using System.ComponentModel.DataAnnotations;

namespace IP_Projekt.Views.Home.ViewModels
{
    public class LogowanieViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
