using IP_Projekt.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IP_Projekt.DB
{
    public class IpprojContext : DbContext
    {
        public IpprojContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<DLogin> dLogins { get; set; }
        public DbSet<Msg> Msgs { get; set; } 
        public DbSet<Chat> Chats { get; set; }
        public DbSet<User> users { get; set; }  //<----- Pole obsługujące Usera



    }
}
