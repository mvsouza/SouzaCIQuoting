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

    public class IsuranceBasePriceRepository : IIsuranceBasePriceRepository
    {
        private readonly QuotingRequestContext _context;       

        public IsuranceBasePriceRepository()
        {
        }


        public async Task<IEnumerable<IsuranceBasePrice>> GetAsync()
        {
            return (IEnumerable<IsuranceBasePrice>)new List<IsuranceBasePrice>(){
                
            };
        }
    }

}
