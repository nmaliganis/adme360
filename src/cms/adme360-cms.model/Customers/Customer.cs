using System;
using adme360.cms.model.Addresses;
using adme360.cms.model.Categories;
using adme360.cms.model.Users;
using adme360.common.infrastructure.Domain;

namespace adme360.cms.model.Customers
{
  public abstract class Customer : EntityBase<Guid>, IAggregateRoot
  {
    public abstract CustomerType Type { get; }

    public virtual string Firstname { get; set; }
    public virtual string Lastname { get; set; }
    public virtual string Brand { get; set; }
    public virtual string Email { get; set; }
    public virtual string Phone { get; set; }
    public virtual string Vat { get; set; }
    public virtual string Website { get; set; }
    public virtual string Notes { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime ModifiedDate { get; set; }
    public virtual Guid CreatedBy { get; set; }
    public virtual Guid ModifiedBy { get; set; }
    public virtual Address Address { get; set; }
    public virtual bool Activated { get; set; }
    public virtual bool IsActive { get; set; }
    public virtual Category Category { get; set; }
    public virtual User User { get; set; }
    protected override void Validate()
    {

    }

    public virtual void InjectWithAuditCreation(Guid accountIdToCreateThisUser)
    {
      this.CreatedBy = accountIdToCreateThisUser;
      this.ModifiedBy = Guid.Empty;
    }

    public virtual void InjectWithCategory(Category categoryToBeInjected)
    {
      this.Category = categoryToBeInjected;
      categoryToBeInjected.Customers.Add(this);
    }

    public virtual void InjectWithUser(User userToBeCreated)
    {
      this.User = userToBeCreated;
      userToBeCreated.Customer = this;
    }
  }
}

