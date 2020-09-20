using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Devices
{
    public class LocationUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Message { get; set; }

        [Required]
        [Editable(true)]
        public double LocationPointLat { get; set; }
        [Required]
        [Editable(true)]
        public double LocationPointLon { get; set; }
        [Required]
        [Editable(true)]
        public double LocationAltitude { get; set; }
        [Required]
        [Editable(true)]
        public double LocationAngle { get; set; }
        [Required]
        [Editable(true)]
        public int LocationSatellites { get; set; }
        [Required]
        [Editable(true)]
        public double LocationSpeed { get; set; }
        [Required]
        [Editable(true)]
        public DateTime LocationCreatedDate { get; set; }
        [Required]
        [Editable(true)]
        public DateTime LocationModifiedDate { get; set; }
        [Required]
        [Editable(true)]
        public double LocationBearing { get; set; }
        [Required]
        [Editable(true)]
        public int LocationTimeToFix { get; set; }
        [Required]
        [Editable(true)]
        public int LocationStatusFlag { get; set; }
        [Required]
        [Editable(true)]
        public int LocationSignalLength { get; set; }
        [Required]
        [Editable(true)]
        public DateTime LocationTimestamp { get; set; }
    }
}