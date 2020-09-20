using System;
using adme360.view;
using adme360.models.DTOs.Devices;

namespace adme360.view.Controls.Sensors.AddEditFlyoutSensor
{
    public interface IUcFlySensorManagementView : IView
    {
        bool IsAddMode { get; set; }
        bool OnDemandLoadFlyoutSensorManagement { set; }

        bool BtnSensorSaveEnabled { get; set; }
        bool BtnSensorCancelEnabled { get; set; }
        bool GridContainerEnabled { get; set; }
        bool GridFirmwareEnabled { get; set; }
        bool GridSimcardEnabled { get; set; }


        Guid SelectedSensorId { get; set; }
        DeviceUiModel SelectedSensor { get; set; }


        bool ChckSensorEnabledEnabled { get; set; }
        bool ChckSensorEnabledValue { get; set; }
        bool SelectedSensorEnabled { get; set; }
        bool ChangedSensorEnabled { get; set; }

        bool ChckSensorContainerEnabled { get; set; }
        bool ChckSensorContainerValue { get; set; }
        bool SelectedContainerEnabled { get; set; }
        bool ChangedContainerEnabled { get; set; }

        bool ChckSensorSimcardEnabled { get; set; }
        bool ChckSensorSimcardValue { get; set; }
        bool SelectedSimcardEnabled { get; set; }
        bool ChangedSimcardEnabled { get; set; }

        bool ChckSensorFirmwareEnabled { get; set; }
        bool ChckSensorFirmwareValue { get; set; }
        bool SelectedFirmwareEnabled { get; set; }
        bool ChangedFirmwareEnabled { get; set; }
    }
}