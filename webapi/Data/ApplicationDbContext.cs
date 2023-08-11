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
        public DbSet<Book>  Books { get; set; }
        public DbSet<BookGrant> BookGrants { get; set; }
        public DbSet<KnowledgeHub> knowledgeHubs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserQuestionsAnswer> UserQuestionsAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfig());
        }
    }
}
