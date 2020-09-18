using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Roles
{
    public class RoleForModificationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string ModifiedName { get; set; }
    }
}
