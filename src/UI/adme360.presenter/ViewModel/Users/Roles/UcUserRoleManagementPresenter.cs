using System;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Users.Roles;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Users.Roles
{
    public class UcUserRoleManagementPresenter : BasePresenter<IUcUserRoleManagementView, IUserRolesService>
    {

        public UcUserRoleManagementPresenter(IUcUserRoleManagementView view)
            : this(view, new UserRolesService())
        {
        }

        public UcUserRoleManagementPresenter(IUcUserRoleManagementView view, IUserRolesService service)
            : base(view, service)
        {
        }

        public void OpenFlyoutForAddUserRoleWasClicked()
        {
            View.SelectedUserRoleId = Guid.Empty;
            View.OpenFlyoutForAddEditUserRole = true;
        }
        public void OpenFlyoutForEditUserRoleWasClicked()
        {
            View.OpenFlyoutForAddEditUserRole = true;
        }

        public void RemoveUserRoleWasClicked()
        {
            
        }

        public void UserRoleFromGridWasSelected()
        {
            PopulateUserRoleDataAfterUserRoleSelection();
        }


        private async void PopulateUserRoleDataAfterUserRoleSelection()
        {
            if(View.SelectedUserRoleId == Guid.Empty)
                return;

            View.SelectedUserRole = await Service.GetEntityByIdAsync(View.SelectedUserRoleId, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
        }
    }
}