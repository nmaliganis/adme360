using adme360.presenter.UriBuilders.ApiFactories.Base;

namespace adme360.presenter.UriBuilders.ApiFactories
{
    public class SimcardUriAddr : BaseClientUri
    {
        public SimcardUriAddr(string serverIp)
            : this(serverIp, "6200", "v1")
        {
        }

        public SimcardUriAddr(string serverIp, string serverPort, string versioning)
            : base(serverIp, serverPort)
        {
            Versioning = versioning;
        }

        protected sealed override string Versioning { get; set; }

        protected override string Segment => "simcards";
    }
}