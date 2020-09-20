using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Tours
{
    public class TourForAssignTrackableModel
    {
        [Required]
        [Editable(true)]
        public Guid EmployeeId { get; set; }
        [Required]
        [Editable(true)]
        public Guid TourId { get; set; }
        [Required]
        [Editable(true)]
        public DateTime ScheduledDate { get; set; }
        [Required]
        [Editable(true)]
        public string AssetNumplate { get; set; }
    }
}