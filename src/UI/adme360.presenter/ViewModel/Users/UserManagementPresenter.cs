using System;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Users;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Users
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
