using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Categories
{
    public class CategoryDoesNotExistException : Exception
    {
        public Guid CategoryId { get; }
        public string CategoryName { get; }

        public CategoryDoesNotExistException(Guid categoryId)
        {
            CategoryId = categoryId;
        }

        public CategoryDoesNotExistException(string categoryName)
        {
          CategoryName = categoryName;
        }

        public override string Message => $"Category with Id: {CategoryId} or Name:{CategoryName} doesn't exists!";
    }
}
