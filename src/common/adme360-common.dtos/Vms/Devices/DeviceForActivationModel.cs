using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Devices
{
  public class DeviceForActivationModel
  {
    [Required]
    [Editable(true)] public Guid DeviceActivationCode { get; set; }
  }
}