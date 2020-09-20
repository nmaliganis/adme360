namespace adme360.view.Controls.Customers
{
    public interface ICustomersView : IMsgView
    {
        //List<CustomerUiModel> Customers { get; set; }
        //List<CustomerUiModel> ActiveCustomers { get; set; }
        bool NoneCustomerWasRetreived { set; }

        //PagedDataRequest RequestPaggingCustomersGrid { get; }
    }
}
