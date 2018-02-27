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
                new IsuranceBasePrice(VehicleType.Car, 2000, "Fit", "Honda", 1345),
                new IsuranceBasePrice(VehicleType.Motocycle, 2000, "Bis", "Honda", 1001),
                new IsuranceBasePrice(VehicleType.Car, 2000, "Corsa", "Chev", 1034),
                new IsuranceBasePrice(VehicleType.Car, 2000, "Uno", "Fiat", 1004),
                new IsuranceBasePrice(VehicleType.Car, 2000, "Palio", "Fiat", 1245)

            };
        }
    }

}
