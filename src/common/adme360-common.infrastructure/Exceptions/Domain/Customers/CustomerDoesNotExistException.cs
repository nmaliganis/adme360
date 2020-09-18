using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Customers
{
    public class CustomerDoesNotExistException : Exception
    {
        public Guid CustomerId { get; }
        public string Vat { get; }

        public CustomerDoesNotExistException(Guid customerId)
        {
            CustomerId = customerId;
        }

        public CustomerDoesNotExistException(string vat)
        {
            Vat = vat;
        }

        public override string Message => $"Customer with Id: {CustomerId} or VAT:{Vat} doesn't exists!";
    }
}
