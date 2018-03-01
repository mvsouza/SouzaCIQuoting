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
using Microsoft.Extensions.Caching.Memory;

namespace SCIQuoting.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class QuotingRequestController : Controller
    {
        private readonly IEventBus _eventBus;
        private readonly IInsuranceQuotingRequestRepository _repository;
        private IMemoryCache _cache;

        public QuotingRequestController(IEventBus eventBus, IInsuranceQuotingRequestRepository repository, IMemoryCache memoryCache)
        {
            this._eventBus = eventBus;
            this._repository = repository;
            this._cache = memoryCache;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]QuoteRequestViewModel value)
        {
            var newQuateRequest = new InsuranceQuotingRequest()
            {
                Key = Guid.NewGuid(),
                Customer = value.Customer,
                Vehicle = value.Vehicle,
                QuoteProcessStatus = new QuoteProcessStatus()
                {
                    Status = QuoteStatus.Pendding
                }
            };

            await _repository.AddOrUpdateAsync(newQuateRequest);
            _eventBus.Publish(new QuoteRequestedIntegrationEvent(
                newQuateRequest.Key
            ));
            _cache.Set(newQuateRequest.Key, newQuateRequest);
            return Ok(newQuateRequest.Key);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Guid key)
        {
            QuoteRequestViewModel quote = await GetQuoteRequestAsync(key);
            if(quote ==  null)
                    return StatusCode(404);
            return Ok(quote);
        }
        private async Task<QuoteRequestViewModel> GetQuoteRequestAsync(Guid key)
        {
            InsuranceQuotingRequest quote;
            if (!_cache.TryGetValue(key, out quote)) {
                quote = await _repository.GetAsync(key);
                _cache.Set(key, quote);
            }
            return new QuoteRequestViewModel()
            {
                Vehicle = quote.Vehicle,
                Customer = quote.Customer
            };
        }
    }
}