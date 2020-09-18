using System;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Bases;

namespace adme360.common.dtos.Vms.Devices.Measurements
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