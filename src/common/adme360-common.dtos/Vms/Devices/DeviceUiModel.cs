using System;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Bases;
using adme360.common.dtos.Vms.Devices.Measurements;

namespace adme360.common.dtos.Vms.Devices
{
  public class DeviceUiModel : IUiModel
  {
    [Key] public Guid Id { get; set; }

    public string Message { get; set; }
    [Required]
    [Editable(true)]
    public virtual string DeviceSerialNumber { get; set; }
    [Required]
    [Editable(true)]
    public virtual Guid DeviceActivationCode { get; set; }
    [Required]
    [Editable(true)]
    public virtual Guid DeviceProvisioningCode { get; set; }
    [Required]
    [Editable(true)]
    public virtual Guid DeviceResetCode { get; set; }
    [Required]
    [Editable(true)]
    public virtual DateTime DeviceCreatedDate { get; set; }
    [Required]
    [Editable(true)]
    public virtual Guid DeviceCreatedBy { get; set; }
    [Required]
    [Editable(true)]
    public virtual DateTime DeviceModifiedDate { get; set; }
    [Required]
    [Editable(true)]
    public virtual Guid DeviceModifiedBy { get; set; }
    [Required]
    [Editable(true)]
    public virtual DateTime DeviceActivationDate { get; set; }
    [Required]
    [Editable(true)]
    public virtual DateTime DeviceProvisioningDate { get; set; }
    [Required]
    [Editable(true)]
    public virtual DateTime DeviceResetDate { get; set; }
    [Required]
    [Editable(true)]
    public virtual Guid DeviceActivatedBy { get; set; }
    [Required]
    [Editable(true)]
    public virtual Guid DeviceProvisioningBy { get; set; }
    [Required]
    [Editable(true)]
    public virtual Guid DeviceResetBy { get; set; }
    [Required]
    [Editable(true)]
    public virtual bool DeviceIsActivated { get; set; }
    [Required]
    [Editable(true)]
    public virtual bool DeviceIsEnabled { get; set; }
    [Required]
    [Editable(true)]
    public virtual bool DeviceIsActive { get; set; }

    [Editable(true)]
    public virtual MeasurementUiModel DeviceMeasurementLast { get; set; }

    [Editable(true)]
    public virtual int DeviceMeasurementsCount { get; set; }
  }
}