using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Data.Configurations;
using webapi.Models;

namespace webapi.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApiUser>
    {
        public ApplicationDbContext(DbContextOptions  options) :base(options) { 
        }
        

        public DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfig());
        }
    }
}
