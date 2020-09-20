using System;
using System.Drawing;
using adme360.view;
using adme360.models.DTOs.Containers;

namespace adme360.view.Controls.Containers
{
    public interface IUcContainerManagementView : IView
    {
        bool ContainerWasSelected { get; set; }
        Guid PreviousSelectedContainerId { get; set; }
        Guid SelectedContainerId { get; set; }
        string SelectedContainerName { get; set; }
        string SelectedContainerAddress { get; set; }
        double SelectedContainerLocationLat { get; set; }
        double SelectedContainerLocationLong { get; set; }
        string SelectedContainerLevel { get; set; }
        string SelectedContainerTimeToFull { get; set; }
        string SelectedContainerFillLevelValue { get; set; }
        string SelectedContainerTypeValue { get; set; }
        string SelectedContainerStatusValue { get; set; }
        DateTime SelectedContainerLastServicedDateValue { get; set; }
        DateTime SelectedContainerFirstRegistrationDateValue { get; set; }
        string SelectedContainerImageName { get; set; }

        ContainerUiModel SelectedContainer { get; set; }
        ContainerUiModel ChangedContainer { get; set; }
        bool NewContainerWasAdded { get; set; }
        ContainerUiModel FocusedSelectedContainer { get; set; }

        Guid ChangedContainerId { get; set; }
        string ChangedContainerName { get; set; }
        string ChangedContainerAddress { get; set; }
        double ChangedContainerLocationLat { get; set; }
        double ChangedContainerLocationLong { get; set; }
        string ChangedContainerLevel { get; set; }
        string ChangedContainerTimeToFull { get; set; }
        string ChangedContainerFillLevelValue { get; set; }
        string ChangedContainerTypeValue { get; set; }
        string ChangedContainerStatusValue { get; set; }
        DateTime ChangedContainerLastServicedDateValue { get; set; }
        DateTime ChangedContainerFirstRegistrationDateValue { get; set; }
        string ChangedContainerImageName { get; set; }

        string PctContainerImageValue { set; }

        bool InitialLoadingWasCaught { set; }
        bool OpenFlyoutForAddContainer { set; }
        bool OnPopulateContainerDataAfterSelection { set; }
        bool OpenFlyoutForEditContainer { set; }
    }
}
