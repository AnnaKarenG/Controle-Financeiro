using Microsoft.EntityFrameworkCore;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Database
{
    public class SistemaFinanceiroDBContext : DbContext
    {
        public SistemaFinanceiroDBContext(DbContextOptions<SistemaFinanceiroDBContext> options) : base(options) 
        {
        }

       public DbSet<User> User { get; set; }
       public DbSet<Revenue> Revenue { get; set; }
       public DbSet<Expense> Expense { get; set; }
       public DbSet<Category> Category { get; set; }
       public DbSet<Card> Card { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
