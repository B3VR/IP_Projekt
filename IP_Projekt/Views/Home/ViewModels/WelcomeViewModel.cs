
using System.ComponentModel.DataAnnotations;
using IP_Projekt.DB.Models;
using System.ComponentModel.DataAnnotations;

namespace IP_Projekt.Views.Home.ViewModels
{
    public class WelcomeViewModel
    {
        public User currentUser { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string loc_typ { get; set; }
    }

}
