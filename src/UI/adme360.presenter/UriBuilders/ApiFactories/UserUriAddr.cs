using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class UserUriAddr : BaseClientUri
    {
        public UserUriAddr(string serverIp)
            : this(serverIp, "6100", "v1")
        {
        }

        public UserUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        public override bool IsVersioning { get; set; } = true;

        protected override string Segment => "users";
    }
}