using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Devices
{
    public class MeasurementUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Message { get; set; }
    
        [Required]
        [Editable(true)]
        public virtual DateTime MeasurementCreatedDate { get; set; }
        [Required]
        [Editable(true)]
        public virtual DateTime MeasurementModifiedDate { get; set; }
        [Required]
        [Editable(true)]
        public virtual string MeasurementJsonbValue { get; set; }
    }
}