using System;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Bases;

namespace adme360.common.dtos.Vms.Devices
{
  public class DeviceActivationUiModel : IUiModel
  {
    [Key] public Guid Id { get; set; }
    [Editable(true)] public string Message { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Editable(true)]
    public virtual string ActivationStatus { get; set; }
    [Required(AllowEmptyStrings = false)]
    [Editable(true)]
    public virtual Guid DeviceId{ get; set; }
  }

  public class DeviceResettingUiModel : IUiModel
  {
    [Key] public Guid Id { get; set; }
    [Editable(true)] public string Message { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Editable(true)]
    public virtual string ActivationStatus { get; set; }
    [Required(AllowEmptyStrings = false)]
    [Editable(true)]
    public virtual Guid DeviceId{ get; set; }
  }

  public class DeviceEnablingStatusUiModel : IUiModel
  {
    [Key] public Guid Id { get; set; }
    [Editable(true)] public string Message { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Editable(true)]
    public virtual bool EnableStatus { get; set; }
    [Required(AllowEmptyStrings = false)]
    [Editable(true)]
    public virtual Guid DeviceId{ get; set; }
  }
}