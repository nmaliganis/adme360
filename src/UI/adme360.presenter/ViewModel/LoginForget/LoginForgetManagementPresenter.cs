using System;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.LoginForget;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.LoginForget
{
    public class LoginForgetManagementPresenter : BasePresenter<ILoginForgetManagementView, IUsersService>
    {

        public LoginForgetManagementPresenter(ILoginForgetManagementView view)
            : this(view, new UsersService())
        {
        }

        public LoginForgetManagementPresenter(ILoginForgetManagementView view, IUsersService service)
            : base(view, service)
        {
        }

        public void LoginLoginWasClicked()
        {
            PrepareUiCtrlsAfterLoginSelection();
            View.CheckForAuthentication = true;
        }

        private void PrepareUiCtrlsAfterLoginSelection()
        {
            View.BtnLoginLoginEnabled = false;
            View.BtnLoginCancelEnabled = false;
            View.TxtLoginUsernameEnabled = false;
            View.TxtLoginPasswordEnabled = false;
        }

        public void LoginCancelWasClicked()
        {
            View.CloseOnDemandFlyout = true;
        }

        public void ForgetSendWasClicked()
        {
            
        }

        public void LoginUsernameValueChanged()
        {
            
        }

        public void LoginPasswordValueChanged()
        {
            
        }

        public void ForgetUsernameValueChanged()
        {
            
        }

        public void JwtWasReceived()
        {
            View.TxtLoginUsernameValue = "";
            View.TxtLoginPasswordValue = "";
            View.OnDemandSuccessBannerShow = true;
        }

        public void UcFlyoutloginForgetWasLoaded()
        {
            View.PanelResultVisible = false;
        }

        public void TimerSuccessWasCatch()
        {
            View.CloseFlyoutAfterSuccess = true;
        }

        public void TimerErrorWasCatch()
        {
            PrepareUiCtrlsAfterErrorTimerCatch();
        }

        private void PrepareUiCtrlsAfterErrorTimerCatch()
        {
            View.TxtLoginUsernameValue = String.Empty;
            View.TxtLoginPasswordValue = String.Empty;

            View.BtnLoginLoginEnabled = true;
            View.BtnLoginCancelEnabled = true;
            View.TxtLoginUsernameEnabled = true;
            View.TxtLoginPasswordEnabled = true;
            View.PanelResultVisible = false;
        }
    }
}