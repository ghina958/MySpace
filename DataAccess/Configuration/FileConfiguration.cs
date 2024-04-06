using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Configuration
{
    public class FileConfiguration : IEntityTypeConfiguration<Domain.File>, 
        IEntityTypeConfiguration<Domain.Attachment>
    {
        public void Configure(EntityTypeBuilder<Domain.File> builder)
        {
            //Primary Key
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(s => s.Url).IsRequired().HasMaxLength(500); ;

        }

        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.File)
                .WithMany()
                .HasForeignKey(x => x.FileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Note)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.NoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
