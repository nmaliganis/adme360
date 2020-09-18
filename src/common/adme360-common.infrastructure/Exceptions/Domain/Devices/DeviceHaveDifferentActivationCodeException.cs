using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
  public class DeviceHaveDifferentActivationCodeException : Exception
  {
    public Guid ActivatedCode { get; }
    public Guid ActivationCode { get; }

    public DeviceHaveDifferentActivationCodeException(Guid activatedCode, Guid activationCode)
    {
      ActivatedCode = activatedCode;
      ActivationCode = activationCode;
    }
    public override string Message => $" Device with Activated Code: {ActivatedCode} and Activation Code:{ActivationCode}";
  }
}