using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Users;

namespace adme360.presenter.ViewModel.Users
{
    public class UcUserManagementPresenter : BasePresenter<IUcUserManagementView, IUsersService>
    {

        public UcUserManagementPresenter(IUcUserManagementView view)
            : this(view, new UsersService())
        {
        }

        public UcUserManagementPresenter(IUcUserManagementView view, IUsersService service)
            : base(view, service)
        {
        }

        public void NavBarModuleLinkClicked()
        {
            View.PopulateUcCtrl = true;
        }
    }
}