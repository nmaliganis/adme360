using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class EmployeeRoleUriAddr : BaseClientUri
    {
        public EmployeeRoleUriAddr(string serverIp)
            : this(serverIp, "6200", "v1")
        {
        }

        public EmployeeRoleUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        protected override string Segment => "EmployeeRoles";
    }
}