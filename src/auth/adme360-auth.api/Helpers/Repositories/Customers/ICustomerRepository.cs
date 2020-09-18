using System;
using System.Collections.Generic;
using adme360.auth.api.Helpers.Models;
using adme360.common.infrastructure.Domain;

namespace adme360.auth.api.Helpers.Repositories.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        Customer FindCustomerByEmail(string email);
        IList<Customer> FindCustomersByEmailOrLogin(string login);
    }
}
