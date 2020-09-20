using System.Linq;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Users;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Users
{
    public class UsersPresenter : BasePresenter<IUsersView, IUsersService>
    {
        public UsersPresenter(IUsersView view)
            : this(view, new UsersService())
        {
        }

        public UsersPresenter(IUsersView view, IUsersService service)
            : base(view, service)
        {
        }

        public async void LoadAllUsers()
        {
            var users = await Service.GetUserEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (users?.Count == 0)
                View.NoneUserWasRetrieved = true;
            else
            {
                View.Users = users?.ToList();
            }
        }
    }
}