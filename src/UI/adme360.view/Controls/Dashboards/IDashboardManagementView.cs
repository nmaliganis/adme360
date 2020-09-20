using System;
using adme360.view;
using adme360.view.Commons;

namespace adme360.view.Controls.Dashboards
{
    public interface IDashboardManagementView : IView
    {
        bool OnDashboardLoaded { set; }

        bool RibbonLockMapEnabled { get; set; }
        bool RibbonLockMapValue { get; set; }
        bool RibbonLockMapSvgImageIsBlack { set; }
        bool RibbonLockMapSvgImageIsOrange { set; }

        bool RibbonGeofenceEnabled { get; set; }
        bool RibbonGeofenceValue { get; set; }
        bool RibbonGeofenceSvgImageIsBlack { set; }
        bool RibbonGeofenceSvgImageIsOrange { set; }

        bool RibbonSphereEnabled { get; set; }
        bool RibbonSphereValue { get; set; }
        bool RibbonSphereSvgImageIsBlack { set; }
        bool RibbonSphereSvgImageIsOrange { set; }

        bool RibbonWasteEnabled { get; set; }
        bool RibbonWasteValue { get; set; }
        bool RibbonWasteSvgImageIsBlack { set; }
        bool RibbonWasteSvgImageIsOrange { set; }

        bool RibbonCompostEnabled { get; set; }
        bool RibbonCompostValue { get; set; }
        bool RibbonCompostSvgImageIsBlack { set; }
        bool RibbonCompostSvgImageIsOrange { set; }

        bool RibbonRecycleEnabled { get; set; }
        bool RibbonRecycleValue { get; set; }
        bool RibbonRecycleSvgImageIsBlack { set; }
        bool RibbonRecycleSvgImageIsOrange { set; }
        bool OnClusterStepInPixelsChange { set; }


        bool RibbonBarTrackStepInPixelsEnabled { get; set; }
        int RibbonBarTrackStepInPixelsValue { get; set; }
    }
}