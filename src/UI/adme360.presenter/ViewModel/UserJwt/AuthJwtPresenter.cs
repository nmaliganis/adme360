using System;
using System.Net;
using dl.wm.presenter.Exceptions.UserJwts;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.LoginForget;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.UserJwt
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