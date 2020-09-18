using System.ComponentModel.DataAnnotations;

namespace magic.button.collector.api.Vms.Dtos.Devices
{
  public class DeviceForCreationUiModel
  {
    [Required(AllowEmptyStrings = false)]
    [Editable(true)]
    public string Name { get; set; }
  }
}
