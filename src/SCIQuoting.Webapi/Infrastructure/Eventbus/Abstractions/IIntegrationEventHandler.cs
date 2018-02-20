using SCIQuoting.Webapi.Infrastructure.EventBus.Events;
using System.Threading.Tasks;

namespace SCIQuoting.Webapi.Infrastructure.EventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler 
        where TIntegrationEvent: IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}