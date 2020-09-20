using dl.wm.presenter.UriBuilders.ApiFactories.Base;

namespace dl.wm.presenter.UriBuilders.ApiFactories
{
    public class DeviceUriAddr : BaseClientUri
    {
        public DeviceUriAddr(string serverIp)
            : this(serverIp, "6200", "v1")
        {
        }

        public DeviceUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        protected override string Segment => "Devices";
    }
}