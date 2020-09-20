using System;
using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Containers;
using adme360.presenter.Exceptions;

namespace adme360.presenter.ViewModel.Containers
{
    public class ContainerPointsPresenter : BasePresenter<IContainersPointsView, IContainersService>
    {
        public ContainerPointsPresenter(IContainersPointsView view)
            : this(view, new ContainersService())
        {
        }

        public ContainerPointsPresenter(IContainersPointsView view, IContainersService service)
            : base(view, service)
        {
        }

        public async void LoadAllContainersPoints()
        {
            try
            {
                var containersPoints = await Service.GetAllActiveContainersPointsAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                if (containersPoints?.Count == 0)
                    View.NoneContainerPointWasRetrieved = true;
                else
                {
                    View.ContainersPoints = containersPoints;
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
                        View.OnContainerPointsMsgError = "Σφάλμα απροσδιόριστο.";
                        break;
                    default:
                        View.OnContainerPointsMsgError =
                            $"Σφάλμα διακομιστή: {ex.HttpStatusCode}\n, Επιπλέον στοιχεία: {ex.Content}";
                        break;
                }
            }
            else
            {
                View.OnContainerPointsMsgError = "΄Αγνωστο Σφάλμα: " + e.Message;
            }
        }
    }
}