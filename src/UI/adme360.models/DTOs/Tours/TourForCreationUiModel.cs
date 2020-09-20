using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Tours
{
    public class TourForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string TourName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string TourType { get; set; }
        [Required]
        [Editable(true)]
        public Guid TourAssetId { get; set; }
        [Required]
        [Editable(true)]
        public DateTime TourScheduledDate { get; set; }
        [Required]
        [Editable(true)]
        public Guid[] TourEmployees { get; set; }
        [Editable(true)]
        public Guid[] TourContainers { get; set; }
    }
}