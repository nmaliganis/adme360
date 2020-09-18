using adme360.cms.contracts.Categories;

namespace adme360.cms.contracts.V1
{
    public interface ICategoriesControllerDependencyBlock
    {
        ICreateCategoryProcessor CreateCategoryProcessor { get; }
        IInquiryCategoryProcessor InquiryCategoryProcessor { get; }
        IUpdateCategoryProcessor UpdateCategoryProcessor { get; }
        IInquiryAllCategoriesProcessor InquiryAllCategoriesProcessor { get; }
        IDeleteCategoryProcessor DeleteCategoryProcessor { get; }
    }
}