using System.Linq;
using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Containers;
using adme360.presenter.Commanding.Events.EventArgs.Containers;
using adme360.presenter.Commanding.Listeners;
using adme360.presenter.Commanding.Listeners.Containers;
using adme360.presenter.Commanding.Servers;
using adme360.presenter.Helpers;
using adme360.presenter.Utilities;

namespace adme360.presenter.ViewModel.Containers
{
    public class UcContainerManagementPresenter : BasePresenter<IUcContainerManagementView, IContainersService>, 
        IContainerPutDetectionActionListener, IContainerPostDetectionActionListener
    {
        public UcContainerManagementPresenter(IUcContainerManagementView view)
            : this(view, new ContainersService())
        {
        }

        public UcContainerManagementPresenter(IUcContainerManagementView view, IContainersService service)
            : base(view, service)
        {
            CommandingInboundServer.GetCommandingInboundServer.Attach((IContainerPostDetectionActionListener)this);
            CommandingInboundServer.GetCommandingInboundServer.Attach((IContainerPutDetectionActionListener)this);
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

        public void OpenFlyoutForAddContainerWasClicked()
        {
            View.OpenFlyoutForAddContainer = true;
        }

        public void OpenFlyoutForEditContainerWasClicked()
        {
            View.OpenFlyoutForEditContainer = true;
        }

        public void RemoveContainerWasClicked()
        {
        }
        public async void ContainerFromGridWasSelected()
        {
            View.PctContainerImageValue = View.SelectedContainerImageName;
            View.OnPopulateContainerDataAfterSelection = true;
        }

        void IContainerPutDetectionActionListener.Update(object sender, ContainerEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        void IContainerPostDetectionActionListener.Update(object sender, ContainerEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}