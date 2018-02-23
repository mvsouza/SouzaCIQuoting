namespace SCIQuoting.Webapi.Infrastructure.Repositories
{
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.GeoJsonObjectModel;
    using SCIQuoting.Webapi.Infrastructure.Infrastructure;
    using SCIQuoting.Webapi.Application.Models;
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

        public async Task AddOrUpdateAsync(InsuranceQuotingRequest quote)
        {
            if(_context.InsuranceQuotingRequest.Count(doc => doc.Id == quote.Id)>0){
                await _context.InsuranceQuotingRequest.ReplaceOneAsync(
                    doc => doc.Id == quote.Id,
                    quote,
                    new UpdateOptions { IsUpsert = true });
            }
            else{
                await _context.InsuranceQuotingRequest.InsertOneAsync(quote);
            }
        }

    }
}
