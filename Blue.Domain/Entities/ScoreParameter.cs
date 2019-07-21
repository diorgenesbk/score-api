using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.Domain.Entities
{
    public class ScoreParameter : BaseEntity
    {
        public int ScoreParameterId { get; set; }

        public string Description { get; set; }

        public decimal Score { get; set; }

        public int? Product { get; set; }

        public int? Instalment { get; set; }

        public decimal? Multiplier { get; set; }

        public int? MinimumDelay { get; set; }

        public int? MaximumDelay { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
