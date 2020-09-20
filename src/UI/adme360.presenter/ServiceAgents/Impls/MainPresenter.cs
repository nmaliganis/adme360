using adme360.presenter.Base;
using adme360.presenter.Helpers;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.view.Controls.Dashboards;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class MainPresenter : BasePresenter<IMainView, IDashboardService>
    {
        public MainPresenter(IMainView view)
            : this(view, new DashboardService())
        {
        }

        public MainPresenter(IMainView view, DashboardService service)
            : base(view, service)
        {
        }

        public void ExtractRoleFromTokens()
        {
            var role = JwtHelper.ExtractRoleFromToken(View.Token);

            if (string.IsNullOrEmpty(role))
            {
                View.NoneClaimRoleFromToken = true;
            }
            else
            {
                View.ClaimRole = role;
            }
        }
    }
}
