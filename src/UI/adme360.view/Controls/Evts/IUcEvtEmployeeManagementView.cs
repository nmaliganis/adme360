using adme360.view;

namespace adme360.view.Controls.Evts
{
    public interface IUcEvtEmployeeManagementView : IView
    {
        bool OpenFlyoutForAddEmployee { set; }
        bool OnEmployeeManagementLoaded { set; }

        bool BtnEmployeeManagementAddEmployee { set; }
        bool BtnEmployeeManagementEditEmployee { set; }
        bool BtnEmployeeManagementDeleteEmployee { set; }
    }
}