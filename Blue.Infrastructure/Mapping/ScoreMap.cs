using Blue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blue.Infrastructure.Mapping
{
    public class ScoreMap : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Score");

            builder.HasKey(c => c.ScoreId);
        }
    }
}
