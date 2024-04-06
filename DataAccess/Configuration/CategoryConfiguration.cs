using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace DataAccess.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            //Primary Key
            builder.HasKey(n => n.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(n => n.Name).IsRequired().HasMaxLength(100); ;


            // Relationship with one category
            builder.HasMany(c => c.Notes)
                   .WithOne(n => n.Category)
                   .HasForeignKey(n => n.CategoryId);



        }
    }
}