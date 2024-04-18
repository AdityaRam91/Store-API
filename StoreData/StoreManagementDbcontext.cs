using GamestoreManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace StoreData
{
    public class StoreManagementDbcontext :DbContext
    {
        public StoreManagementDbcontext(DbContextOptions options) : base(options) { }

        public DbSet<Games> Games { get; set; }
        public DbSet<Joysticks> Joysticks { get; set;}
        public DbSet<Login> Logins { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Register> Registers { get; set; }



    }
}
