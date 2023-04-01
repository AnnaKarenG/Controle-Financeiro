using Microsoft.EntityFrameworkCore;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Database
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) 
        {
        }

       public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
