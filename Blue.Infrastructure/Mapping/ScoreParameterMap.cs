using Blue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blue.Infrastructure.Mapping
{
    public class ScoreParameterMap : IEntityTypeConfiguration<ScoreParameter>
    {
        public void Configure(EntityTypeBuilder<ScoreParameter> builder)
        {
            builder.ToTable("ScoreParameter");

            builder.HasKey(c => c.ScoreParameterId);
        }
    }
}
