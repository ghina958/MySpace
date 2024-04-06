using Domain;
using Domain.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            //Primary Key
            builder.HasKey(m => m.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasIndex(x => new { x.UserId, x.SpaceId }).IsUnique();

            // Relationship with one User
            builder.HasOne(m => m.User)
            .WithMany(u => u.Memberships)
            .HasForeignKey(m => m.UserId);

            // Relationship with one Space
            builder.HasOne(m => m.Space)
           .WithMany(s => s.Members)
           .HasForeignKey(m => m.SpaceId);


            // Relationship with one Notes
            builder.HasMany(m => m.Notes)
                   .WithOne(n => n.Creator)
                   .HasForeignKey(n => n.CreatorId)
                   .OnDelete(DeleteBehavior.Cascade);

           //builder.Property(p => p.Role)
           //        .HasConversion(
           //            p => p.Value,
           //            p => Role.FromValue(p));
           //
        }
    }
}
