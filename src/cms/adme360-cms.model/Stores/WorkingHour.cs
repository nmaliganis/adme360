using System;
using adme360.common.infrastructure.Domain;

namespace adme360.cms.model.Stores
{
  public class WorkingHour : EntityBase<Guid>
  {
    protected WorkingHour()
    {
      OnCreated();
    }

    private void OnCreated()
    {
    }

    public virtual WeekDay Day { get; set; }
    public virtual DateTime Start { get; set; }
    public virtual DateTime End { get; set; }
    public virtual string Comments { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime ModifiedDate { get; set; }
    public virtual Guid CreatedBy { get; set; }
    public virtual Guid ModifiedBy { get; set; }
    public virtual bool IsActive { get; set; }
    public virtual Store Store { get; set; }
    protected override void Validate()
    {

    }
  }
}

