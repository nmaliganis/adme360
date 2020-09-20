using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Users.Roles;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Users.Roles
{
    public class UserRolesPresenter : BasePresenter<IUserRolesView, IUserRolesService>
    {
        public UserRolesPresenter(IUserRolesView view)
            : this(view, new UserRolesService())
        {
        }

        public UserRolesPresenter(IUserRolesView view, IUserRolesService service)
            : base(view, service)
        {
        }

        public async void LoadAllUserRoles()
        {
            var userRoles = await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (userRoles?.Count == 0)
                View.NoneUserRoleWasRetrieved = true;
            else
            {
                View.UserRoles = userRoles;
            }
        }
    }
}