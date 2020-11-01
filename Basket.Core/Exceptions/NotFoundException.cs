using Microsoft.AspNetCore.Http;
using System;

namespace Basket.Core.Exceptions
{
    public class NotFoundException : Exception, IBaseException
    {   
        public NotFoundException(string message) : base(message)
        { 
        }

        public NotFoundException(string message, Exception exception) : base(message, exception)
        { 
        }
    }
}