using Blue.Domain.Dto;
using Blue.Domain.Entities;
using Blue.Infrastructure.Context;
using System;
using System.Linq;

namespace Blue.Service.Business
{
    public class ScoreTransactionService : BaseService<ScoreTransaction>
    {
        public ScoreTransactionService(BlueContext options) : base(options)
        {
        }
    }
}
