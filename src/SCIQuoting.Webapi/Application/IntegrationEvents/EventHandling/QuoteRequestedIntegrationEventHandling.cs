using SCIQuoting.Webapi.Infrastructure.EventBus.Abstractions;
using SCIQuoting.Webapi.Infrastructure.Repositories;
using System.Threading.Tasks;
using SCIQuoting.Webapi.Application.IntegrationEvents.Events;
using SCIQuoting.Webapi.Application.Commands;
using MediatR;

namespace SCIQuoting.Webapi.Application.IntegrationEvents.EventHandling
{
    public class QuoteRequestedIntegrationEventHandler : IIntegrationEventHandler<QuoteRequestedIntegrationEvent>
    {

        private readonly IMediator _mediator;
        private readonly IInsuranceQuotingRequestRepository _repository;

        public QuoteRequestedIntegrationEventHandler(IInsuranceQuotingRequestRepository repository, IMediator _mediator)
        {
            _mediator = _mediator;
            _repository = repository;
        }

        public async Task Handle(QuoteRequestedIntegrationEvent @event)
        {
            var InsurenceQuoting = await _repository.GetAsync(@event.Id);
            var veh = InsurenceQuoting.Vehicle;
            var calculateRequest = new CalculateIsuranceBasePrice(veh.VehicleType, veh.ManufacturingYear, veh.Model, veh.Make);
            var commandResult  = _mediator.Send(calculateRequest);
        }
    }
}

