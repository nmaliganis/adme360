using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Employees.Departments;

namespace adme360.presenter.ViewModel.Employees.Departments
{
    public class DepartmentsPresenter : BasePresenter<IDepartmentsView, IDepartmentsService>
    {
        public DepartmentsPresenter(IDepartmentsView view)
            : this(view, new DepartmentsService())
        {
        }

        public DepartmentsPresenter(IDepartmentsView view, IDepartmentsService service)
            : base(view, service)
        {
        }

        public async void LoadAllDepartments()
        {
            var departments = await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (departments?.Count == 0)
                View.NoneDepartmentWasRetrieved = true;
            else
            {
                View.Departments = departments;
            }
        }
    }
}