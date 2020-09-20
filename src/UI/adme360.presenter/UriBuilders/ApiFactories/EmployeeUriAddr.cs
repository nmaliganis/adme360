using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class EmployeeUriAddr : BaseClientUri
    {
        public EmployeeUriAddr(string serverIp)
            : this(serverIp, "6200", "v1")
        {
        }

        public EmployeeUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort) =>
            Versioning = versioning;

        protected sealed override string Versioning { get; set; }

        protected override string Segment => "Employees";
    }
}