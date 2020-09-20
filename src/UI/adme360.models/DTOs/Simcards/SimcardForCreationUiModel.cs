using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Simcards
{
    public class SimcardForCreationUiModel
    {
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
        public int SimcardCardType { get; set; }
        [Required]
        [Editable(true)]
        public int SimcardNetworkType { get; set; }
        [Required]
        [Editable(true)]
        public bool SimcardIsEnabled { get; set; }


        [Editable(true)]
        public Guid SimcardDeviceId { get; set; }
    }
}