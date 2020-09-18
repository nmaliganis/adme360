using System;
using System.ComponentModel.DataAnnotations;

namespace magic.button.collector.api.Vms.Dtos.Devices
{
    public class DeviceUiModel
    {
        [Editable(true)]
        public Guid id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Name { get; set; }
    }
}
