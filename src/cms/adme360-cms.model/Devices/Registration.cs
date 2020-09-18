using System;
using System.Collections.Generic;
using adme360.cms.model.Stores;
using adme360.common.infrastructure.Domain;
using GeoAPI.Geometries;

namespace adme360.cms.model.Devices
{
  public class Registration : EntityBase<Guid>, IAggregateRoot
  {
    protected Registration()
    {
      OnCreated();
    }

    private void OnCreated()
    {
      this.RegisteredDate = DateTime.Now;
    }

    public virtual Device Device { get; set; }
    public virtual Store Store { get; set; }
    public virtual DateTime RegisteredDate { get; set; }
    protected override void Validate()
    {
    }
  }
}

