namespace SCIQuoting.Webapi.Infrastructure.Infrastructure
{
    using SCIQuoting.Webapi.Application.Models;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using SCIQuoting.Webapi.Infrastructure.Idempotency;

    public class QuotingRequestContext
    {
        private readonly IMongoDatabase _database = null;

        public QuotingRequestContext(IOptions<QuotingSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<InsuranceQuotingRequest> InsuranceQuotingRequest
        {
            get
            {
                return _database.GetCollection<InsuranceQuotingRequest>("InsuranceQuotingRequest");
            }
        }

        public IMongoCollection<ClientRequest> ClientRequests
        {
            get
            {
                return _database.GetCollection<ClientRequest>("ClientRequest");
            }
        }
    }
}
