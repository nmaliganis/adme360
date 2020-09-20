using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Employees.EmployeeRoles;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Employees.EmployeeRoles
{
    public class EmployeeRolesPresenter : BasePresenter<IEmployeeRolesView, IEmployeeRolesService>
    {
        public EmployeeRolesPresenter(IEmployeeRolesView view)
            : this(view, new EmployeeRolesService())
        {
        }

        public EmployeeRolesPresenter(IEmployeeRolesView view, IEmployeeRolesService service)
            : base(view, service)
        {
        }

        public async void LoadAllEmployeeRoles()
        {
            var employeeRoles = await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (employeeRoles?.Count == 0)
                View.NoneEmployeeRoleWasRetrieved = true;
            else
            {
                View.EmployeeRoles = employeeRoles;
            }
        }
    }
}