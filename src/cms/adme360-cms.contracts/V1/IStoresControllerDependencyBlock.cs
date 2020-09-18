using adme360.cms.contracts.Categories;
using adme360.cms.contracts.Stores;

namespace adme360.cms.contracts.V1
{
    public interface IStoresControllerDependencyBlock
    {
        ICreateStoreProcessor CreateStoreProcessor { get; }
        IInquiryStoreProcessor InquiryStoreProcessor { get; }
        IUpdateStoreProcessor UpdateStoreProcessor { get; }
        IInquiryAllStoresProcessor InquiryAllStoresProcessor { get; }
        IDeleteStoreProcessor DeleteStoreProcessor { get; }
    }
}