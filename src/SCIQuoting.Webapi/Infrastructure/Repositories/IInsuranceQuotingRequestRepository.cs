using System;
using System.Threading.Tasks;
using SCIQuoting.Webapi.Model;

namespace SCIQuoting.Webapi.Infrastructure.Repositories{
    public interface IInsuranceQuotingRequestRepository
    {
        Task<InsuranceQuotingRequest> GetAsync(Guid insurenceId);
        Task AddOrUpdateAsync(InsuranceQuotingRequest quoting);
    }
}