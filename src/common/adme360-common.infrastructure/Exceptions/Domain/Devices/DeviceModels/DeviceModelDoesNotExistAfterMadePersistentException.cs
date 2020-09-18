using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices.DeviceModels
{
    public class DeviceModelDoesNotExistAfterMadePersistentException : Exception
    {
        public string DeviceModelName { get; }

        public DeviceModelDoesNotExistAfterMadePersistentException(string name)
        {
            DeviceModelName = name;
        }

        public override string Message => $" Device Model with Name: {DeviceModelName}, was not made Persistent!";
    }
}