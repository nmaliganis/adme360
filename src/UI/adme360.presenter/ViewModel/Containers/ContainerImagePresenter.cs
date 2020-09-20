using System.Linq;
using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Containers;
using adme360.presenter.Helpers;

namespace adme360.presenter.ViewModel.Containers
{
    public class ContainerImagePresenter : BasePresenter<IContainerImageView, IContainersService>
    {
        public ContainerImagePresenter(IContainerImageView view)
            : this(view, new ContainersService())
        {
        }

        public ContainerImagePresenter(IContainerImageView view, IContainersService service)
            : base(view, service)
        {
        }

        public void ContainerImagePopulate()
        {
            View.PctContainerImagePathValue = View.SelectedContainerImageNameImageView;
        }
    }
}