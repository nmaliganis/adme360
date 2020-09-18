using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
    public class InvalidDeviceException : Exception
    {
        public string BrokenRules { get; private set; }

        public InvalidDeviceException(string brokenRules)
        {
            BrokenRules = brokenRules;
        }
    }
}