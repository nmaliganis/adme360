using System;
using System.Collections.Generic;
using System.Linq;
using adme360.auth.api.Helpers.Security;
using adme360.common.dtos.Vms.Accounts;
using adme360.common.infrastructure.Domain;

namespace adme360.auth.api.Helpers.Models
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
            this.UsersRoles = new HashSet<UserRole>();
            this.UserTokens = new HashSet<UserToken>();
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
        public virtual ISet<UserToken> UserTokens { get; set; }

        protected override void Validate()
        {

        }

        public virtual void InjectWithCustomer(Customer customerToBeInjected)
        {
            this.Customer = customerToBeInjected;
            customerToBeInjected.User = this;
        }

        public virtual void InjectWithInitialAttributes(UserForRegistrationUiModel newUserForRegistration)
        {
            this.Login = newUserForRegistration.Login;
            this.PasswordHash = HashHelper.Sha512(newUserForRegistration.Password + newUserForRegistration.Login);
            this.IsActivated = false;
            this.ResetDate = DateTime.UtcNow;
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
            this.ResetKey = Guid.NewGuid();
            this.ActivationKey = Guid.NewGuid();
        }

        public virtual void InjectWithUserRole(UserRole userRoleToBeInjected)
        {
            this.UsersRoles.Add(userRoleToBeInjected);
            userRoleToBeInjected.User = this;
        }

        public virtual void InjectWithUserToken(UserToken userTokenToBeInjected)
        {
            this.UserTokens.Add(userTokenToBeInjected);
            userTokenToBeInjected.User = this;
        }

        public virtual void InjectWithAuditCreation(Guid accountIdToCreateThisUser)
        {
            this.CreatedBy = accountIdToCreateThisUser;
            this.ModifiedBy = Guid.Empty;
        }

        public virtual void Activate()
        {
            this.IsActivated = true;
        }

        public virtual void InjectWithAudit(Guid accountIdToActivateThisUser)
        {
            this.ModifiedBy = accountIdToActivateThisUser;
        }

        public virtual void ModifyWithRefreshToken(Guid refreshToken)
        {
          this.UserTokens.FirstOrDefault(t => t.RefreshToken == refreshToken).Expired = true;
        }

    }
}


