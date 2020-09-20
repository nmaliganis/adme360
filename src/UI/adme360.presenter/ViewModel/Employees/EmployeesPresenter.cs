using System;
using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Employees;
using adme360.presenter.Exceptions;
using adme360.presenter.Utilities;

namespace adme360.presenter.ViewModel.Employees
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