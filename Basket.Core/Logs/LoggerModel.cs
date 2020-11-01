using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Logs
{
    public class LoggerModel
    {
        public string RequestHost { get; set; }
        public string RequestProtocol { get; set; }
        public string RequestMethod { get; set; }
        public string RequestPath { get; set; }
        public string RequestPathAndQuery { get; set; }
        public int ResponseStatusCode { get; set; }
        public Dictionary<string, object> RequestHeaders { get; set; }
        public long? ElapsedMilliseconds { get; set; }
        public string RequestBody { get; set; }
        public Exception Exception { get; set; }
        public string Data { get; set; }
    }
}
