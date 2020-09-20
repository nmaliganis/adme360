using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Firmwares;

namespace adme360.presenter.ViewModel.Firmwares
{
    public class FirmwaresPresenter : BasePresenter<IFirmwaresView, IFirmwaresService>
    {
        public FirmwaresPresenter(IFirmwaresView view)
            : this(view, new FirmwaresService())
        {
        }

        public FirmwaresPresenter(IFirmwaresView view, IFirmwaresService service)
            : base(view, service)
        {
        }

        public async void LoadAllFirmwares()
        {
            var firmwares = await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (firmwares?.Count == 0)
                View.NoneFirmwareWasRetrieved = true;
            else
            {
                View.Firmwares = firmwares;
            }
        }
    }
}