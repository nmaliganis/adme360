using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class UserJwtUriAddr : BaseClientUri
    {
        public UserJwtUriAddr(string serverIp)
            : this(serverIp, "6100", "v1")
        {
        }

        public UserJwtUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        public override bool IsVersioning { get; set; } = false;

        protected override string Segment => "userJwt/authtoken";
    }
}