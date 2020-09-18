using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Devices
{
  public class DeviceForResetModel
  {
    [Required]
    [Editable(true)] public Guid DeviceResetCode { get; set; }
  }
}