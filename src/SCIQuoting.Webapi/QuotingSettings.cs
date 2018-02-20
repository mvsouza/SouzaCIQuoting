using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIQuoting.Webapi
{
    public class QuotingSettings
    {
        public string EventBusConnection { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
