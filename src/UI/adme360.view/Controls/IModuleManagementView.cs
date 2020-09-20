using adme360.view;

namespace adme360.view.Controls
{
    public interface IModuleManagementView : IView
    {
        string SelectedModuleItem { get; set; }
        bool PopulateUcCtrl { set; }
    }
}
