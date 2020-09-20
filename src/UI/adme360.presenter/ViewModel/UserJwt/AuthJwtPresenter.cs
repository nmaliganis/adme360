using System;
using System.Net;
using adme360.presenter.Base;
using adme360.presenter.Exceptions.UserJwts;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.LoginForget;

namespace adme360.presenter.ViewModel.UserJwt
{
    public class AuthJwtPresenter : BasePresenter<IAuthJwtView, IUserJwtService>
    {

        public AuthJwtPresenter(IAuthJwtView view)
            : this(view, new UserJwtService())
        {
        }

        public AuthJwtPresenter(IAuthJwtView view, IUserJwtService service)
            : base(view, service)
        {
        }

        public async void LoginWasSelected(string username, string password)
        {
            try
            {
                var result = await Service.PostJwtUserAsync(username, password);

                if (result.Message == HttpStatusCode.BadRequest.ToString())
                {
                    View.OnBadRequestForUserJwtResult = result.Message;
                }
                else
                {
                    View.JwtAuthUiModel = result;
                }
            }
            catch (BadRequestForUserJwtWasCatch ex)
            {
                View.OnBadRequestForUserJwtResult= ex.Message;
            }
            catch (Exception e)
            {
                //Todo: Should be enriched to support extra info and logs 
            }
        }
    }
}