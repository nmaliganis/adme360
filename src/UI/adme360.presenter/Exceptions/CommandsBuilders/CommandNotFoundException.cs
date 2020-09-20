using System;

namespace adme360.presenter.Exceptions
{
    public class CommandNotFoundException : Exception
    {
        public string Content { get; }

        public CommandNotFoundException()
        {
        }

        public CommandNotFoundException(string content)
        {
            Content = content;
        }
    }
}