using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Tours
{
    public class TourErrorModel
    {
        public string errorMessage { get; set; }
    }

    public class TourUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string TourName { get; set; }
        [Required]
        [Editable(true)]
        public DateTime TourScheduledDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string TourAssetBrand { get; set; }
        [Required]
        [Editable(true)]
        public bool TourActive { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string TourType { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string TourStatus { get; set; }
        [Required]
        [Editable(false)]
        public int TourStatusValue { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public DateTime TourCreatedDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string TourCreatedByName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string TourAssetNumPlate { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string TourAssetType { get; set; }
        [Required]
        [Editable(false)]
        public int TourAssetTypeValue { get; set; }
        [Required]
        [Editable(false)]
        public int TourNumberOfEmployees { get; set; }
        [Required]
        [Editable(false)]
        public int TourNumberOfContainer { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string TourAddressStart { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string TourAddressEnd { get; set; }
    }
}