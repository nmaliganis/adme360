using System;

namespace dl.wm.presenter.Exceptions
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