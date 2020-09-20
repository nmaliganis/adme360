using System;
using adme360.view;
using adme360.models.DTOs.Trackables;

namespace adme360.view.Controls.Trackables
{
    public interface ITrackableManagementView : IView
    {
        bool TxtTrackableNameEnabled { get; set; }
        string TxtTrackableNameValue { get; set; }

        bool TxtTrackableModelEnabled { get; set; }
        string TxtTrackableModelValue { get; set; }
        
        bool TxtTrackableVendorIdEnabled { get; set; }
        string TxtTrackableVendorIdValue { get; set; }
        
        bool TxtTrackableOsEnabled { get; set; }
        string TxtTrackableOsValue { get; set; }

        bool TxtTrackablePhoneEnabled { get; set; }
        string TxtTrackablePhoneValue { get; set; }

        bool TxtTrackableVersionEnabled { get; set; }
        string TxtTrackableVersionValue { get; set; }
        
        bool TxtTrackableNotesEnabled { get; set; }
        string TxtTrackableNotesValue { get; set; }

        bool BtnTrackableAddEnabled { get; set; }
        bool BtnTrackableDeleteEnabled { get; set; }
        bool BtnTrackableCancelEnabled { get; set; }
        bool BtnTrackableSaveEnabled { get; set; }

        TrackableUiModel SelectedTrackable { get; set; }
        Guid PreviousSelectedTrackableId { get; set; }
        Guid SelectedTrackableId { get; set; }
        string SelectedTrackableName { get; set; }
        string SelectedTrackableModel { get; set; }
        string SelectedTrackableVendorId { get; set; }
        string SelectedTrackableVersion { get; set; }
        string SelectedTrackableOs { get; set; }
        string SelectedTrackablePhone { get; set; }
        string SelectedTrackableNotes { get; set; }
        
        
        TrackableUiModel CreatedTrackable { get; set; }
        bool TrackableWasChanged { get; set; }
        Guid ChangedTrackableId { get; set; }
        string ChangedTrackableName { get; set; }
        string ChangedTrackableModel { get; set; }
        string ChangedTrackableVendorId { get; set; }
        string ChangedTrackableOs { get; set; }
        string ChangedTrackablePhone { get; set; }
        string ChangedTrackableVersion { get; set; }
        string ChangedTrackableNotes { get; set; }
        TrackableUiModel ChangedTrackable { get; set; }
        bool NewTrackableWasAdded { get; set; }
        TrackableUiModel FocusedSelectedTrackable { get; set; }

        TrackableUiModel ModifiedTrackable { get; set; }
        TrackableUiModel DeletedTrackable { get; set; }

        string OnTrackableSaveMsgError { set; }
        string OnTrackableDeleteMsgError { set; }
        bool OnSuccessTrackableCreation { set; }
        bool OnSuccessTrackableModification { set; }
        bool OnSuccessTrackableDeletion { set; }
        string OnTrackableGeneralMsg { set; }
        bool VerifyForTheTrackableModification { set; }
        bool ActionAfterVerifyForTheTrackableModification { get; set; }
        bool ActionAfterSuccessTrackableModification { get; set; }
        bool VerifyForTheTrackableDeletion { set; }
        bool ActionAfterVerifyForTheTrackableDeletion { get; set; }
        bool UcWasLoadedOnDemand { set; }
    }
}
