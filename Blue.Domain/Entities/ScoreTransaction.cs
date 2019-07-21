using System;

namespace Blue.Domain.Entities
{
    public class ScoreTransaction : BaseEntity
    {
        public int ScoreTransactionId { get; set; }

        public int ScoreId { get; set; }

        public decimal Score { get; set; }

        public DateTime TransactionDate { get; set; }

        public int TransactionTypeId { get; set; }
    }
}
