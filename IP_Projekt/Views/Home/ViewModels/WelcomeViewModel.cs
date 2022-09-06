using System.ComponentModel.DataAnnotations;
namespace IP_Projekt.Views.Home.ViewModels
{
    public class WelcomeViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string loc_typ { get; set; }
    }

}
