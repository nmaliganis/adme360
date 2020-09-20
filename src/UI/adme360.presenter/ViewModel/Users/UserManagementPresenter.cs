using System;
using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Users;

namespace adme360.presenter.ViewModel.Users
{
    public class UserManagementPresenter : BasePresenter<IUserManagementView, IUsersService>
    {
        public UserManagementPresenter(IUserManagementView view)
            : this(view, new UsersService())
        {
        }

        public UserManagementPresenter(IUserManagementView view, IUsersService service)
            : base(view, service)
        {
        }

        public void UcUsersWasLoaded()
        {
            View.UcUserWasLoadedOnDemand = true;
        }

        public void OpenFlyoutForAddUserWasClicked()
        {
            View.OpenFlyoutForAddUser = true;
        }
    }
}
