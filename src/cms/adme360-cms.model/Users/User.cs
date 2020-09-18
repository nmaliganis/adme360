using System;
using System.Collections.Generic;
using adme360.cms.model.Customers;
using adme360.common.infrastructure.Domain;
using adme360.common.infrastructure.Helpers.Security;

namespace adme360.cms.model.Users
{
  public class User : EntityBase<Guid>, IAggregateRoot
  {
    public User()
    {
      OnCreate();
    }

    private void OnCreate()
    {
      this.IsActive = true;
      this.CreatedDate = DateTime.UtcNow;
      this.ModifiedDate = DateTime.UtcNow;
      this.ResetDate = DateTime.UtcNow;
    }

    public virtual string Login { get; set; }
    public virtual string PasswordHash { get; set; }
    public virtual bool IsActivated { get; set; }
    public virtual Guid CreatedBy { get; set; }
    public virtual Guid ModifiedBy { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime ModifiedDate { get; set; }
    public virtual Guid ResetKey { get; set; }
    public virtual Guid ActivationKey { get; set; }
    public virtual DateTime ResetDate { get; set; }
    public virtual bool IsActive { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ISet<UserRole> UsersRoles { get; set; }

    protected override void Validate()
    {

    }

    public virtual void InjectWithInitialAttributes(string customerUserLogin, string customerUserPassword)
    {
      this.Login = customerUserLogin;
      this.PasswordHash = HashHelper.Sha512(customerUserPassword + customerUserLogin);
      this.IsActivated = false;
      this.ResetDate = DateTime.UtcNow;
      this.CreatedDate = DateTime.UtcNow;
      this.ModifiedDate = DateTime.UtcNow;
      this.ResetKey = Guid.NewGuid();
      this.ActivationKey = Guid.NewGuid();
    }

    public virtual void InjectWithAuditCreation(Guid accountIdToCreateThisUser)
    {
      this.CreatedBy = accountIdToCreateThisUser;
      this.ModifiedBy = Guid.Empty;
    }

    public virtual void InjectWithUserRole(UserRole userRoleToBeInjected)
    {
      this.UsersRoles.Add(userRoleToBeInjected);
      userRoleToBeInjected.User = this;
    }
  }
}


