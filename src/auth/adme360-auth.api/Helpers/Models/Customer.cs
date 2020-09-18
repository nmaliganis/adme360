using System;
using adme360.common.infrastructure.Domain;

namespace adme360.auth.api.Helpers.Models
{
    public class Customer : EntityBase<Guid>, IAggregateRoot
    {
        public Customer()
        {
            OnCreate();
        }

        private void OnCreate()
        {
            this.IsActive = true;
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
        }

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
        public virtual User User { get; set; }

        protected override void Validate()
        {

        }

        public virtual void InjectWithAuditCreation(Guid accountIdToCreateThisUser)
        {
            this.CreatedBy = accountIdToCreateThisUser;
            this.ModifiedBy = Guid.Empty;
        }
    }
}
