using System.Linq;
using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Users;

namespace adme360.presenter.ViewModel.Users
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