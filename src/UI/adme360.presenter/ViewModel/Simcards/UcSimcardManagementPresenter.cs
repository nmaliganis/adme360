using adme360.presenter.Base;
using adme360.presenter.Commanding.Events.EventArgs.Simcards;
using adme360.presenter.Commanding.Listeners.Simcards;
using adme360.presenter.Commanding.Servers;
using adme360.presenter.Helpers;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Sensors;

namespace adme360.presenter.ViewModel.Simcards
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