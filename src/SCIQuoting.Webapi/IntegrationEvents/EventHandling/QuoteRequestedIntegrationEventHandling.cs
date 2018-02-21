using SCIQuoting.Webapi.Infrastructure.EventBus.Abstractions;
using SCIQuoting.Webapi.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;
using SCIQuoting.Webapi.IntegrationEvents.Events;

namespace SCIQuoting.Webapi.IntegrationEvents.EventHandling
{
    public class QuoteRequestedIntegrationEventHandler : IIntegrationEventHandler<QuoteRequestedIntegrationEvent>
    {

        private readonly IInsuranceQuotingRequestRepository _repository;
        public QuoteRequestedIntegrationEventHandler(IInsuranceQuotingRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(QuoteRequestedIntegrationEvent @event)
        {
        }
    }
}

