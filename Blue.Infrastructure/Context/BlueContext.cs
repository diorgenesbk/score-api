using Blue.Domain.Entities;
using Blue.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Blue.Infrastructure.Context
{
    public class BlueContext : DbContext
    {
        public BlueContext(DbContextOptions<BlueContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<ScoreParameter>(new ScoreParameterMap().Configure);
            modelBuilder.Entity<Score>(new ScoreMap().Configure);
           // modelBuilder.Entity<TransactionType>(new TransactionTypeMap().Configure);
            modelBuilder.Entity<ScoreTransaction>(new ScoreTransactionMap().Configure);
        }
    }
}
