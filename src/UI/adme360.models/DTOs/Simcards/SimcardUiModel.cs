using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;
using adme360.models.DTOs.Devices;

namespace adme360.models.DTOs.Simcards
{
    public class SimcardErrorModel
    {
        public string errorMessage { get; set; }
    }
    public class SimcardUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Message { get; set; }
    
        [Required]
        [Editable(true)]
        public string SimcardIccid { get; set; }
        [Required]
        [Editable(true)]
        public string SimcardImsi { get; set; }
        [Required]
        [Editable(true)]
        public string SimcardCountryIso { get; set; }
        [Required]
        [Editable(true)]
        public string SimcardNumber { get; set; }
        [Required]
        [Editable(true)]
        public DateTime SimcardPurchaseDate { get; set; }
        [Required]
        [Editable(true)]
        public DateTime SimcardCreatedDate { get; set; }
        [Required]
        [Editable(true)]
        public int SimcardCardType { get; set; }
        [Required]
        [Editable(true)]
        public string SimcardCardTypeValue { get; set; }
        [Required]
        [Editable(true)]
        public int SimcardNetworkType { get; set; }
        [Required]
        [Editable(true)]
        public string SimcardNetworkTypeValue { get; set; }
        [Required]
        [Editable(true)]
        public bool SimcardIsEnabled { get; set; }
        [Editable(true)]
        public Guid SimcardDeviceId { get; set; }
        [Editable(true)]
        public DeviceUiModel SimcardDevice { get; set; }

        [Editable(true)]
        public bool SimcardHasDevice => SimcardDeviceId != Guid.Empty;
    }
}