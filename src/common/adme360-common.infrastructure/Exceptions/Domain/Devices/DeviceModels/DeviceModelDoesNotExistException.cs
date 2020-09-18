using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices.DeviceModels
{
    public class DeviceModelDoesNotExistException : Exception
    {
        public Guid DeviceId { get; set; }

        public DeviceModelDoesNotExistException(Guid id)
        {
            DeviceId = id;
        }

        public override string Message => $"Device Model with id: {DeviceId} doesn't exist";
    }
}