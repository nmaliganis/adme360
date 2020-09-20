using System.Collections.Generic;
using adme360.suite.ui.Controls;
using adme360.suite.ui.Views.Components.Containers;
using adme360.suite.ui.Views.Components.Sensors;

namespace adme360.suite.ui.Views.Repositories
{
    public sealed class ModuleSensorViewRepository
    {
        public readonly IDictionary<string, BaseModule> SensorViewRepository;
        private ModuleSensorViewRepository()
        {
            SensorViewRepository = new Dictionary<string, BaseModule>()
            {
                {"SensorManagement", new UcClientsManagementSensors()},
                {"SensorModelManagement", new UcClientsManagementSensorModels()},
                {"SensorMonitoring", new UcClientsMonitoringSensors()},
                {"SensorMeasurementHistory", new UcClientsMeasurementHistorySensors()},
                {"SensorMeasurementRealTime", new UcClientsMeasurementRealTimeSensors()},
                {"SensorSettingsSim", new UcClientsSettingsSimcardSensors()},
                {"SensorSettingsCalibration", new UcClientsSettingsCalibrationSensors()},
                {"SensorSettingsFirmware", new UcClientsSettingsFirmwareSensors()},
                {"SensorSettingsCommand", new UcClientsSettingsCommandsSensors()},
            };
        }

        public static ModuleSensorViewRepository ViewRepository { get; } = new ModuleSensorViewRepository();

        public BaseModule this[string index] => SensorViewRepository[index];
    }
}
