using System;
using MongoDB.Bson;

namespace SCIQuoting.Webapi.Infrastructure.Idempotency
{
    public class ClientRequest
    {

        public ObjectId Id { get; set; }
        public Guid Key { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}
