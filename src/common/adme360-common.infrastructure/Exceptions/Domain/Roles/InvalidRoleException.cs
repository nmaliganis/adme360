using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Roles
{
    public class InvalidRoleException : Exception
    {
        public string BrokenRules { get; private set; }

        public InvalidRoleException(string brokenRules)
        {
            BrokenRules = brokenRules;
        }
    }
}