using adme360.view;

namespace adme360.view.Controls.Evts
{
    public interface IUcEvtManagementView : IView
    {
        string SelectedModuleItem { get; set; }

        bool PopulateUcCtrl { set; }
    }
}
