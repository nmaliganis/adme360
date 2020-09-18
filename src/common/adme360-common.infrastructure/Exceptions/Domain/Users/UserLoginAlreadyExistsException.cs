using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Users
{
    public class UserLoginAlreadyExistsException : Exception
    {
        public string Login { get; }
        public string BrokenRules { get; }

        public UserLoginAlreadyExistsException(string login, string brokenRules)
        {
            Login = login;
            BrokenRules = brokenRules;
        }

        public override string Message => $" User with enail:{Login} already Exists!\n Additional info:{BrokenRules}";
    }
}
