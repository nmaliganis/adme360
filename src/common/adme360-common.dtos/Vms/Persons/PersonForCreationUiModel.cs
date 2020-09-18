using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Persons
{
    public class PersonForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string PersonLogin { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string PersonEmail { get; set; }
    }
}