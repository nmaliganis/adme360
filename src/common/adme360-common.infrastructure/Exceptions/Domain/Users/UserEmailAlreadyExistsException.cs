using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Users
{
    public class UserEmailAlreadyExistsException : Exception
    {
        public string Email { get; }
        public string BrokenRules { get; }

        public UserEmailAlreadyExistsException(string email, string brokenRules)
        {
            Email = email;
            BrokenRules = brokenRules;
        }

        public override string Message => $" User with enail:{Email} already Exists!\n Additional info:{BrokenRules}";
    }
}
