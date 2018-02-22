using System;
using System.Threading.Tasks;

namespace SCIQuoting.Webapi.Model{
    public class InsuranceQuotingRequest{
        public Guid Id { set; get; }
        public Costumer Costumer { get; private set; }
        public Vehicle Vehicle { get; private set; }
    }
}