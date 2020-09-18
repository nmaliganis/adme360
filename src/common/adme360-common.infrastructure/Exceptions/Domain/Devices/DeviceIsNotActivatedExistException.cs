using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
  public class DeviceIsNotActivatedExistException : Exception
  {
    public Guid DeviceId { get; set; }

    public DeviceIsNotActivatedExistException(Guid id)
    {
      DeviceId = id;
    }

    public override string Message => $"Device with id: {DeviceId} is not activated";
  }
}