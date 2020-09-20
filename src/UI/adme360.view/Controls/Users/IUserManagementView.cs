using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adme360.view;

namespace adme360.view.Controls.Users
{
    public interface IUserManagementView : IView
    {
        bool UcUserWasLoadedOnDemand { set; }
        bool OpenFlyoutForAddUser { set; }
    }
}
