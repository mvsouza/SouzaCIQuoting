using MongoDB.Driver;
using SCIQuoting.Webapi.Infrastructure.Infrastructure;
using System;
using System.Threading.Tasks;

namespace SCIQuoting.Webapi.Infrastructure.Idempotency
{
    public class RequestManager : IRequestManager
    {
        private readonly QuotingRequestContext _context;

        public RequestManager(QuotingRequestContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<bool> ExistAsync(Guid id)
        {

            var filter = Builders<ClientRequest>.Filter.Eq("Id", id);

            var request = await _context.ClientRequests
                                 .Find(filter)
                                 .FirstOrDefaultAsync(); ;

            return request != null;
        }

        public async Task CreateRequestForCommandAsync<T>(Guid key)
        {
            var exists = await ExistAsync(key);

            var request = exists ?
                throw new Exception($"Request with {key} already exists") :
                new ClientRequest()
                {
                    Key = key,
                    Name = typeof(T).Name,
                    Time = DateTime.UtcNow
                };

            _context.ClientRequests.InsertOne(request);
            
        }
    }
}
