using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Roles;

namespace adme360.common.dtos.Vms.Users
{
    public class UserForRetrievalUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public List<RoleUiModel> Roles { get; set; }
        [Required]
        [Editable(true)]
        public bool IsActivated { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string RefreshToken { get; set; }
        [Editable(true)]
        public string Message { get; set; }
    }
}