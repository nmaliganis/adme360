using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Devices
{
    public class DeviceForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string DeviceImei { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)] public string DeviceSerialNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)] public string DeviceSimcardIccid { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)] public string DeviceSimcardImsi { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)] public string DeviceSimcardCountryIso { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)] public string DeviceSimcardNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)] public string DeviceSimcardType { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)] public string DeviceSimcardNetworkType { get; set; }
        [Required]
        [Editable(true)] public Guid DeviceDeviceModelId { get; set; }
    }
}