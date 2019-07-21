using System;
using Blue.Domain.Entities;
using Blue.Infrastructure.Context;
using Blue.Service.Business;
using Microsoft.AspNetCore.Mvc;

namespace Blue.Service.Proxy.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreTransactionController : ControllerBase
    {
        private BaseService<ScoreTransaction> ScoreTransactionService { get; set; }

        public ScoreTransactionController(BlueContext options)
        {
            this.ScoreTransactionService = new BaseService<ScoreTransaction>(options);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(this.ScoreTransactionService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(this.ScoreTransactionService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}