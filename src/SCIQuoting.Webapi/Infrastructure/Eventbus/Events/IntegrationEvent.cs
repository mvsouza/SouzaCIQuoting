using System;
using MongoDB.Bson;

namespace SCIQuoting.Webapi.Infrastructure.EventBus.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Key = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public ObjectId Id { get; set; }
        public Guid Key  { get; }
        public DateTime CreationDate { get; }
    }
}