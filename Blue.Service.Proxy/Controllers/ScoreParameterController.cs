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
    public class ScoreParameterController : ControllerBase
    {
        protected BaseService<ScoreParameter> ScoreParameterService { get; set; }

        public ScoreParameterController(BlueContext options)
        {
            this.ScoreParameterService = new BaseService<ScoreParameter>(options);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(this.ScoreParameterService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}