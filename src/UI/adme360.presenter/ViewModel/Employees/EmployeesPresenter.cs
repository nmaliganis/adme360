using System;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Employees;
using dl.wm.presenter.Base;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.Utilities;

namespace dl.wm.presenter.ViewModel.Employees
{
    public class EmployeesPresenter : BasePresenter<IEmployeesView, IEmployeesService>
    {
        public EmployeesPresenter(IEmployeesView view)
            : this(view, new EmployeesService())
        {
        }

        public EmployeesPresenter(IEmployeesView view, IEmployeesService service)
            : base(view, service)
        {
        }

        public async void LoadAllActiveEmployees()
        {
            try
            {
                var employees =
                    await Service.GetAllActiveEmployeesAsync(
                        ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                if (employees?.Count == 0)
                    View.NoneEmployeeWasRetrieved = true;
                else
                {
                    View.Employees = employees;
                }
            }
            catch (Exception e)
            {
                HandleServiceException(e);
            }
        }

        private void HandleServiceException(Exception e)
        {
            if (e is ServiceHttpRequestException<string>)
            {
                ServiceHttpRequestException<string> ex = (ServiceHttpRequestException<string>) e;

                switch (ex.Content)
                {
                    case "UNKNOWN_ERROR":
                        View.OnEmployeesMsgError = "Σφάλμα απροσδιόριστο.";
                        break;
                    default:
                        View.OnEmployeesMsgError =
                            $"Σφάλμα διακομιστή: {ex.HttpStatusCode}\n, Επιπλέον στοιχεία: {ex.Content}";
                        break;
                }
            }
            else
            {
                View.OnEmployeesMsgError = "΄Αγνωστο Σφάλμα: " + e.Message;
            }
        }
    }
}