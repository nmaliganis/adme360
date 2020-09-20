using System.Collections.Generic;
using DevExpress.XtraMap;

namespace adme360.suite.ui.Views.Helpers
{
    public class DashboardCustomClusterFactory : DefaultClusterItemFactory 
    {
        protected override MapItem CreateItemInstance(IList<MapItem> obj) {
            return new MapCallout();
        }
    }
}