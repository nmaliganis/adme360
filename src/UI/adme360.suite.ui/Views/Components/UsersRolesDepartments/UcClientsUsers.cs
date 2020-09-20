using System;
using System.Collections.Generic;
using adme360.models.DTOs.Users;
using adme360.presenter.ViewModel.Users;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Users;

namespace adme360.suite.ui.Views.Components.UsersRolesDepartments
{
    public partial class UcClientsUsers : BaseModule, IUsersView, IUserManagementView
    {
        private UsersPresenter _usersPresenter;
        private UserManagementPresenter _userManagementPresenter;

        public UcClientsUsers()
        {
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _usersPresenter = new UsersPresenter(this);
            _userManagementPresenter = new UserManagementPresenter(this);
        }

        #region IUsersView

        public string OnGeneralMsg { get; set; }

        public List<UserForAllRetrievalUiModel> Users
        {
            get => (List<UserForAllRetrievalUiModel>)gvAdvBndManagementUsers.DataSource;
            set => gcAdvBndManagementUsers.DataSource = value;

        }
        public bool NoneUserWasRetrieved { get; set; }

        #endregion

        #region IUserManagementView

        public bool UcUserWasLoadedOnDemand
        {
            set
            {
                if (true)
                {
                    _usersPresenter.LoadAllUsers();
                }
            }
        }

        public bool OpenFlyoutForAddUser
        {
            set
            {
                if (value)
                {
                    FlyoutAddEditUserEventArgs args =
                        new FlyoutAddEditUserEventArgs( "OnAddNewUser", Guid.Empty);
                    this.OnAddNewUserRequested(args);
                    if (args.IsAccepted)
                    {
                        OnFlyoutCallbackOkResponnse();
                    }
                }
            }
        }

        private void OnFlyoutCallbackOkResponnse()
        {
            
        }

        #endregion

        #region Locals

        private void UcClientsUsersLoad(object sender, EventArgs e)
        {
            _userManagementPresenter.UcUsersWasLoaded();
        }

        private void BtnAddUserClick(object sender, EventArgs e)
        {
            _userManagementPresenter.OpenFlyoutForAddUserWasClicked();
        }

        private void BtnEditUserClick(object sender, EventArgs e)
        {

        }
        private void BtnRemoveUserClick(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
