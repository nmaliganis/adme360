using adme360.view;

namespace adme360.view.Controls.LoginForget
{
    public interface ILoginForgetManagementView : IView
    {
        bool TxtLoginUsernameEnabled { get; set; }
        bool TxtLoginPasswordEnabled { get; set; }
        bool TxtForgetUsernameEnabled { get; set; }

        bool BtnLoginLoginEnabled { get; set; }
        bool BtnLoginCancelEnabled { get; set; }
        bool BtnForgetSendEnabled { get; set; }

        bool PanelResultVisible { get; set; }


        string TxtLoginUsernameValue { get; set; }
        string TxtLoginPasswordValue { get; set; }
        string TxtForgetLoginValue { get; set; }
        bool CheckForAuthentication { set; }
        bool CloseOnDemandFlyout { set; }
        bool OnDemandSuccessBannerShow {  set; }
        bool CloseFlyoutAfterSuccess { set; }
    }
}
