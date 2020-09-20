using dl.wm.presenter.Base;
using dl.wm.presenter.Commanding.Events.EventArgs.Simcards;
using dl.wm.presenter.Commanding.Listeners.Simcards;
using dl.wm.presenter.Commanding.Servers;
using dl.wm.presenter.Helpers;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Sensors;

namespace dl.wm.presenter.ViewModel.Simcards
{
    public class UcSimcardManagementPresenter : BasePresenter<IUcManagementSensorSettingsSimcardView, ISimcardsService>, 
        ISimcardPutDetectionActionListener, ISimcardPostDetectionActionListener
    {
        public UcSimcardManagementPresenter(IUcManagementSensorSettingsSimcardView view)
            : this(view, new SimcardsService())
        {
        }

        public UcSimcardManagementPresenter(IUcManagementSensorSettingsSimcardView view, ISimcardsService service)
            : base(view, service)
        {
            CommandingInboundServer.GetCommandingInboundServer.Attach((ISimcardPostDetectionActionListener)this);
            CommandingInboundServer.GetCommandingInboundServer.Attach((ISimcardPutDetectionActionListener)this);
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

        public void OpenFlyoutForAddSimcardWasClicked()
        {
            View.OpenFlyoutForAddSimcard = true;
        }

        public void OpenFlyoutForEditSimcardWasClicked()
        {
            View.OpenFlyoutForEditSimcard = true;
        }

        public void RemoveSimcardWasClicked()
        {
            View.RemoveSimcardWasCaught = true;
        }

        void ISimcardPutDetectionActionListener.Update(object sender, SimcardEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        void ISimcardPostDetectionActionListener.Update(object sender, SimcardEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}