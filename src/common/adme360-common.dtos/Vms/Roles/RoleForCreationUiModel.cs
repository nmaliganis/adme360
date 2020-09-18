using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Roles
{
    public class RoleForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Name { get; set; }
    }
}