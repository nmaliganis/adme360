using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Users
{
    public class UserDoesNotActivatedAfterMadePersistentException : Exception
    {
        public string Login { get; private set; }

        public UserDoesNotActivatedAfterMadePersistentException(string login)
        {
            Login = login;
        }

        public override string Message => $" User with Login: {Login} was not Activated!";
    }
}
