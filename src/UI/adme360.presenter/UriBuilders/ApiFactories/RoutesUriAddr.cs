using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class RoutesUriAddr : BaseClientUri
    {
        public RoutesUriAddr(string serverIp)
            : this(serverIp, "6200", "v1")
        {
        }

        public RoutesUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        public override bool IsVersioning { get; set; } = true;

        protected override string Segment => "routes";
    }
}