using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
    public class DeviceDoesNotExistException : Exception
    {
      public string SerialNumber { get; }
      public Guid DeviceId { get; set; }

        public DeviceDoesNotExistException(Guid id)
        {
            DeviceId = id;
        }
        public DeviceDoesNotExistException(string serialNumber)
        {
          SerialNumber = serialNumber;
        }

        public override string Message => $"Device with id: {DeviceId} or SerialNumber: {SerialNumber} doesn't exist";
    }
}