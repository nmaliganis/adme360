using System;
using adme360.common.infrastructure.Domain;

namespace adme360.auth.api.Helpers.Models
{

    public class UserRole : EntityBase<Guid>
    {
        public UserRole()
        {
            OnCreated();
        }

        private void OnCreated()
        {
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
            this.IsActive = true;
        }

        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual Guid CreatedBy { get; set; }
        public virtual Guid ModifiedBy { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }

        protected override void Validate()
        {

        }

        public virtual void InjectWithRole(Role roleToBeInjected)
        {
            this.Role = roleToBeInjected;
            roleToBeInjected.Usersroles.Add(this);
        }

        public virtual void InjectWithAuditCreation(Guid accountIdToCreateThisUser)
        {
            this.CreatedBy = accountIdToCreateThisUser;
            this.ModifiedBy = Guid.Empty;
        }
    }
}
