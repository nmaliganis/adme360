using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Persons
{
    public class PersonDoesNotExistException : Exception
    {
        public Guid PersonId { get; }

        public PersonDoesNotExistException(Guid personId)
        {
            PersonId = personId;
        }

        public override string Message => $"Person with Id: {PersonId}  doesn't exists!";
    }
}
