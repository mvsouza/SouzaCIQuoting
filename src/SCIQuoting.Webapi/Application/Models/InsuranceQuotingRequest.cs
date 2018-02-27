using System;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SCIQuoting.Webapi.Application.Models{
    public class InsuranceQuotingRequest{
        public ObjectId Id { get; set; }
        public Guid Key { set; get; }
        public Costumer Costumer { get; set; }
        public Vehicle Vehicle { get; set; }
        public QuoteProcessStatus QuoteProcessStatus { get; set; }
    }
}