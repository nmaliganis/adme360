using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Employees.EmployeeRoles;

namespace adme360.presenter.ViewModel.Employees.EmployeeRoles
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