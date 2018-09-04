using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTest.Domain.SeedWork.Exception
{
    public abstract class AbstractException : System.Exception
    {
        public const string DefaultMessage = "An unexpected error ocurred. Please contact our support or try again latter";

        public AbstractException(string message) : base(message)
        {
        }

        public AbstractException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
