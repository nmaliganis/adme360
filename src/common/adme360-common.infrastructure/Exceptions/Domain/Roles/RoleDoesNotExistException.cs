using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Roles
{
    public class RoleDoesNotExistException : Exception
    {
        public Guid RoleId { get; }
        public string RoleName { get; }

        public RoleDoesNotExistException(Guid roleId)
        {
            RoleId = roleId;
        }

        public RoleDoesNotExistException(string roleName)
        {
          RoleName = roleName;
        }

        public override string Message => $"Role with Id: {RoleId} or Name:{RoleName} doesn't exists!";
    }
}
