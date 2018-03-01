using System;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SCIQuoting.Webapi.Application.Models{
    public class QuoteRequestViewModel{
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}