using System;
using dl.wm.models.DTOs.Users.Roles;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Users.Roles;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Users.Roles
{
    public class FoUserRoleManagementPresenter : BasePresenter<IFoUserRoleManagementView, IUserRolesService>
    {
        private bool _bUserRoleNameValidated;


        public FoUserRoleManagementPresenter(IFoUserRoleManagementView view)
            : this(view, new UserRolesService())
        {
        }

        public FoUserRoleManagementPresenter(IFoUserRoleManagementView view, IUserRolesService service)
            : base(view, service)
        {
        }

        public async void AddEditRoleSaveWasClicked()
        {
            View.ChangedUserRole = new UserRoleUiModel();
            PrepareChangedRoleForSaving();

            if (!CheckIfUserRoleCanBeSaved())
            {
                View.OnSaveUserRoleMsgError = "Correction. " +
                                             "Fill in all required fields!";
                return;
            }

            try
            {
                //Create
                if (View.SelectedUserRoleId == Guid.Empty)
                {
                    View.CreatedUserRole = await Service.CreateEntityAsync(View.ChangedUserRole, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

                    if (View.CreatedUserRole!= null)
                        View.OnSuccessUserRoleCreation = true;
                }
                //Modify
                else
                {
                    if (!CheckUserRoleForValidation())
                        return;
                    View.VerifyForTheUserRoleModification = true;
                    if (View.ActionAfterVerifyForTheUserRoleModification)
                    {
                        View.ChangedUserRole.Id = View.SelectedUserRoleId;
                        View.ModifiedUserRole = await Service.UpdateEntityAsync(View.ChangedUserRole, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                        //View.OnSuccessUserRoleModification = View.ModifiedVehicle?.Content != null;
                    }
                }
            }
            catch (Exception e)
            {
                //HandleServiceException(e);
            }
        }

        private void PrepareChangedRoleForSaving()
        {
            View.ChangedUserRole.Name = _bUserRoleNameValidated
                ? View.ChangedUserRoleName
                : View.SelectedUserRoleName;
        }

        private bool CheckUserRoleForValidation()
        {
            return true;
        }

        private bool CheckIfUserRoleCanBeSaved()
        {
            return (!String.IsNullOrEmpty(View.ChangedUserRole.Name)
                );
        }

        public async void FoWasLoaded()
        {
            if (View.UserRoleIdToBeRetrieved == Guid.Empty)
            {
                View.TxtUserRoleNameValue = String.Empty;
            }
            else
            {
                View.SelectedUserRole = await Service
                    .GetEntityByIdAsync(View.UserRoleIdToBeRetrieved, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                if(View.SelectedUserRole != null)
                    View.TxtUserRoleNameValue = View.SelectedUserRole.Name;
            }
        }
    }
}