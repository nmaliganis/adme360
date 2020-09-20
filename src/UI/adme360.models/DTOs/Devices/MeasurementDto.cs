using System;

namespace adme360.models.DTOs.Devices
{
    public class MeasurementDto
    {
        public string CommandType { get; set; }
        public double Temperature { get; set; }
        public double FillLevel { get; set; }
        public double TiltX { get; set; }
        public double TiltY { get; set; }
        public double TiltZ { get; set; }
        public double Light { get; set; }
        public double Battery { get; set; }
        public string Gps { get; set; }
        public string NbIoT { get; set; }
        public double Distance { get; set; }
        public double Tamper { get; set; }
        public double NbIoTSignalLength { get; set; }
        public string LatestResetCause { get; set; }
        public string FirmwareVersion { get; set; }
        public bool TemperatureEnable { get; set; }
        public bool DistanceEnable { get; set; }
        public bool TiltEnable { get; set; }
        public bool MagnetometerEnable { get; set; }
        public bool TamperEnable { get; set; }
        public bool LightEnable { get; set; }
        public bool GpsEnable { get; set; }
        public double BatterySafeMode { get; set; }
        public double NbIoTMode { get; set; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double Speed { get; set; }
        public double Bearing { get; set; }
        public double Angle { get; set; }
        public int NumOfSatellites { get; set; }
        public double TimeToFix { get; set; }
        public double SignalLength { get; set; }
        public double StatusFlags { get; set; }
        public string Version { get; set; }
        public string Imei { get; set; }
    }
}