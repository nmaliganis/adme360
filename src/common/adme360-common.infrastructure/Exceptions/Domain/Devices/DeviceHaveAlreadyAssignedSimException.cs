using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
  public class DeviceHaveAlreadyAssignedSimException : Exception
  {
    public Guid DeviceId { get; }
    public Guid SimcardId { get; }

    public DeviceHaveAlreadyAssignedSimException(Guid deviceId, Guid simcardId)
    {
      DeviceId = deviceId;
      SimcardId = simcardId;
    }
    public override string Message => $" Device with Id: {DeviceId} and Sim with Id:{SimcardId} already assigned";
  }
}