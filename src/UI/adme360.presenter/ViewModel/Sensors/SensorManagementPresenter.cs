using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Sensors;

namespace adme360.presenter.ViewModel.Sensors
{
    public class SensorManagementPresenter : BasePresenter<ISensorManagementView, IDevicesService>
    {
        public SensorManagementPresenter(ISensorManagementView view)
            : this(view, new DevicesService())
        {
        }

        public SensorManagementPresenter(ISensorManagementView view, IDevicesService service)
            : base(view, service)
        {
        }

        public void NavBarModuleLinkClicked()
        {
            View.PopulateUcCtrl = true;
        }
    }
}