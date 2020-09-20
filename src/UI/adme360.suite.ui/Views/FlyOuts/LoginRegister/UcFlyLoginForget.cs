using System;
using System.Windows.Forms;
using adme360.models.DTOs.Users;
using adme360.presenter.Utilities;
using adme360.presenter.ViewModel.LoginForget;
using adme360.presenter.ViewModel.UserJwt;
using adme360.suite.ui.Controls;
using adme360.suite.ui.Views.FlyOuts.LoginRegister.Ucs;
using adme360.view.Controls.LoginForget;

namespace adme360.suite.ui.Views.FlyOuts.LoginRegister
{
    public partial class UcFlyLoginForget : BaseModule, IAuthJwtView, ILoginForgetManagementView
    {
        public UserUiModel UserToBeLoginIn { get; private set; }

        #region Presenters

        private AuthJwtPresenter _authJwtPresenter;
        private LoginForgetManagementPresenter _loginForgetManagementPresenter;
        #endregion

        public UcFlyLoginForget(string eText, UserUiModel userToBeLoginIn)
        {
            UserToBeLoginIn = userToBeLoginIn;
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _authJwtPresenter = new AuthJwtPresenter(this);
            _loginForgetManagementPresenter = new LoginForgetManagementPresenter(this);
        }

        public bool TxtLoginUsernameEnabled
        {
            get => txtLoginUsername.Enabled;
            set => txtLoginUsername.Enabled = value;
        }

        public bool TxtLoginPasswordEnabled
        {
            get => txtLoginPassword.Enabled;
            set => txtLoginPassword.Enabled = value;
        }

        public bool TxtForgetUsernameEnabled
        {
            get => txtForgetUsername.Enabled;
            set => txtLoginPassword.Enabled = value;
        }

        public bool BtnLoginLoginEnabled
        {
            get => btnLoginLogin.Enabled;
            set => btnLoginLogin.Enabled = value;
        }

        public bool BtnLoginCancelEnabled
        {
            get => btnLoginCancel.Enabled;
            set => btnLoginCancel.Enabled = value;
        }

        public bool BtnForgetSendEnabled
        {
            get => btnForgetSend.Enabled;
            set => btnForgetSend.Enabled = value;
        }

        public bool PanelResultVisible
        {
            get => pnlCntrlResult.Visible;
            set => pnlCntrlResult.Visible = value;
        }

        public string TxtLoginUsernameValue
        {
            get => txtLoginUsername.Text;
            set => txtLoginUsername.Text = value;
        }

        public string TxtLoginPasswordValue
        {
            get => txtLoginPassword.Text;
            set => txtLoginPassword.Text = value;
        }

        public string TxtForgetLoginValue
        {
            get => txtForgetUsername.Text;
            set => txtForgetUsername.Text = value;
        }

        public bool CheckForAuthentication
        {
            set
            {
                if (value)
                {
                    _authJwtPresenter.LoginWasSelected(TxtLoginUsernameValue, TxtLoginPasswordValue);
                }
            }
        }

        public bool CloseOnDemandFlyout
        {
            set
            {
                if (value)
                {
                    UserToBeLoginIn.Message = "cancel";
                    UserToBeLoginIn.Token = "";
                    UserToBeLoginIn.RefreshToken = "";
                    UserToBeLoginIn.Login = "";
                    (this.Parent as CustomFlyoutDialog).Close();
                }
            }
        }

        public bool OnDemandSuccessBannerShow
        {
            set
            {
                if (value)
                {
                    PopulateResultSuccessUiStatus();
                }
            }
        }

        public bool CloseFlyoutAfterSuccess
        {
            set
            {
                if (value)
                {
                    UserToBeLoginIn.Message = "enter";
                    UserToBeLoginIn.Token = _jwtAuthUiModel.Token;
                    UserToBeLoginIn.RefreshToken = _jwtAuthUiModel.RefreshToken;
                    UserToBeLoginIn.Login = "su@digitalabs.tech"; // Todo: Extract from Token.
                    (this.Parent as CustomFlyoutDialog).Close();
                }
            }
        }

        private void PopulateResultSuccessUiStatus()
        {
            pnlCntrlResult.Controls.Clear();

            BaseModule ucModuleItem = new UcSuccessLogin();
            ucModuleItem.Dock = DockStyle.Fill;
            pnlCntrlResult.Controls.Add(ucModuleItem);

            pnlCntrlResult.Visible = true;
            timerSuccess.Enabled = true;
        }

        private void BtnLoginLoginClick(object sender, EventArgs e)
        {
            _loginForgetManagementPresenter.LoginLoginWasClicked();
        }

        private void BtnLoginCancelClick(object sender, EventArgs e)
        {
            _loginForgetManagementPresenter.LoginCancelWasClicked();
        }

        private void BtnForgetSendClick(object sender, EventArgs e)
        {

        }

        private void TxtLoginUsernameEditValueChanged(object sender, EventArgs e)
        {
            _loginForgetManagementPresenter.LoginUsernameValueChanged();
        }

        private void TxtLoginPasswordEditValueChanged(object sender, EventArgs e)
        {
            _loginForgetManagementPresenter.LoginPasswordValueChanged();
        }

        private void TxtForgetUsernameEditValueChanged(object sender, EventArgs e)
        {
            _loginForgetManagementPresenter.ForgetUsernameValueChanged();
        }

        public string OnMessageError { get; set; }

        private AuthUiModel _jwtAuthUiModel;
        public AuthUiModel JwtAuthUiModel
        {
            get => _jwtAuthUiModel;
            set
            {
                if (value != null)
                {
                    //Todo: Load success Panel
                    _jwtAuthUiModel = value;
                    _loginForgetManagementPresenter.JwtWasReceived();
                    ClientSettingsSingleton.InstanceSettings().TokenConfigValue = value.Token;
                    ClientSettingsSingleton.InstanceSettings().RefreshTokenConfigValue = value.RefreshToken;
                }
            }
        }

        string _messageError = String.Empty;
        public string OnBadRequestForUserJwtResult
        {
            set
            {
                _messageError = value;
                PopulateResultErrorUiStatus();
                timerError.Enabled = true;
            }
        }

        private void PopulateResultErrorUiStatus()
        {
            pnlCntrlResult.Controls.Clear();

            BaseModule ucModuleItem = new UcErrorLogin();
            ucModuleItem.Dock = DockStyle.Fill;
            pnlCntrlResult.Controls.Add(ucModuleItem);

            pnlCntrlResult.Visible = true;
            timerError.Enabled = true;
        }

        private void UcFlyLoginForgetLoad(object sender, EventArgs e)
        {
            _loginForgetManagementPresenter.UcFlyoutloginForgetWasLoaded();
        }

        private void TimerSuccessTick(object sender, EventArgs e)
        {
            timerSuccess.Enabled = false;
            pnlCntrlResult.Visible = false;
            pnlCntrlResult.Controls.Clear();
            //Todo: 2 above should be removed to Presenter Action
            _loginForgetManagementPresenter.TimerSuccessWasCatch();
        }

        private void TimerErrorTick(object sender, EventArgs e)
        {
            timerError.Enabled = false;
            pnlCntrlResult.Visible = false;
            pnlCntrlResult.Controls.Clear();
            //Todo: 2 above should be removed to Presenter Action
            _loginForgetManagementPresenter.TimerErrorWasCatch();
        }
    }
}
