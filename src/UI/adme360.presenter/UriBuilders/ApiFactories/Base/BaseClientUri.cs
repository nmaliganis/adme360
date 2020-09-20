using System.Text;

namespace dl.wm.presenter.UriBuilders.ApiFactories.Base
{
    public abstract class BaseClientUri
    {
        public string ServerIp { get; }
        public string ServerPort { get; }
        protected abstract string Versioning { get; set; }

        public bool IsSecured { get; set; } = false;
        public virtual bool IsVersioning { get; set; } = true;

        protected abstract string Segment { get; }
        protected BaseClientUri(string serverIp, string serverPort)
        {
            ServerIp = serverIp;
            ServerPort = serverPort;
        }

        public string BuildUri()
        {
            var uriSb = new StringBuilder();

            uriSb.Append(IsSecured ? "https://" : "http://");
            uriSb.Append(ServerIp);
            uriSb.Append(":");
            uriSb.Append(ServerPort);
            uriSb.Append("/");
            uriSb.Append("api");
            if (IsVersioning)
            {
                uriSb.Append("/");
                uriSb.Append(Versioning);
            }
            uriSb.Append("/");
            uriSb.Append(Segment);

            return uriSb.ToString();
        }
    }
}