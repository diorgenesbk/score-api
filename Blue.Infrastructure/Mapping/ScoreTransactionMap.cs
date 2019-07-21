using Blue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blue.Infrastructure.Mapping
{
    public class ScoreTransactionMap : IEntityTypeConfiguration<ScoreTransaction>
    {
        public void Configure(EntityTypeBuilder<ScoreTransaction> builder)
        {
            builder.ToTable("ScoreTransaction");

            builder.HasKey(c => c.ScoreTransactionId);
        }
    }
}
