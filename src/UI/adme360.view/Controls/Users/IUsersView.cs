using System.Collections.Generic;
using adme360.models.DTOs.Users;
using adme360.models.DTOs.Vehicles;

namespace adme360.view.Controls.Users
{
    public interface IUsersView : IMsgView
    {
        List<UserForAllRetrievalUiModel> Users { get; set; }
        bool NoneUserWasRetrieved { set; }
    }
}