using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Projekt.Views.Home.ViewModels
{
    public class RejestracjaViewModel
    {
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Przy potwierdzaniu wpisz takie samo hasło jak w polu powyżej")]
        public string ConfirmPassword { get; set; }


    }
}
