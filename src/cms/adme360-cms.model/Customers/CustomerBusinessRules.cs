using adme360.common.infrastructure.Domain;

namespace adme360.cms.model.Customers
{
    public class CustomerBusinessRules
    {
        public static BusinessRule FirstName => new BusinessRule("Customer", "Customer First Name must not be null or empty!");
        public static BusinessRule LastName => new BusinessRule("Customer", "Customer Last Name must not be null or empty!");
    }
}