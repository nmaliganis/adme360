using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Containers
{
    public class ContainerForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string ContainerName { get; set; }

        [Required] [Editable(true)] public int ContainerLevel { get; set; }
        [Required] [Editable(true)] public string ContainerFillLevel { get; set; }
        [Required] [Editable(true)] public double ContainerLat { get; set; }
        [Required] [Editable(true)] public double ContainerLong { get; set; }
        [Required] [Editable(true)] public string ContainerType { get; set; }
        [Required] [Editable(true)] public string ContainerStatus { get; set; }
        [Required] [Editable(true)] public string ContainerImagePath { get; set; }
        [Required] [Editable(true)] public string ContainerImageName { get; set; }
        [Editable(true)] public DateTime ContainerPickupDate { get; set; }
        [Editable(true)] public string ContainerPickupOption { get; set; }
        [Required] [Editable(true)] public bool ContainerPickupActive { get; set; }
        [Required] [Editable(true)] public bool ContainerFixed { get; set; }
        [Required] [Editable(true)] public int ContainerCapacity { get; set; }
        [Required] [Editable(true)] public int ContainerLoad { get; set; }
        [Required] [Editable(true)] public string ContainerWasteType { get; set; }
        [Required] [Editable(true)] public string ContainerMaterial { get; set; }
        [Editable(true)] public string ContainerDescription { get; set; }
    }

    public class ContainerForCreationModel : ContainerForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string ContainerAddress { get; set; }
    }
}