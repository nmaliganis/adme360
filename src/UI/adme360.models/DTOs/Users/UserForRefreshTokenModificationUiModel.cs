using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Users
{
    public class UserForRefreshTokenModificationUiModel
    {
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string RefreshToken { get; set; }
    }
}