using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices.DeviceModels
{
    public class InvalidDeviceModelException : Exception
    {
        public string BrokenRules { get; private set; }

        public InvalidDeviceModelException(string brokenRules)
        {
            BrokenRules = brokenRules;
        }
    }
}