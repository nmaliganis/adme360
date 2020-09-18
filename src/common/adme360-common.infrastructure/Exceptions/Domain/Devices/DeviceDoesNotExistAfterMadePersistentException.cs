using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
    public class DeviceDoesNotExistAfterMadePersistentException : Exception
    {
        public string DeviceSerialNumber { get; }

        public DeviceDoesNotExistAfterMadePersistentException(string deviceSerialNumber)
        {
          DeviceSerialNumber = deviceSerialNumber;
        }

        public override string Message => $" Device with Serial Number: {DeviceSerialNumber} was not made Persistent!";
    }
}