using dl.wm.presenter.Base;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Sensors;

namespace dl.wm.presenter.ViewModel.Sensors
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