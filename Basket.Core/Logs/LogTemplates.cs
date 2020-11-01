using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Logs
{
    public class LogTemplates
    {
        public static readonly string Error = $"ERROR: HTTP {"{" + nameof(LoggerModel.RequestMethod) + "}"} / {"{" + nameof(LoggerModel.RequestPathAndQuery) + "}"} responded as {"{" + nameof(LoggerModel.ResponseStatusCode) + "}"}";
    }
}
