using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Devices
{
    public class DeviceForModificationUiModel : IUiModel
    {
        [Key] public Guid Id { get; set; }
        public string Message { get; set; }
        [Required]
        [Editable(true)]
        public virtual string DeviceImei { get; set; }
        [Required]
        [Editable(true)]
        public virtual string DeviceSerialNumber { get; set; }

    }
}