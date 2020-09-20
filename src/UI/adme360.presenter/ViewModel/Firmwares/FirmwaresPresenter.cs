using dl.wm.presenter.Base;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Firmwares;

namespace dl.wm.presenter.ViewModel.Firmwares
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