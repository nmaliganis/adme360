using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Customers
{
    public class InvalidCustomerException : Exception
    {
        public string BrokenRules { get; private set; }

        public InvalidCustomerException(string brokenRules)
        {
            BrokenRules = brokenRules;
        }
    }
}
