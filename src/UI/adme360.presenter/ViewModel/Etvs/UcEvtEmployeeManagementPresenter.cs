using System;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Evts;
using dl.wm.presenter.Base;
using dl.wm.presenter.Helpers;
using dl.wm.presenter.Utilities;

namespace dl.wm.presenter.ViewModel.Etvs
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