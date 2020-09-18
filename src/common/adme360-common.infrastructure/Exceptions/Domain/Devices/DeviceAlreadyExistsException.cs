using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
    public class DeviceAlreadyExistsException : Exception
    {
      public string BrokenRules { get; }
      public string DeviceSerialNumber { get; }


        public DeviceAlreadyExistsException(string serialNumber, string brokenRules)
        {
          DeviceSerialNumber = serialNumber;
          BrokenRules = brokenRules;
        }

        public override string Message => $" Device with Serial Number: {DeviceSerialNumber} already Exists! Details : {BrokenRules}";
    }
}