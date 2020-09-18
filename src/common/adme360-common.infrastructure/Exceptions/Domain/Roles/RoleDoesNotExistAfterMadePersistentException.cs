using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Roles
{
    public class RoleDoesNotExistAfterMadePersistentException : Exception
    {
        public string Name { get; private set; }

        public RoleDoesNotExistAfterMadePersistentException(string name)
        {
            Name = name;
        }

        public override string Message => $" Role with Name: {Name} was not made Persistent!";
    }
}