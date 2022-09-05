
using IP_Projekt.DB.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

public class User: IdentityUser
{


    [Column("user_type")]
    private user_type Typ { get; set; }
    //[Column("Imie")]
    //private string imie { get; set; }
    //[Column("Nazwisko")]
    //private string nazwisko { get; set; }

    public User(user_type typ, string userName)
    {
        this.Typ = typ;
        this.UserName = userName;
    }

    public User(string email, string userName)
    {
        this.Email = email;
        this.UserName = userName;   
    }

    public User()
    {

    }
}
