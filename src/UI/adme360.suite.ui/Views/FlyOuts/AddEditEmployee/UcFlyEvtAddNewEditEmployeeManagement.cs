using System;
using adme360.suite.ui.Controls;

namespace adme360.suite.ui.Views.FlyOuts.AddEditEmployee
{
    public partial class UcFlyEvtAddNewEditEmployeeManagement : BaseModule
    {
        public UcFlyEvtAddNewEditEmployeeManagement()
        {
            InitializeComponent();
        }

        private void BtnEvtAddEditEmployeeCancelClick(object sender, EventArgs e)
        {
            (this.Parent as CustomFlyoutDialog).Close();
        }
    }
}
