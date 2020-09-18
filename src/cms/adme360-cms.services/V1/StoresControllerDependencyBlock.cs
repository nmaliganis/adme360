using adme360.cms.contracts.Stores;
using adme360.cms.contracts.V1;

namespace adme360.cms.services.V1
{
    public class StoresControllerDependencyBlock : IStoresControllerDependencyBlock
    {
        public StoresControllerDependencyBlock(ICreateStoreProcessor createStoreProcessor,
                                                        IInquiryStoreProcessor inquiryStoreProcessor,
                                                        IUpdateStoreProcessor updateStoreProcessor,
                                                        IInquiryAllStoresProcessor allStoreProcessor,
                                                        IDeleteStoreProcessor deleteStoreProcessor)

        {
            CreateStoreProcessor = createStoreProcessor;
            InquiryStoreProcessor = inquiryStoreProcessor;
            UpdateStoreProcessor = updateStoreProcessor;
            InquiryAllStoresProcessor = allStoreProcessor;
            DeleteStoreProcessor = deleteStoreProcessor;
        }

        public ICreateStoreProcessor CreateStoreProcessor { get; private set; }
        public IInquiryStoreProcessor InquiryStoreProcessor { get; private set; }
        public IUpdateStoreProcessor UpdateStoreProcessor { get; private set; }
        public IInquiryAllStoresProcessor InquiryAllStoresProcessor { get; private set; }
        public IDeleteStoreProcessor DeleteStoreProcessor { get; private set; }
    }
}