using adme360.cms.contracts.Customers;
using adme360.cms.contracts.V1;

namespace adme360.cms.services.V1
{
  public class CustomersControllerDependencyBlock : ICustomersControllerDependencyBlock
  {
    public CustomersControllerDependencyBlock(
      ICreateCustomerProcessor createCustomerProcessor,
      IInquiryCustomerProcessor inquiryCustomerProcessor,
      IInquiryAllCustomersProcessor allCustomerProcessor)

    {
      CreateCustomerProcessor = createCustomerProcessor;
      InquiryCustomerProcessor = inquiryCustomerProcessor;
      InquiryAllCustomersProcessor = allCustomerProcessor;
    }

    public ICreateCustomerProcessor CreateCustomerProcessor { get; private set; }
    public IInquiryCustomerProcessor InquiryCustomerProcessor { get; private set; }
    public IInquiryAllCustomersProcessor InquiryAllCustomersProcessor { get; private set; }
  }
}