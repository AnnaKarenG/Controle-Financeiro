using Microsoft.EntityFrameworkCore;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Database 
{ 
    public class CategoryDBContext : DbContext
    {
        public CategoryDBContext(DbContextOptions<CategoryDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }



    }
}