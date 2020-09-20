using adme360.view;

namespace adme360.view.Controls.Configurations
{
    public interface IUcConfigurationManagementView : IView
    {
        string SelectedModuleItem { get; set; }

        bool PopulateUcCtrl { set; }
    }
}
