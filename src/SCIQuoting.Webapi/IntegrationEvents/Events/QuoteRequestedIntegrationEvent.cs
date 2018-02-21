
using System;
using SCIQuoting.Webapi.Infrastructure.EventBus.Events;

namespace SCIQuoting.Webapi.IntegrationEvents.Events
{
    // Integration Events notes: 
    // An Event is “something that has happened in the past”, therefore its name has to be   
    // An Integration Event is an event that can cause side effects to other microsrvices, Bounded-Contexts or external systems.
    public class QuoteRequestedIntegrationEvent : IntegrationEvent
    {
        public Guid RequestId{ get; set; }

        public QuoteRequestedIntegrationEvent(Guid requestId)
            => RequestId = requestId;            
    }
}
