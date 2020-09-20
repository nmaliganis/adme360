using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Users
{
    public class AuthUiModel : IUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string Token { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string RefreshToken { get; set; }

        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}