using adme360.presenter.Base;
using adme360.presenter.Commanding.Events.EventArgs.Devices;
using adme360.presenter.Commanding.Listeners.Devices;
using adme360.presenter.Commanding.Servers;
using adme360.presenter.Helpers;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Sensors;

namespace adme360.presenter.ViewModel.Sensors
{
    public class UcSensorManagementPresenter : BasePresenter<IUcManagementSensorManagementView, IDevicesService>, 
        IDevicePutDetectionActionListener, IDevicePostDetectionActionListener
    {
        public UcSensorManagementPresenter(IUcManagementSensorManagementView view)
            : this(view, new DevicesService())
        {
        }

        public UcSensorManagementPresenter(IUcManagementSensorManagementView view, IDevicesService service)
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

        public void OpenFlyoutForAddSensorWasClicked()
        {
            View.OpenFlyoutForAddSensor = true;
        }

        public void OpenFlyoutForEditSensorWasClicked()
        {
            View.OpenFlyoutForEditSensor = true;
        }

        public void RemoveSensorWasClicked()
        {
            View.RemoveSensorWasCaught = true;
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