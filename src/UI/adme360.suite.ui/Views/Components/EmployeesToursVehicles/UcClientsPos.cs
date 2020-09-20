using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using adme360.models.DTOs.Trackables;
using adme360.presenter.ViewModel.Trackables;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Trackables;

namespace adme360.suite.ui.Views.Components.EmployeesToursVehicles
{
    public partial class UcClientsPos : BaseModule,
        ITrackablesView,
        ITrackableManagementView
    {

        private TrackablesPresenter _trackablesPresenter;
        private TrackableManagementPresenter _trackableManagementPresenter;

        public UcClientsPos()
        {
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _trackablesPresenter = new TrackablesPresenter(this);
            _trackableManagementPresenter = new TrackableManagementPresenter(this);
        }

        #region Locals

        private void UcClientsPosLoad(object sender, EventArgs e)
        {
            _trackableManagementPresenter.UcLoadedOnDemand();
        }

        private void BtnAddEditTrackableAddTrackableClick(object sender, EventArgs e)
        {
            _trackableManagementPresenter.NewTrackableBtnWasClicked();
        }

        private void BtnAddEditTrackableDeleteTrackableClick(object sender, EventArgs e)
        {
            _trackableManagementPresenter.RemoveTrackableBtnWasClicked();
        }

        private void BtnAddEditTrackableCancelTrackable(object sender, EventArgs e)
        {
            _trackableManagementPresenter.CancelTrackableBtnWasClicked();
        }

        private void BtnAddEditTrackableSaveTrackableClick(object sender, EventArgs e)
        {
            _trackableManagementPresenter.SaveTrackableBtnWasClicked();
        }

        private void TxtAddEditTrackableModelValueChanged(object sender, EventArgs e)
        {
            _trackableManagementPresenter.TrackableModelValueWasChanged();

        }

        private void TxtAddEditTrackableNameEditValueChanged(object sender, EventArgs e)
        {
            _trackableManagementPresenter.TrackableNameValueWasChanged();
        }

        private void TxtAddEditTrackableVendorIdEditValueChanged(object sender, EventArgs e)
        {
            _trackableManagementPresenter.TrackableVendorIdValueWasChanged();
        }

        private void TxtAddEditTrackablePhoneEditValueChanged(object sender, EventArgs e)
        {
            _trackableManagementPresenter.TrackablePhoneValueWasChanged();
        }

        private void TxtAddEditTrackableOsEditValueChanged(object sender, EventArgs e)
        {
            _trackableManagementPresenter.TrackableOsValueWasChanged();
        }

        private void TxtAddEditTrackableVersionEditValueChanged(object sender, EventArgs e)
        {
            _trackableManagementPresenter.TrackableVersionValueWasChanged();
        }

        private void TxtAddEditTrackableNotesEditValueChanged(object sender, EventArgs e)
        {
            _trackableManagementPresenter.TrackableNotesValueWasChanged();
        }
        private void GvTrackablesFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                SelectedTrackableId = Guid.Empty;
                SelectedTrackableName = string.Empty;
                SelectedTrackableVendorId = string.Empty;
                SelectedTrackableModel = string.Empty;
                SelectedTrackableVersion = string.Empty;
                SelectedTrackableOs = string.Empty;
                SelectedTrackablePhone = string.Empty;
                SelectedTrackableNotes = string.Empty;
            }
            else
            {
                SelectedTrackableId = (Guid)gvTrackables.GetRowCellValue(
                    e.FocusedRowHandle, "Id");
                SelectedTrackableName = (string)gvTrackables.GetRowCellValue(
                    e.FocusedRowHandle, "TrackableName");
                SelectedTrackableVendorId = (string)gvTrackables.GetRowCellValue(
                    e.FocusedRowHandle, "TrackableVendorId");
                SelectedTrackableModel = (string)gvTrackables.GetRowCellValue(
                    e.FocusedRowHandle, "TrackableModel");
                SelectedTrackableVersion = (string)gvTrackables.GetRowCellValue(
                    e.FocusedRowHandle, "TrackableVersion");
                SelectedTrackableOs = (string)gvTrackables.GetRowCellValue(
                    e.FocusedRowHandle, "TrackableOs");
                SelectedTrackablePhone = (string)gvTrackables.GetRowCellValue(
                    e.FocusedRowHandle, "TrackablePhone");
                SelectedTrackableNotes = (string)gvTrackables.GetRowCellValue(
                    e.FocusedRowHandle, "TrackableNotes");
            }

            _trackableManagementPresenter.TrackableFromGridWasSelected();
        }

        #endregion

        #region ITrackablesView

        public string OnGeneralMsg { get; set; }

        public List<TrackableUiModel> Trackables
        {
            get => (List<TrackableUiModel>)gvTrackables.DataSource;
            set => gcTrackables.DataSource = value;
        }
        public bool NoneTrackableWasRetrieved { get; set; }

        #endregion

        #region ITrackableManagementView

        public bool TxtTrackableNameEnabled
        {
            get => txtAddEditTrackableName.Enabled;
            set => txtAddEditTrackableName.Enabled = value;
        }

        public string TxtTrackableNameValue
        {
            get => txtAddEditTrackableName.Text;
            set => txtAddEditTrackableName.Text = value;
        }

        public bool TxtTrackableModelEnabled
        {
            get => txtAddEditTrackableModel.Enabled;
            set => txtAddEditTrackableModel.Enabled = value;
        }

        public string TxtTrackableModelValue
        {
            get => txtAddEditTrackableModel.Text;
            set => txtAddEditTrackableModel.Text = value;
        }

        public bool TxtTrackableVendorIdEnabled
        {
            get => txtAddEditTrackableVendorId.Enabled;
            set => txtAddEditTrackableVendorId.Enabled = value;
        }

        public string TxtTrackableVendorIdValue
        {
            get => txtAddEditTrackableVendorId.Text;
            set => txtAddEditTrackableVendorId.Text = value;
        }

        public bool TxtTrackableOsEnabled
        {
            get => txtAddEditTrackableOs.Enabled;
            set => txtAddEditTrackableOs.Enabled = value;
        }

        public string TxtTrackableOsValue
        {
            get => txtAddEditTrackableOs.Text;
            set => txtAddEditTrackableOs.Text = value;
        }

        public bool TxtTrackablePhoneEnabled
        {
            get => txtAddEditTrackablePhone.Enabled;
            set => txtAddEditTrackablePhone.Enabled = value;
        }

        public string TxtTrackablePhoneValue
        {
            get => txtAddEditTrackablePhone.Text;
            set => txtAddEditTrackablePhone.Text = value;
        }

        public bool TxtTrackableVersionEnabled
        {
            get => txtAddEditTrackableVersion.Enabled;
            set => txtAddEditTrackableVersion.Enabled = value;
        }

        public string TxtTrackableVersionValue
        {
            get => txtAddEditTrackableVersion.Text;
            set => txtAddEditTrackableVersion.Text = value;
        }

        public bool TxtTrackableNotesEnabled
        {
            get => txtAddEditTrackableNotes.Enabled;
            set => txtAddEditTrackableNotes.Enabled = value;
        }

        public string TxtTrackableNotesValue
        {
            get => txtAddEditTrackableNotes.Text;
            set => txtAddEditTrackableNotes.Text = value;
        }

        public bool BtnTrackableAddEnabled
        {
            get => btnAddEditTrackablesAddTrackable.Enabled;
            set => btnAddEditTrackablesAddTrackable.Enabled = value;
        }

        public bool BtnTrackableDeleteEnabled
        {
            get => btnAddEditTrackablesDeleteTrackable.Enabled;
            set => btnAddEditTrackablesDeleteTrackable.Enabled = value;
        }

        public bool BtnTrackableCancelEnabled
        {
            get => btnAddEditTrackablesCancelTrackable.Enabled;
            set => btnAddEditTrackablesCancelTrackable.Enabled = value;
        }

        public bool BtnTrackableSaveEnabled
        {
            get => btnAddEditTrackablesSaveTrackable.Enabled;
            set => btnAddEditTrackablesSaveTrackable.Enabled = value;
        }
        public TrackableUiModel SelectedTrackable { get; set; }
        public Guid PreviousSelectedTrackableId { get; set; }
        public Guid SelectedTrackableId { get; set; }
        public string SelectedTrackableName { get; set; }
        public string SelectedTrackableModel { get; set; }
        public string SelectedTrackableVendorId { get; set; }
        public string SelectedTrackableVersion { get; set; }
        public string SelectedTrackableOs { get; set; }
        public string SelectedTrackablePhone { get; set; }
        public string SelectedTrackableNotes { get; set; }
        public TrackableUiModel CreatedTrackable { get; set; }
        public bool TrackableWasChanged { get; set; }
        public Guid ChangedTrackableId { get; set; }
        public string ChangedTrackableName { get; set; }
        public string ChangedTrackableModel { get; set; }
        public string ChangedTrackableVendorId { get; set; }
        public string ChangedTrackableOs { get; set; }
        public string ChangedTrackablePhone { get; set; }
        public string ChangedTrackableVersion { get; set; }
        public string ChangedTrackableNotes { get; set; }
        public TrackableUiModel ChangedTrackable { get; set; }
        public bool NewTrackableWasAdded { get; set; }
        public TrackableUiModel FocusedSelectedTrackable { get; set; }
        public TrackableUiModel ModifiedTrackable { get; set; }
        public TrackableUiModel DeletedTrackable { get; set; }
        public string OnTrackableSaveMsgError { get; set; }
        public string OnTrackableDeleteMsgError { get; set; }

        public bool OnSuccessTrackableCreation
        {
            set
            {
                if (value)
                {
                    XtraMessageBox.Show("Η δημιουργία ενός νέου Συσκευής Απορριμματοφόρου ολοκληρώθηκε με επιτυχία",
                        "Δημιουργία Συσκευής Απορριμματοφόρου",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _trackablesPresenter.LoadAllTrackables();
                }
            }
        }

        public bool OnSuccessTrackableModification
        {
            set
            {
                if (value)
                {
                    XtraMessageBox.Show("Η επεξεργασία ενός νέου Συσκευής Απορριμματοφόρου ολοκληρώθηκε με επιτυχία",
                        "Επεξεργασία Συσκευής Απορριμματοφόρου",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _trackablesPresenter.LoadAllTrackables();
                }
            }
        }
        public bool OnSuccessTrackableDeletion { get; set; }
        public string OnTrackableGeneralMsg { get; set; }

        public bool VerifyForTheTrackableModification
        {
            set
            {
                if (value)
                {
                    var iResult = XtraMessageBox.Show("Πρόκειται να επεξεργαστείτε μια καταχώρηση Συσκευής Απορριμματοφόρου. Παρακαλώ επιβεβαιώστε!", "Αλλαγή Συσκευής Απορριμματοφόρου",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    ActionAfterVerifyForTheTrackableModification = iResult == DialogResult.OK;
                }
            }
        }
        public bool ActionAfterVerifyForTheTrackableModification { get; set; }
        public bool ActionAfterSuccessTrackableModification { get; set; }
        public bool VerifyForTheTrackableDeletion { get; set; }
        public bool ActionAfterVerifyForTheTrackableDeletion { get; set; }

        public bool UcWasLoadedOnDemand
        {
            set
            {
                if (value)
                {
                    _trackablesPresenter.LoadAllTrackables();
                }
            }
        }


        #endregion


    }
}
