using System;
using System.Collections.Generic;
using System.Globalization;
using adme360.cms.model.Addresses;
using adme360.cms.model.Customers;
using adme360.cms.model.Devices;
using adme360.common.infrastructure.Domain;
using GeoAPI.Geometries;

namespace adme360.cms.model.Stores
{
  public class Store : EntityBase<Guid>, IAggregateRoot
  {
    protected Store()
    {
      OnCreated();
    }

    private void OnCreated()
    {
      this.WorkingHours = new HashSet<WorkingHour>();
      this.Registrations = new HashSet<Registration>();
    }

    public virtual IGeometry Point { get; set; }
    public virtual string Supervisor { get; set; }
    public virtual Address Address { get; set; }
    public virtual string Name { get; set; }
    public virtual StoreStatus Status { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime ModifiedDate { get; set; }
    public virtual Guid CreatedBy { get; set; }
    public virtual Guid ModifiedBy { get; set; }
    public virtual bool IsActive { get; set; }
    public virtual Advertiser Advertiser { get; set; }
    public virtual ISet<WorkingHour> WorkingHours { get; set; }
    public virtual ISet<Registration> Registrations { get; set; }

    protected override void Validate()
    {

    }
  }
}

