using System;
using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Users.Roles;

namespace adme360.presenter.ViewModel.Users.Roles
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