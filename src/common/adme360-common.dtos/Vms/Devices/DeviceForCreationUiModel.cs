using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Devices
{
  public class DeviceForCreationUiModel
  {
    [Required(AllowEmptyStrings = false)]
    [Editable(true)]
    public string DeviceSerialNumber { get; set; }
  }
}