using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartEnum.EFCore;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.ConfigureSmartEnum();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Domain.User> Users { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

    }

}
