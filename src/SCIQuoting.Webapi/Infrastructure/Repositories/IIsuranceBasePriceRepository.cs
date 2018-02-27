using SCIQuoting.Webapi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIQuoting.Webapi.Infrastructure.Repositories
{
    public interface IIsuranceBasePriceRepository
    {
        Task<IEnumerable<IsuranceBasePrice>> GetAsync();
    }
}
