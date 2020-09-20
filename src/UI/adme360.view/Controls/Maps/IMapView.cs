using System.Collections.Generic;
using adme360.view;
using adme360.models.DTOs.Users;

namespace adme360.view.Controls.Maps
{
    public interface IMapView : IView
    {
        double PointLat { get; set; }
        double PointLon { get; set; }
        string PointAddress { get; set; }
    }
}