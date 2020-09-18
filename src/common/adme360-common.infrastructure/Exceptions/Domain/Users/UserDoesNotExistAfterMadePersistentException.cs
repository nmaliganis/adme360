using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Users
{
    public class UserDoesNotExistAfterMadePersistentException : Exception
    {
        public string Email { get; private set; }
        public string Login { get; private set; }

        public UserDoesNotExistAfterMadePersistentException(string login, string email)
        {
            Email = email;
            Login = login;
        }

        public override string Message => $" User with Name: {Email} and Login:{Login} was not made Persistent!";
    }
}