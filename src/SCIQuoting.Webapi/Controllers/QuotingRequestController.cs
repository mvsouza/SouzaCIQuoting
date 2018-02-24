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
        public async Task<IActionResult> Post([FromBody]QuoteRequestViewModel value)
        {
            var newQuateRequest =  new InsuranceQuotingRequest(){
                Key = Guid.NewGuid(),
                Costumer = value.Costumer,
                Vehicle =  value.Vehicle,
                QuoteProcessStatus = new QuoteProcessStatus(){
                    Status = QuoteStatus.Pendding
                }
            };

            await _repository.AddOrUpdateAsync(newQuateRequest);
            _eventBus.Publish(new QuoteRequestedIntegrationEvent(
                newQuateRequest.Key 
            ));
            return Ok(newQuateRequest.Key );
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Guid key)
        {
            var quote = await _repository.GetAsync(key);
            if(quote==null)
                return StatusCode(404);
            return Ok(new QuoteRequestViewModel(){
                Vehicle = quote.Vehicle,
                Costumer = quote.Costumer
            });
        }
    }
}