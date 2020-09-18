using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
    public class DeviceHaveDifferentProvisioningException : Exception
    {
      public Guid ProvisionCode { get; }
      public Guid ProvisioningCode { get; }

      public DeviceHaveDifferentProvisioningException(Guid provisionCode, Guid provisioningCode)
      {
        ProvisionCode = provisionCode;
        ProvisioningCode = provisioningCode;
      }
        public override string Message => $" Device with Provisioned Code: {ProvisionCode} and Provisioning Code:{ProvisioningCode}";
    }
}