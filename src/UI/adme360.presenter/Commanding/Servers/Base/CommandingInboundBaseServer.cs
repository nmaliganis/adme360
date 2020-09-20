using System;
using dl.wm.models.DTOs.Containers;
using dl.wm.models.DTOs.Devices;
using dl.wm.models.DTOs.Simcards;
using dl.wm.presenter.Commanding.Events.EventArgs.Containers;
using dl.wm.presenter.Commanding.Events.EventArgs.Devices;
using dl.wm.presenter.Commanding.Events.EventArgs.Simcards;
using dl.wm.presenter.Commanding.Listeners.Containers;
using dl.wm.presenter.Commanding.Listeners.Devices;
using dl.wm.presenter.Commanding.Listeners.Simcards;

namespace dl.wm.presenter.Commanding.Servers.Base
{
    public abstract class CommandingInboundBaseServer
    {
        public event EventHandler<ContainerEventArgs> ContainerPostDetector;
        public event EventHandler<ContainerEventArgs> ContainerPutDetector;

        public event EventHandler<SimcardEventArgs> SimcardPostDetector;
        public event EventHandler<SimcardEventArgs> SimcardPutDetector;
        
        public event EventHandler<DeviceEventArgs> DevicePostDetector;
        public event EventHandler<DeviceEventArgs> DevicePutDetector;


        #region Container Post detection Event Manipulation

        private void OnContainerPostDetection(ContainerEventArgs e)
        {
            ContainerPostDetector?.Invoke(this, e);
        }

        public void RaiseContainerPostDetection(ContainerUiModel container)
        {
            OnContainerPostDetection(new ContainerEventArgs(container));
        }

        public void Attach(IContainerPostDetectionActionListener listener)
        {
            ContainerPostDetector += listener.Update;
        }

        public void Detach(IContainerPostDetectionActionListener listener)
        {
            ContainerPostDetector -= listener.Update;
        }

        #endregion

        #region Container Put detection Event Manipulation

        private void OnContainerPutDetection(ContainerEventArgs e)
        {
            ContainerPutDetector?.Invoke(this, e);
        }

        public void RaiseContainerPutDetection(ContainerUiModel container)
        {
            OnContainerPutDetection(new ContainerEventArgs(container));
        }

        public void Attach(IContainerPutDetectionActionListener listener)
        {
            ContainerPutDetector += listener.Update;
        }

        public void Detach(IContainerPutDetectionActionListener listener)
        {
            ContainerPutDetector -= listener.Update;
        }

        #endregion

        #region Simcard Post detection Event Manipulation

        private void OnSimcardPostDetection(SimcardEventArgs e)
        {
            SimcardPostDetector?.Invoke(this, e);
        }

        public void RaiseSimcardPostDetection(SimcardUiModel Simcard)
        {
            OnSimcardPostDetection(new SimcardEventArgs(Simcard));
        }

        public void Attach(ISimcardPostDetectionActionListener listener)
        {
            SimcardPostDetector += listener.Update;
        }

        public void Detach(ISimcardPostDetectionActionListener listener)
        {
            SimcardPostDetector -= listener.Update;
        }

        #endregion

        #region Simcard Put detection Event Manipulation

        private void OnSimcardPutDetection(SimcardEventArgs e)
        {
            SimcardPutDetector?.Invoke(this, e);
        }

        public void RaiseSimcardPutDetection(SimcardUiModel simcard)
        {
            OnSimcardPutDetection(new SimcardEventArgs(simcard));
        }

        public void Attach(ISimcardPutDetectionActionListener listener)
        {
            SimcardPutDetector += listener.Update;
        }

        public void Detach(ISimcardPutDetectionActionListener listener)
        {
            SimcardPutDetector -= listener.Update;
        }

        #endregion

        
        #region Device Post detection Event Manipulation

        private void OnDevicePostDetection(DeviceEventArgs e)
        {
            DevicePostDetector?.Invoke(this, e);
        }

        public void RaiseDevicePostDetection(DeviceUiModel device)
        {
            OnDevicePostDetection(new DeviceEventArgs(device));
        }

        public void Attach(IDevicePostDetectionActionListener listener)
        {
            DevicePostDetector += listener.Update;
        }

        public void Detach(IDevicePostDetectionActionListener listener)
        {
            DevicePostDetector -= listener.Update;
        }

        #endregion

        #region Device Put detection Event Manipulation

        private void OnDevicePutDetection(DeviceEventArgs e)
        {
            DevicePutDetector?.Invoke(this, e);
        }

        public void RaiseDevicePutDetection(DeviceUiModel device)
        {
            OnDevicePutDetection(new DeviceEventArgs(device));
        }

        public void Attach(IDevicePutDetectionActionListener listener)
        {
            DevicePutDetector += listener.Update;
        }

        public void Detach(IDevicePutDetectionActionListener listener)
        {
            DevicePutDetector -= listener.Update;
        }

        #endregion
    }
}