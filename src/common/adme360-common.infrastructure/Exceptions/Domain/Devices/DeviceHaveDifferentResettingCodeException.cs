using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
  public class DeviceHaveDifferentResettingCodeException : Exception
  {
    public Guid ResettedCode { get; }
    public Guid ResettingCode { get; }

    public DeviceHaveDifferentResettingCodeException(Guid resettedCode, Guid resettingCode)
    {
      ResettedCode = resettedCode;
      ResettingCode = resettingCode;
    }
    public override string Message => $" Device with Reseted Code: {ResettedCode} and Resetting Code:{ResettingCode}";
  }
}