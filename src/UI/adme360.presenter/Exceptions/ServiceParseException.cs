using System;

namespace dl.wm.presenter.Exceptions
{
    public class ServiceParseException : Exception
    {
        public string Content { get; private set; }

        public ServiceParseException(string content, string message)
            : base(message)
        {
            Content = content;
        }

    }
}
