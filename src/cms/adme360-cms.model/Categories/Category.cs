using System;
using System.Collections.Generic;
using adme360.cms.model.Customers;
using adme360.common.infrastructure.Domain;

namespace adme360.cms.model.Categories
{
  public class Category : EntityBase<Guid>, IAggregateRoot
  {
    public Category()
    {
      OnCreate();
    }

    private void OnCreate()
    {
      this.IsActive = true;
      this.CreatedDate = DateTime.UtcNow;
      this.ModifiedDate = DateTime.UtcNow;
      this.Customers = new HashSet<Customer>();
    }

    public virtual string Name { get; set; }
    public virtual Guid CreatedBy { get; set; }
    public virtual Guid ModifiedBy { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime ModifiedDate { get; set; }
    public virtual bool IsActive { get; set; }
    public virtual ISet<Customer> Customers { get; set; }

    protected override void Validate()
    {
    }

    public virtual void InjectWithAudit(Guid accountIdToCreateThisCategory)
    {
      this.CreatedBy = accountIdToCreateThisCategory;
    }
  }
}


