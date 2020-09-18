using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Categories
{
    public class CategoryAlreadyExistsException : Exception
    {
        public string Name { get; }
        public string BrokenRules { get; }

        public CategoryAlreadyExistsException(string name)
           : this(name, "NO_BROKEN_RULES")
        {
        }
        public CategoryAlreadyExistsException(string name, string brokenRules)
        {
            Name = name;
            BrokenRules = brokenRules;
        }

        public override string Message => $" Category with name:{Name} already Exists!\n Additional info:{BrokenRules}";
    }
}
