using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpace.DomainModel;

namespace MySpace.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Permisions> Permisions { get; set; }
        public DbSet<PermisionsRoleMapper> PermisionsRoleMapper { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<User> Users { get; set; }

    }

    //public class NoteConfiguration : IEntityTypeConfiguration<Note>
    //{
    //    public void Configure(EntityTypeBuilder<Note> builder)
    //    {
    //    }
    //}
}
