using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class TourUriAddr : BaseClientUri
    {
        public TourUriAddr(string serverIp)
            : this(serverIp, "6200", "v1")
        {
        }

        public TourUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        protected override string Segment => "tours";
    }
}