using System;
using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Sensors.AddEditFlyoutSensor;

namespace adme360.presenter.ViewModel.Sensors
{
    public class UcFlySensorManagementPresenter : BasePresenter<IUcFlySensorManagementView, IDevicesService>
    {
        public UcFlySensorManagementPresenter(IUcFlySensorManagementView view)
            : this(view, new DevicesService())
        {
        }

        public UcFlySensorManagementPresenter(IUcFlySensorManagementView view, IDevicesService service)
            : base(view, service)
        {
        }

        public void FlyoutSensorManagementWasLoaded()
        {
            View.OnDemandLoadFlyoutSensorManagement = true;
            PrepareUiCtrlsAfterLoadFlyoutSensorManagement();
            if (View.SelectedSensorId == Guid.Empty)
            {
                PrepareUiCtrlsValuesAfterAddSensorWasSelected();
            }
            else
            {
                PopulateUiCtrlsValuesAfterEditSensorWasSelected();
            }
        }

        private void PopulateUiCtrlsValuesAfterEditSensorWasSelected()
        {
            View.BtnSensorSaveEnabled = false;
            View.BtnSensorCancelEnabled = true;
        }

        private void PrepareUiCtrlsValuesAfterAddSensorWasSelected()
        {
            View.SelectedSensorId = Guid.Empty;
        }

        private void PrepareUiCtrlsAfterLoadFlyoutSensorManagement()
        {
            View.BtnSensorSaveEnabled = false;
            View.BtnSensorCancelEnabled = true;
        }

        public async void PopulateSensorDataForModification()
        {
            View.SelectedSensor = await Service.GetEntityByIdAsync(View.SelectedSensorId, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
            PrepareUiCtrlsAfterSensorSelection();
        }

        private void PrepareUiCtrlsAfterSensorSelection()
        {
            
        }

        public void WithContainerWasChecked()
        {
            View.GridContainerEnabled = View.ChckSensorContainerValue;
        }

        public void WithFirmwareWasChecked()
        {
            View.GridFirmwareEnabled = View.ChckSensorFirmwareValue;
        }

        public void WithSimcardWasChecked()
        {
            View.GridSimcardEnabled = View.ChckSensorSimcardValue;
        }

        public void EnabledWasChecked()
        {
        }

        public void ActivatedWasChecked()
        {
        }
    }
}
