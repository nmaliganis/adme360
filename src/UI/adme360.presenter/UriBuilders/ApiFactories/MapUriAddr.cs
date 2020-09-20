using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class MapUriAddr : BaseClientUri
    {
        public MapUriAddr(string serverIp)
            : this(serverIp, "6200", "v1")
        {
        }

        public MapUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        public override bool IsVersioning { get; set; } = true;

        protected override string Segment => "maps";
    }
}