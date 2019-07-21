using Blue.Domain;
using Blue.Domain.Dto;
using Blue.Domain.Entities;
using Blue.Infrastructure.Context;
using System;
using System.Linq;

namespace Blue.Service.Business
{
    public class ScoreService : BaseService<Score>
    {
        protected ScoreParameterService ScoreParameterService { get; set; }
        protected ScoreTransactionService ScoreTransactionService { get; set; }

        public ScoreService(BlueContext options) : base(options)
        {
            this.ScoreParameterService = new ScoreParameterService(options);
            this.ScoreTransactionService = new ScoreTransactionService(options);
        }

        public bool UpdateScore(RequestDto request, TransactionType type)
        {
            ScoreParameter parameter = this.ScoreParameterService.GetParameters(request);

            if (parameter == null)
                throw new ArgumentException("Não foi encontrada uma configuração para definir a Pontuação");

            Score clientScore = this.GetByTaxId(request.TaxId);

            if (clientScore == null)
            {
                Score client = new Score();
                client.TaxId = request.TaxId;
                client.TotalScore = parameter.Score;

                this.Repository.Insert(client);
            }
            else
            {
                switch (type)
                {
                    case TransactionType.Addiction:

                        if(parameter.Multiplier.HasValue)
                            clientScore.TotalScore += request.PaymentValue.Value * parameter.Multiplier.Value;
                        else
                            clientScore.TotalScore += parameter.Score;
                        break;
                    case TransactionType.Subtraction:
                        clientScore.TotalScore -= parameter.Score;
                        break;
                }
            }

            ScoreTransaction scoreTransaction = new ScoreTransaction();
            scoreTransaction.Score = parameter.Score;
            scoreTransaction.ScoreId = clientScore.ScoreId;
            scoreTransaction.TransactionDate = DateTime.Now;
            scoreTransaction.TransactionTypeId = (int)type;

            this.ScoreTransactionService.Repository.Insert(scoreTransaction);

            this.Repository.Context.SaveChanges();

            return true;
        }

        private Score GetByTaxId(string taxId)
        {
            return this.Repository.Context.Set<Score>().Where(s => s.TaxId.Equals(taxId)).FirstOrDefault();
        }
    }
}
