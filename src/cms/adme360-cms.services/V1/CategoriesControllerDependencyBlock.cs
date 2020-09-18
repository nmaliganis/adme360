using adme360.cms.contracts.Categories;
using adme360.cms.contracts.V1;

namespace adme360.cms.services.V1
{
    public class CategoriesControllerDependencyBlock : ICategoriesControllerDependencyBlock
    {
        public CategoriesControllerDependencyBlock(ICreateCategoryProcessor createCategoryProcessor,
                                                        IInquiryCategoryProcessor inquiryCategoryProcessor,
                                                        IUpdateCategoryProcessor updateCategoryProcessor,
                                                        IInquiryAllCategoriesProcessor allCategoryProcessor,
                                                        IDeleteCategoryProcessor deleteCategoryProcessor)

        {
            CreateCategoryProcessor = createCategoryProcessor;
            InquiryCategoryProcessor = inquiryCategoryProcessor;
            UpdateCategoryProcessor = updateCategoryProcessor;
            InquiryAllCategoriesProcessor = allCategoryProcessor;
            DeleteCategoryProcessor = deleteCategoryProcessor;
        }

        public ICreateCategoryProcessor CreateCategoryProcessor { get; private set; }
        public IInquiryCategoryProcessor InquiryCategoryProcessor { get; private set; }
        public IUpdateCategoryProcessor UpdateCategoryProcessor { get; private set; }
        public IInquiryAllCategoriesProcessor InquiryAllCategoriesProcessor { get; private set; }
        public IDeleteCategoryProcessor DeleteCategoryProcessor { get; private set; }
    }
}