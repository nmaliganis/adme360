using System;
using System.Collections.Generic;
using adme360.cms.model.Stores;
using adme360.common.infrastructure.Domain;
using GeoAPI.Geometries;

namespace adme360.cms.model.Devices
{
  public class Device : EntityBase<Guid>, IAggregateRoot
  {
    protected Device()
    {
      OnCreated();
    }

    private void OnCreated()
    {
      this.Registrations = new HashSet<Registration>();
    }

    public virtual string SerialNumber { get; set; }
    public virtual string Ip { get; set; }
    public virtual int Port { get; set; }
    public virtual ISet<Registration> Registrations { get; set; }
    protected override void Validate()
    {
    }
  }
}

