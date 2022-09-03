using Microsoft.AspNetCore.Identity;
namespace IP_Projekt.DB.Models
{

    

    public class User: IdentityUser
    {
        private user_type Typ { get; set; }
        public User(/*String Email, String loc_password, user_type loc_type*/)
        {
            //this.Email = loc_email;
            //this.PasswordHash = loc_password;
            //this.Typ = loc_type;
        }
    }
}
