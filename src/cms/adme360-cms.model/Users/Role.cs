using System;
using System.Collections.Generic;
using adme360.common.infrastructure.Domain;

namespace adme360.cms.model.Users
{
    public class Role : EntityBase<Guid>, IAggregateRoot
    {
        public Role()
        {
            OnCreated();
        }

        private void OnCreated()
        {
            this.IsActive = true;
            this.CreatedDate = DateTime.UtcNow;
            this.Usersroles = new HashSet<UserRole>();
        }

        public virtual string Name { get; set; }
        public virtual Guid CreatedBy { get; set; }
        public virtual Guid ModifiedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual ISet<UserRole> Usersroles { get; set; }

        protected override void Validate()
        {
        }
    }
}
