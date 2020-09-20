using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Users;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Users
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