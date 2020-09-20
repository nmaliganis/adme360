using System.Collections.Generic;
using DevExpress.XtraMap;

namespace adme360.suite.ui.Views.Modules.Clustering
{
    public class CustomClusterFactory : DefaultClusterItemFactory
    {
        protected override MapItem CreateItemInstance(IList<MapItem> obj)
        {
            return new MapCallout();
        }
    }
}