using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Devices
{
    public class DeviceErrorModel
    {
        public string errorMessage { get; set; }
    }

  public class DeviceUiModel : IUiModel
  {
    [Key] public Guid Id { get; set; }

    public string Message { get; set; }
    [Required]
    [Editable(true)]
    public string DeviceImei { get; set; }
    [Required]
    [Editable(true)]
    public string DeviceSerialNumber { get; set; }
    [Required]
    [Editable(true)]
    public Guid DeviceActivationCode { get; set; }
    [Required]
    [Editable(true)]
    public Guid DeviceProvisioningCode { get; set; }
    [Required]
    [Editable(true)]
    public Guid DeviceResetCode { get; set; }
    [Required]
    [Editable(true)]
    public DateTime DeviceCreatedDate { get; set; }
    [Required]
    [Editable(true)]
    public Guid DeviceCreatedBy { get; set; }
    [Required]
    [Editable(true)]
    public DateTime DeviceModifiedDate { get; set; }
    [Required]
    [Editable(true)]
    public Guid DeviceModifiedBy { get; set; }
    [Required]
    [Editable(true)]
    public DateTime DeviceActivationDate { get; set; }
    [Required]
    [Editable(true)]
    public DateTime DeviceProvisioningDate { get; set; }
    [Required]
    [Editable(true)]
    public DateTime DeviceResetDate { get; set; }
    [Required]
    [Editable(true)]
    public Guid DeviceActivatedBy { get; set; }
    [Required]
    [Editable(true)]
    public Guid DeviceProvisioningBy { get; set; }
    [Required]
    [Editable(true)]
    public Guid DeviceResetBy { get; set; }
    [Required]
    [Editable(true)]
    public bool DeviceIsActivated { get; set; }
    [Required]
    [Editable(true)]
    public bool DeviceIsEnabled { get; set; }
    [Required]
    [Editable(true)]
    public bool DeviceIsActive { get; set; }

    [Required]
    [Editable(true)]
    public Guid DeviceContainerId { get; set; }
    [Required]
    [Editable(true)]
    public string DeviceContainerName { get; set; }
    [Editable(true)]
    public double DeviceContainerLat { get; set; }
    [Editable(true)]
    public double DeviceContainerLon { get; set; }
    [Editable(true)]
    public virtual string DeviceContainerImage { get; set; }
    [Editable(true)]
    public virtual DateTime DeviceContainerLastServiced { get; set; }
    [Editable(true)]
    public virtual int DeviceContainerType { get; set; }
    [Editable(true)]
    public virtual string DeviceContainerTypeValue { get; set; }

    [Required]
    [Editable(true)]
    public Guid DeviceDeviceModelId { get; set; }
    [Required]
    [Editable(true)]
    public string DeviceDeviceModelName { get; set; }

    [Required]
    [Editable(true)]
    public Guid DeviceSimcardId { get; set; }
    [Required]
    [Editable(true)]
    public string DeviceSimcardIccid { get; set; }
    [Required]
    [Editable(true)]
    public string DeviceSimcardNumber { get; set; }

    [Editable(true)]
    public virtual MeasurementUiModel DeviceMeasurementLast { get; set; }
    [Editable(true)]
    public virtual int DeviceMeasurementsCount { get; set; }

    [Editable(true)]
    public virtual int DeviceLocationsCount { get; set; }

    [Editable(true)]
    public virtual string DeviceComputedForLue => $"Imei:{DeviceImei} Serial Number:{DeviceSerialNumber}";
    [Editable(true)]
    public virtual LocationUiModel DeviceLocationLast { get; set; }
    [Required]
    [Editable(true)]
    public virtual string DeviceFirmwareName { get; set; }
  }
}