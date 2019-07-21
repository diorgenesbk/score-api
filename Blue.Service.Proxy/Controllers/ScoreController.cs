using System;
using Blue.Domain.Dto;
using Blue.Domain.Entities;
using Blue.Infrastructure.Context;
using Blue.Service.Business;
using Microsoft.AspNetCore.Mvc;

namespace Blue.Service.Proxy.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        protected ScoreService ScoreService { get; set; }

        public ScoreController(BlueContext options)
        {
            this.ScoreService = new ScoreService(options);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(this.ScoreService.Get());
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
                return new ObjectResult(this.ScoreService.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("add")]
        public IActionResult AddScore(RequestDto request)
        {
            try
            {
                var response = this.ScoreService.UpdateScore(request, TransactionType.Addiction);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPost("sub")]
        public IActionResult SubScore(RequestDto request)
        {
            try
            {
                var response = this.ScoreService.UpdateScore(request, TransactionType.Subtraction);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}