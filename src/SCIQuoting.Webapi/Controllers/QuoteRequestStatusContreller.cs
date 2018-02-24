using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCIQuoting.Webapi.Infrastructure.EventBus.Abstractions;
using SCIQuoting.Webapi.Infrastructure.Repositories;
using SCIQuoting.Webapi.Application.Models;
using SCIQuoting.Webapi.Application.IntegrationEvents.Events;

namespace SCIQuoting.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class QuoteRequestStatusController : Controller
    {
        private readonly IInsuranceQuotingRequestRepository _repository;
        public QuoteRequestStatusController(IInsuranceQuotingRequestRepository _repository){
            this._repository = _repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Guid key)
        {
            var quote = await _repository.GetAsync(key);
            if(quote==null)
                return StatusCode(404);
            return Ok(new {
                Key = quote.Key,
                Satus = quote.QuoteProcessStatus.Status,
                ValueQuoted = quote.QuoteProcessStatus.ValueQuoted
            });
        }
    }
}