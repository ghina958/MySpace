using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            //Primary Key
            builder.HasKey(n => n.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(n => n.Title).IsRequired().HasMaxLength(100);
            builder.Property(n => n.Description).IsRequired().HasMaxLength(200);
               
        }

    }
}
