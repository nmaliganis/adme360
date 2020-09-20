using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Employees.Departments;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Employees.Departments
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