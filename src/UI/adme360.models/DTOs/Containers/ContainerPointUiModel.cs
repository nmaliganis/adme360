using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Containers
{
    public class ContainerPointUiModel : IUiModel
    {
        [Key] public Guid Id { get; set; }
        [Editable(true)] public string Message { get; set; }


        [Required] [Editable(true)] public virtual string ContainerPointType { get; set; }
        [Required] [Editable(true)] public virtual double ContainerLat { get; set; }
        [Required] [Editable(true)] public virtual double ContainerLon { get; set; }
    }
}