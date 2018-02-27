using System;
using System.Threading.Tasks;
using SCIQuoting.Webapi.Application.Models;

namespace SCIQuoting.Webapi.Infrastructure.Repositories{
    public interface IInsuranceQuotingRequestRepository
    {
        Task<InsuranceQuotingRequest> GetAsync(Guid insurenceKey);
        Task AddOrUpdateAsync(InsuranceQuotingRequest quoting);
    }
}