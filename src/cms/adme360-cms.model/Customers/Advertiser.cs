using System;
using System.Collections.Generic;
using System.Text;
using adme360.cms.model.Stores;

namespace adme360.cms.model.Customers
{
  public class Advertiser : Customer
  {

    public Advertiser()
    {
      OnCreated();
    }

    protected void OnCreated()
    {
      this.CreatedDate = DateTime.Now;
      this.Stores = new HashSet<Store>();
    }
    public override CustomerType Type => CustomerType.Advertiser;

    public virtual ISet<Store> Stores { get; set; }
  }
}
