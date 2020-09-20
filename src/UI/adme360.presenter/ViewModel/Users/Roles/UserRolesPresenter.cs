using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Users.Roles;

namespace adme360.presenter.ViewModel.Users.Roles
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