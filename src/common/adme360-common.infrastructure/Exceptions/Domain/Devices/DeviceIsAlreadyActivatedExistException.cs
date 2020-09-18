using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
  public class DeviceIsAlreadyActivatedExistException : Exception
  {
    public Guid DeviceId { get; set; }

    public DeviceIsAlreadyActivatedExistException(Guid id)
    {
      DeviceId = id;
    }

    public override string Message => $"Device with id: {DeviceId} is already activated";
  }
}