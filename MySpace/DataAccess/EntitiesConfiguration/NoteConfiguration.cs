using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpace.DomainModel;

namespace MySpace.DataAccess.EntitiesConfiguration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            //Primary Key
            builder.HasKey(n => n.Id);

            // Properties
            builder.Property(n => n.Title).IsRequired().HasMaxLength(100); ;
            builder.Property(n => n.Description).IsRequired().HasMaxLength(100); ;

            // Relationship with one category
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Notes)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired();

            // Relationship with one memeber
            builder.HasOne(p => p.Member)
                   .WithMany(m => m.Notes)
                   .HasForeignKey(p => p.MemberId)
                   .IsRequired();

        }

    }
}
