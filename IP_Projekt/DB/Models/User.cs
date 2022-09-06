using Microsoft.AspNetCore.Identity;


using IP_Projekt.DB.Models;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Projekt.DB.Models
{

    public class User : IdentityUser
    {
        [Column("user_type")]
        public user_type Typ { get; set; }
        [Column("Imie")]
        private string imie { get; set; }
        [Column("Nazwisko")]
        private string nazwisko { get; set; }


        public user_type GetTyp()
        {
            return Typ;
        }

        public void setTyp(user_type loc_typ)
        {
            this.Typ = loc_typ;
        }


        public User(user_type typ, string userName)
        {
            this.Typ = typ;
            this.UserName = userName;
        }
        public User() { }
    }

}

