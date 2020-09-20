using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Dashboards;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Dashboards
{
    public class DashboardManagementPresenter : BasePresenter<IDashboardManagementView, IDashboardService>
    {
        public DashboardManagementPresenter(IDashboardManagementView view)
            : this(view, new DashboardService())
        {
        }

        public DashboardManagementPresenter(IDashboardManagementView view, DashboardService service)
            : base(view, service)
        {
        }


        public void UcDashboardWasLoaded()
        {
            View.OnDashboardLoaded = true;
        }

        public void RibbonCheckLockMapWasClicked()
        {
            if (View.RibbonLockMapValue)
                View.RibbonLockMapSvgImageIsBlack = true;
            else
                View.RibbonLockMapSvgImageIsOrange = true;
        }

        public void RibbonCheckGeofenceWasClicked()
        {
            if (View.RibbonGeofenceValue)
                View.RibbonGeofenceSvgImageIsBlack = true;
            else
                View.RibbonGeofenceSvgImageIsOrange = true;
        }

        public void RibbonCheckOrangeSphereClicked()
        {
            if (View.RibbonSphereValue)
                View.RibbonSphereSvgImageIsBlack = true;
            else
                View.RibbonSphereSvgImageIsOrange = true;
        }

        public void RibbonCheckCompostWasClicked()
        {
            if (View.RibbonCompostValue)
                View.RibbonCompostSvgImageIsBlack = true;
            else
                View.RibbonCompostSvgImageIsOrange = true;
        }

        public void RibbonCheckRecycleWasClicked()
        {
            if (View.RibbonRecycleValue)
                View.RibbonRecycleSvgImageIsBlack = true;
            else
                View.RibbonRecycleSvgImageIsOrange = true;
        }

        public void RibbonCheckWasteWasClicked()
        {
            if (View.RibbonWasteValue)
                View.RibbonWasteSvgImageIsBlack = true;
            else
                View.RibbonWasteSvgImageIsOrange = true;
        }

        public void StepInPixelsWasChanged()
        {
            View.OnClusterStepInPixelsChange = true;
        }
    }
}
