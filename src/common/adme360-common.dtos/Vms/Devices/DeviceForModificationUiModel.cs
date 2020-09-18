using System;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Bases;

namespace adme360.common.dtos.Vms.Devices
{
    public class DeviceForModificationUiModel : IUiModel
    {
        [Key] public Guid Id { get; set; }
        public string Message { get; set; }
        [Required]
        [Editable(true)]
        public virtual bool DeviceStatusEnabled { get; set; }
        [Required]
        [Editable(true)]
        public virtual string DeviceSerialNumber { get; set; }

    }
}