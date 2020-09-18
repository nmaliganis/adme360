using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Users
{
    public class UserDoesNotExistException : Exception
    {
        public Guid UserId { get; }

        public UserDoesNotExistException(Guid userId) => UserId = userId;
        public override string Message => $"User with Id: {UserId}  doesn't exists!";
    }
}
