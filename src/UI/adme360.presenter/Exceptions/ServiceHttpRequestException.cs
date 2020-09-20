using System;
using System.Net;

namespace dl.wm.presenter.Exceptions
{
    public class ServiceHttpRequestException<T> : Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }
        public T Content { get; private set; }

        public ServiceHttpRequestException(HttpStatusCode statusCode, T content)
        {
            HttpStatusCode = statusCode;
            Content = content;
        }

        public override string Message => $"Service HTTP Request Exception. Status code: {HttpStatusCode}";
    }
    public class ServiceHttpRequestException : Exception
    {
        public string E{ get; private set; }

        public ServiceHttpRequestException(string e)
        {
            E = e;
        }

        public override string Message => $"Error {E}";
    }
}
