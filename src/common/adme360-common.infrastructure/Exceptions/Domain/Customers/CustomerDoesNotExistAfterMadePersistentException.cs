using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Customers
{
    public class CustomerDoesNotExistAfterMadePersistentException : Exception
    {
        public string Vat { get; private set; }
        public Guid Id { get; private set; }

        public CustomerDoesNotExistAfterMadePersistentException(string vat)
        {
            Vat = vat;
        }

        public CustomerDoesNotExistAfterMadePersistentException(Guid id)
        {
            Id = id;
        }

        public override string Message => $" Customer with Id: {Id} or with VAT: {Vat} was not made Persistent!";
    }
}