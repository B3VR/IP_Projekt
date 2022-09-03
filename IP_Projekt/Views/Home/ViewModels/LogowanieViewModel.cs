using IP_Projekt.DB.Models;
namespace IP_Projekt.Views.Home.ViewModels
{
    public class LogowanieViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public user_type Typ { get; set; }
    }
}
