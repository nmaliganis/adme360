using System.ComponentModel.DataAnnotations;

namespace magic.button.collector.api.Vms.Dtos.Devices
{
    public class DeviceForModificationUiModel
    {
        [Required]
        [Editable(true)]
        public string DeviceNewName { get; set; }
    }
}
