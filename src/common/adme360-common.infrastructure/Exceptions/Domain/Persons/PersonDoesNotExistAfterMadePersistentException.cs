using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Persons
{
    public class PersonDoesNotExistAfterMadePersistentException : Exception
    {
        public string Email { get; private set; }

        public PersonDoesNotExistAfterMadePersistentException(string email)
        {
            Email = email;
        }

        public override string Message => $" Person with Name: {Email} was not made Persistent!";
    }
}