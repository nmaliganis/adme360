using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Accounts
{
    public class UserForModificationUiModel
    {
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Login { get; set; }
        [MaxLength(100)]
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public Guid Role { get; set; }
    }
}
