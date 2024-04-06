using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class SpaceConfiguration : IEntityTypeConfiguration<Space>
    {
        public void Configure(EntityTypeBuilder<Space> builder)
        {
            //Primary Key
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100); ;
            builder.Property(s => s.Description).IsRequired().HasMaxLength(200);

            // Relationship with one category
            builder.HasMany(s => s.Categories)
                   .WithOne(c => c.Space)
                   .HasForeignKey(c => c.SpaceId);

        }
    }
}
