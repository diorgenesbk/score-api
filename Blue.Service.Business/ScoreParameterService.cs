using Blue.Domain.Dto;
using Blue.Domain.Entities;
using Blue.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Blue.Service.Business
{
    public class ScoreParameterService : BaseService<ScoreParameter>
    {
        public ScoreParameterService(BlueContext options) : base(options)
        {
        }

        public ScoreParameter GetParameters(RequestDto request)
        {
            var query = this.Repository.Context.Set<ScoreParameter>()
                .AsNoTracking()
                .Where(sp => sp.StartDate <= DateTime.Now.Date && (!sp.EndDate.HasValue || sp.EndDate >= DateTime.Now.Date));

            if (request.Product != null)
                query = query.Where(sp => !sp.Product.HasValue || sp.Product == request.Product);

            if (request.Instalment.HasValue)
                query = query.Where(sp => !sp.Instalment.HasValue || sp.Instalment == request.Instalment);

            if(request.PaymentDate.HasValue && request.DueDate.HasValue)
            {
                query = query
                    .Where(sp => !sp.MinimumDelay.HasValue || sp.MinimumDelay >= request.PaymentDate.Value.Subtract(request.DueDate.Value).TotalDays)
                    .Where(sp => !sp.MaximumDelay.HasValue || sp.MaximumDelay <= request.PaymentDate.Value.Subtract(request.DueDate.Value).TotalDays);
            }

            var parameters = query.FirstOrDefault();

            return parameters;
        }
    }
}
