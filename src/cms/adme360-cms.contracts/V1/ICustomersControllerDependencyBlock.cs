using adme360.cms.contracts.Customers;

namespace adme360.cms.contracts.V1
{
  public interface ICustomersControllerDependencyBlock
  {
    ICreateCustomerProcessor CreateCustomerProcessor { get; }
    IInquiryCustomerProcessor InquiryCustomerProcessor { get; }
    IInquiryAllCustomersProcessor InquiryAllCustomersProcessor { get; }
  }
}