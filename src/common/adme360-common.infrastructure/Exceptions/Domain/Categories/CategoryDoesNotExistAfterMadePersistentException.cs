using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Categories
{
    public class CategoryDoesNotExistAfterMadePersistentException : Exception
    {
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }

        public CategoryDoesNotExistAfterMadePersistentException(string name)
        {
            Name = name;
        }
        public CategoryDoesNotExistAfterMadePersistentException(Guid categoryId)
        {
            CategoryId = categoryId;
        }

        public override string Message => $" Category with Name: {Name} or Id: {CategoryId} was not made Persistent!";
    }
}