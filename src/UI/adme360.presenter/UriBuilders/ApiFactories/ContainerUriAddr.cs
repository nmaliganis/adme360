using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class ContainerUriAddr : BaseClientUri
    {
        public ContainerUriAddr(string serverIp)
            : this(serverIp, "6200", "v1")
        {
        }

        public ContainerUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        protected override string Segment => "containers";
    }
}