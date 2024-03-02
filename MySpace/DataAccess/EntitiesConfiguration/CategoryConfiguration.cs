using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MySpace.DomainModel;

namespace MySpace.DataAccess.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            //Primary Key
            builder.HasKey(n => n.Id);

            // Properties
            builder.Property(n => n.Name).IsRequired().HasMaxLength(100); ;
            

            // Relationship with one category
            builder.HasOne(c => c.Space)
                   .WithMany(s => s.Categories)
                   .HasForeignKey(c => c.SpaceId)
                   .IsRequired();

            // Relationship with one category
            builder.HasMany(c => c.Notes)
                   .WithOne(n => n.Category)
                   .HasForeignKey(n => n.CategoryId)
                   .IsRequired();



        }
    }
}