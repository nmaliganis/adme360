using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
  public class DeviceDoesNotExistAfterMadeTransientException : Exception
  {
    public Guid DeviceId { get; private set; }
    public string SerialNumber { get; private set; }

    public DeviceDoesNotExistAfterMadeTransientException(string serialNumber)
    {
      SerialNumber = serialNumber;
    }
    public DeviceDoesNotExistAfterMadeTransientException(Guid deviceId)
    {
      DeviceId = DeviceId;
    }

    public override string Message => $" Device with serialNumber: {SerialNumber} or Id: {DeviceId} was not made Transient!";
  }
}