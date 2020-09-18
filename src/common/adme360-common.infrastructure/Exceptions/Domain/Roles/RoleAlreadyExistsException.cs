using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Roles
{
    public class RoleAlreadyExistsException : Exception
    {
        public string Name { get; }
        public string BrokenRules { get; }

        public RoleAlreadyExistsException(string name, string brokenRules)
        {
            Name = name;
            BrokenRules = brokenRules;
        }

        public override string Message => $" Role with Name:{Name} already Exists!\n Additional info:{BrokenRules}";
    }
}
