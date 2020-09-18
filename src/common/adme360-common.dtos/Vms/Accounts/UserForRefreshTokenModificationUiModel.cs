using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Accounts
{
    public class UserForRefreshTokenModificationUiModel
    {
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string RefreshToken { get; set; }
    }
}