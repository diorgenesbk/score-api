using Blue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blue.Infrastructure.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnName("Cpf");

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");
        }
    }
}
