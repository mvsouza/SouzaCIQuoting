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
    public class QuotingRequestController : Controller
    {
        private readonly IEventBus _eventBus;
        private readonly IInsuranceQuotingRequestRepository _repository;
        public QuotingRequestController(IEventBus _eventBus, IInsuranceQuotingRequestRepository _repository){
            this._eventBus = _eventBus;
            this._repository = _repository;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InsuranceQuotingRequest value)
        {
            value.Key = Guid.NewGuid();
            await _repository.AddOrUpdateAsync(value);
            _eventBus.Publish(new QuoteRequestedIntegrationEvent(
                value.Key 
            ));
            return Ok(value.Key );
        }
    }
}