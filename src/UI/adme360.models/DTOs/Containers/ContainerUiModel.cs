using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Containers
{
    public class ContainerErrorModel
    {
        public string errorMessage { get; set; }
    }

    public class ContainerUiModel : IUiModel
    {
        [Key] public Guid Id { get; set; }
        [Editable(true)] public string Message { get; set; }


        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public virtual string ContainerName { get; set; }

        [Required] [Editable(true)] public int ContainerLevel { get; set; }
        [Required] [Editable(true)] public string ContainerFillLevel { get; set; }
        [Required] [Editable(true)] public double ContainerLocationLat { get; set; }
        [Required] [Editable(true)] public double ContainerLocationLong { get; set; }
        [Required] [Editable(true)] public double ContainerTimeFull { get; set; }
        [Required] [Editable(true)] public DateTime ContainerLastServicedDate { get; set; }
        [Required] [Editable(true)] public DateTime ContainerCreatedDate { get; set; }
        [Required] [Editable(true)] public DateTime ContainerModifiedDate { get; set; }
        [Required] [Editable(true)] public Guid ContainerCreatedBy { get; set; }
        [Required] [Editable(true)] public Guid ContainerModifiedBy { get; set; }
        [Required] [Editable(true)] public string ContainerType { get; set; }
        [Required] [Editable(true)] public string ContainerStatus { get; set; }
        [Required] [Editable(true)] public string ContainerTypeValue { get; set; }
        [Required] [Editable(true)] public string ContainerStatusValue { get; set; }

        [Required] [Editable(true)] public string ContainerImagePath { get; set; }
        [Required] [Editable(true)] public string ContainerImageName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public virtual string ContainerAddress { get; set; }

        [Editable(true)] public DateTime ContainerMandatoryPickupDate 
        {
            get;
            set;
        }
        [Editable(true)] public string ContainerMandatoryPickupOption { get; set; }
        [Required] [Editable(true)] public bool ContainerMandatoryPickupActive { get; set; }

        [Required] [Editable(true)] public int ContainerCapacity { get; set; }
        [Required] [Editable(true)] public int ContainerLoad { get; set; }
        [Required] [Editable(true)] public string ContainerWasteType { get; set; }
        [Required] [Editable(true)] public string ContainerWasteTypeValue { get; set; }
        [Required] [Editable(true)] public string ContainerMaterial { get; set; }
        [Required] [Editable(true)] public string ContainerMaterialValue { get; set; }
        [Required] [Editable(true)] public bool ContainerFixed { get; set; }
        [Required] [Editable(true)] public string ContainerDescription { get; set; }
    }
}
