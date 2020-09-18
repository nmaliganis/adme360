using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Accounts
{
    public class AccountForResetPasswordModification
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string OldPassword { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string NewPassword { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string ResetCode { get; set; }
    }
}