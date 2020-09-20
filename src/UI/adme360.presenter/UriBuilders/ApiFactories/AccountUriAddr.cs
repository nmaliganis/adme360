using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class AccountUriAddr : BaseClientUri
    {
        public AccountUriAddr(string serverIp)
            : this(serverIp, "6100", "v1")
        {
        }

        public AccountUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        public override bool IsVersioning { get; set; } = false;

        protected override string Segment => "accounts";
    }
}