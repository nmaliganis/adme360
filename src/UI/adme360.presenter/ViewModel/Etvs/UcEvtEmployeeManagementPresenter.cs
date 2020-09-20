using System;
using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Evts;
using adme360.presenter.Helpers;
using adme360.presenter.Utilities;

namespace adme360.presenter.ViewModel.Etvs
{
    public class UcEvtEmployeeManagementPresenter : BasePresenter<IUcEvtEmployeeManagementView, IEmployeesService>
    {
        private readonly string _role = string.Empty;

        public UcEvtEmployeeManagementPresenter(IUcEvtEmployeeManagementView view)
            : this(view, new EmployeesService())
        {
        }

        public UcEvtEmployeeManagementPresenter(IUcEvtEmployeeManagementView view, IEmployeesService service)
            : base(view, service)
        {
            _role = JwtHelper.ExtractRoleFromToken(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
        }

        public void OpenFlyoutForAddEmployeeWasClicked()
        {
            View.OpenFlyoutForAddEmployee = true;
        }

        public void UcWasLoaded()
        {
            View.OnEmployeeManagementLoaded = true;
            PopulateCtrlsOnLoadingWithRole();
        }

        private void PopulateCtrlsOnLoadingWithRole()
        {
            if (_role == "SU" || _role == "ADMIN")
            {
                View.BtnEmployeeManagementAddEmployee = true;
                View.BtnEmployeeManagementEditEmployee = true;
                View.BtnEmployeeManagementDeleteEmployee = true;
            }
            else
            {
                View.BtnEmployeeManagementAddEmployee = false;
                View.BtnEmployeeManagementEditEmployee = false;
                View.BtnEmployeeManagementDeleteEmployee = false;
            }
        }
    }
}