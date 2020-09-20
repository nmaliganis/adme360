using dl.wm.presenter.Base;
using dl.wm.presenter.Commanding.Events.EventArgs.Devices;
using dl.wm.presenter.Commanding.Listeners.Devices;
using dl.wm.presenter.Commanding.Servers;
using dl.wm.presenter.Helpers;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Sensors;

namespace dl.wm.presenter.ViewModel.Sensors
{
    public class UcSensorMonitoringManagementPresenter : BasePresenter<IUcManagementSensorMonitoringView, IDevicesService>, 
        IDevicePutDetectionActionListener, IDevicePostDetectionActionListener
    {
        public UcSensorMonitoringManagementPresenter(IUcManagementSensorMonitoringView view)
            : this(view, new DevicesService())
        {
        }

        public UcSensorMonitoringManagementPresenter(IUcManagementSensorMonitoringView view, IDevicesService service)
            : base(view, service)
        {
            CommandingInboundServer.GetCommandingInboundServer.Attach((IDevicePostDetectionActionListener)this);
            CommandingInboundServer.GetCommandingInboundServer.Attach((IDevicePutDetectionActionListener)this);
        }

        public void UcWasLoaded()
        {
            View.InitialLoadingWasCaught = true;
            PopulateCtrlsOnLoadingWithRole();
        }

        private void PopulateCtrlsOnLoadingWithRole()
        {
            var role = JwtHelper.ExtractRoleFromToken(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (role != "SU" || role != "ADMIN")
            {
            }
        }

        void IDevicePutDetectionActionListener.Update(object sender, DeviceEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        void IDevicePostDetectionActionListener.Update(object sender, DeviceEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}