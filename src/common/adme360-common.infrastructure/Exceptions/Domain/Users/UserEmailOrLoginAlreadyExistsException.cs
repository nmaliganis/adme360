using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Users
{
    public class UserEmailOrLoginAlreadyExistsException : Exception
    {
        public string Email { get; }
        public string Login { get; }
        public string BrokenRules { get; }

        public UserEmailOrLoginAlreadyExistsException(string login, string email, string brokenRules)
        {
            Email = email;
            Login = login;
            BrokenRules = brokenRules;
        }

        public override string Message => $" User with enail:{Email} or/and login:{Login} already Exists!\n Additional info:{BrokenRules}";
    }
}