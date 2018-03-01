using SCIQuoting.Webapi.Infrastructure.EventBus.Abstractions;
using SCIQuoting.Webapi.Infrastructure.Repositories;
using System.Threading.Tasks;
using SCIQuoting.Webapi.Application.IntegrationEvents.Events;
using SCIQuoting.Webapi.Application.Commands;
using MediatR;
using SCIQuoting.Webapi.Application.Models;

namespace SCIQuoting.Webapi.Application.IntegrationEvents.EventHandling
{
    public class QuoteRequestedIntegrationEventHandler : IIntegrationEventHandler<QuoteRequestedIntegrationEvent>
    {

        private readonly IMediator _mediator;
        private readonly IInsuranceQuotingRequestRepository _repository;

        public QuoteRequestedIntegrationEventHandler(IInsuranceQuotingRequestRepository repository, IMediator _mediator)
        {
            this._mediator = _mediator;
            this._repository = repository;
        }

        public async Task Handle(QuoteRequestedIntegrationEvent @event)
        {
            var InsurenceQuoting = await _repository.GetAsync(@event.RequestKey);
            var veh = InsurenceQuoting.Vehicle;
            var calculateRequest = new CalculateIsuranceBasePrice(veh.VehicleType,int.Parse(veh.ManufacturingYear), veh.Model, veh.Make);
            InsurenceQuoting.QuoteProcessStatus.ValueQuoted  = await _mediator.Send(calculateRequest);
            InsurenceQuoting.QuoteProcessStatus.ValueQuoted*=(decimal)InsurenceQuoting.Customer.Modifier;
            InsurenceQuoting.QuoteProcessStatus.Status = QuoteStatus.Done;
            _repository.AddOrUpdateAsync(InsurenceQuoting);
            
            
        
        }
    }
}

