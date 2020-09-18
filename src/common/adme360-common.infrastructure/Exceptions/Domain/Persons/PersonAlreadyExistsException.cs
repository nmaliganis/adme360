using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Persons
{
    public class PersonAlreadyExistsException : Exception
    {
        public string Email { get; }
        public string BrokenRules { get; }

        public PersonAlreadyExistsException(string email, string brokenRules)
        {
            Email = email;
            BrokenRules = brokenRules;
        }

        public override string Message => $" Person with email:{Email} already Exists!\n Additional info:{BrokenRules}";
    }
}
