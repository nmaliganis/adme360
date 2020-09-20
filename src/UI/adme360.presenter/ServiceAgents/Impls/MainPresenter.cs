using dl.wm.presenter.Base;
using dl.wm.presenter.Helpers;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.view.Controls.Dashboards;

namespace dl.wm.presenter.ServiceAgents.Impls
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
