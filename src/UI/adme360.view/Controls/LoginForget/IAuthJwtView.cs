using System.Threading.Tasks;
using adme360.view;
using adme360.models.DTOs.Users;

namespace adme360.view.Controls.LoginForget
{
    public interface IAuthJwtView : IView
    {
        string OnMessageError { get; set; }
        AuthUiModel JwtAuthUiModel { get; set; }
        string OnBadRequestForUserJwtResult { set; }
    }
}
