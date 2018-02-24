namespace SCIQuoting.Webapi.Application.Models{
    public enum QuoteStatus{
        Pendding = 1,
        Done = 2
    }
    public class QuoteProcessStatus{
        public decimal ValueQuoted { get; set; }
        public QuoteStatus Status { get; set; }
    }
}