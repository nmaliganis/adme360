using adme360.common.infrastructure.Domain;

namespace adme360.cms.model.Addresses
{
    public class Address : ValueObjectBase
    {
        public virtual string StreetOne { get; set; }
        public virtual string StreetTwo { get; set; }
        public virtual string PostCode { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }

        protected override void Validate()
        {
            
        }
    }
}
