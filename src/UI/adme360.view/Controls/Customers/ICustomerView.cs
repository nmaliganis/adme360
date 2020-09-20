using System;

namespace adme360.view.Controls.Customers
{
    public interface ICustomerView : IMsgView
    {
        //CustomerUiModel Customer { set; }
        Guid SelectedCustomerId { get; set; }
    }
}