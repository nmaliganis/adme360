using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Devices
{
  public class DeviceForEnableModel
  {
    [Required]
    [Editable(true)] public bool DeviceEnableStatus{ get; set; }
  }
}