﻿using Microsoft.AspNetCore.Identity;
namespace IP_Projekt.DB.Models
{

    public enum user_type { pacjent, lekarz, administrator };

    public class User: IdentityUser
    {
        private user_type Typ;
        public User(String loc_email, String loc_password, user_type loc_type)
        {
            this.Email = loc_email;
            this.PasswordHash = loc_password;
            this.Typ = loc_type;
        }
    }
}