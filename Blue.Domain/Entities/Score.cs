namespace Blue.Domain.Entities
{
    public class Score : BaseEntity
    {
        public int ScoreId { get; set; }

        public string TaxId { get; set; }

        public decimal TotalScore { get; set; }
    }
}
