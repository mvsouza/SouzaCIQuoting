namespace SCIQuoting.Webapi.Infrastructure.Repositories
{
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.GeoJsonObjectModel;
    using SCIQuoting.Webapi.Infrastructure.Infrastructure;
    using SCIQuoting.Webapi.Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class InsuranceQuotingRequestRepository
        : IInsuranceQuotingRequestRepository
    {
        private readonly QuotingRequestContext _context;       

        public InsuranceQuotingRequestRepository(IOptions<QuotingSettings> settings)
        {
            _context = new QuotingRequestContext(settings);
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<InsuranceQuotingRequest> GetAsync(Guid insurenceId)
        {
            var filter = Builders<InsuranceQuotingRequest>.Filter.Eq("Id", insurenceId);
            return await _context.InsuranceQuotingRequest
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(InsuranceQuotingRequest quote)
        {
            await _context.InsuranceQuotingRequest.ReplaceOneAsync(
                doc => doc.Id == quote.Id,
                quote,
                new UpdateOptions { IsUpsert = true });
        }

    }
}
