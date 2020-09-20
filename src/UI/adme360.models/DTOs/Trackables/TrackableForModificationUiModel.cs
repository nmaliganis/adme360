using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.suite.common.dtos.Vms.Trackables
{
    public class TrackableForModificationUiModel : IUiModel
    {
        [Required]
        [Editable(true)] public string TrackableName { get; set; }
        [Required]
        [Editable(true)] public string TrackableModel { get; set; }
        [Required]
        [Editable(true)] public string TrackableVendorId { get; set; }
        [Required]
        [Editable(true)] public string TrackablePhone { get; set; }
        [Required]
        [Editable(true)] public string TrackableOs { get; set; }
        [Required]
        [Editable(true)] public string TrackableVersion { get; set; }
        [Editable(true)] public string TrackableNotes { get; set; }

        [Key] public Guid Id { get; set; }
        public string Message { get; set; }
    }
}