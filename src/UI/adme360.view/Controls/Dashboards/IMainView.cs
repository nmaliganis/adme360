using System.Collections.Generic;
using adme360.view;

namespace adme360.view.Controls.Dashboards
{
    public interface IMainView : IView
    {
        string Token { get; set; }
        string ClaimRole { get; set; }
        bool NoneClaimRoleFromToken { set; }
    }
}