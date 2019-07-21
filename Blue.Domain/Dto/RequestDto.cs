using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.Domain.Dto
{
    public class RequestDto
    {
        public string TaxId { get; set; }

        public int? Product { get; set; }

        public int? Instalment { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public decimal? PaymentValue { get; set; }

        public string ContractNumber { get; set; }
    }
}
