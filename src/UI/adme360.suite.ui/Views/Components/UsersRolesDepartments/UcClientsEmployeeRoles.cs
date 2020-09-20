using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using adme360.models.DTOs.Employees.EmployeeRoles;
using adme360.presenter.ViewModel.Employees.EmployeeRoles;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Employees.EmployeeRoles;

namespace adme360.suite.ui.Views.Components.UsersRolesDepartments
{
    public partial class UcClientsEmployeeRoles : BaseModule, 
        IEmployeeRoleManagementView, 
        IEmployeeRolesView
    {

        private EmployeeRolesPresenter _employeeRolesPresenter;
        private EmployeeRoleManagementPresenter _employeeRoleManagementPresenter;

        public UcClientsEmployeeRoles()
        {
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _employeeRolesPresenter = new EmployeeRolesPresenter(this);
            _employeeRoleManagementPresenter = new EmployeeRoleManagementPresenter(this);
        }

        #region IEmployeeRoleManagementView

        public bool TxtEmployeeRoleNameEnabled
        {
            get => txtEvtAddEditEmployeeRoleName.Enabled;
            set => txtEvtAddEditEmployeeRoleName.Enabled = value;
        }

        public string TxtEmployeeRoleNameValue
        {
            get => txtEvtAddEditEmployeeRoleName.Text;
            set => txtEvtAddEditEmployeeRoleName.Text = value;
        }

        public bool TxtEmployeeRoleNotesEnabled
        {
            get => mmEdtEmployeeRoleNotes.Enabled;
            set => mmEdtEmployeeRoleNotes.Enabled = value;
        }

        public string TxtEmployeeRoleNotesValue
        {
            get => mmEdtEmployeeRoleNotes.Text;
            set => mmEdtEmployeeRoleNotes.Text = value;
        }

        public bool BtnEmployeeRoleAddEnabled
        {
            get => btnAddEditAddEmployeeRole.Enabled;
            set => btnAddEditAddEmployeeRole.Enabled = value;
        }

        public bool BtnEmployeeRoleDeleteEnabled
        {
            get => btnAddEditDeleteEmployeeRole.Enabled;
            set => btnAddEditDeleteEmployeeRole.Enabled = value;
        }

        public bool BtnEmployeeRoleCancelEnabled
        {
            get => btnAddEditCancelEmployeeRole.Enabled;
            set => btnAddEditCancelEmployeeRole.Enabled = value;
        }

        public bool BtnEmployeeRoleSaveEnabled
        {
            get => btnAddEditSaveEmployeeRole.Enabled;
            set => btnAddEditSaveEmployeeRole.Enabled = value;
        }
        public EmployeeRoleUiModel CreatedEmployeeRole { get; set; }
        public Guid SelectedEmployeeRoleId { get; set; }
        public string SelectedEmployeeRoleName { get; set; }
        public string SelectedEmployeeRoleNotes { get; set; }
        public EmployeeRoleType SelectedEmployeeRoleType { get; set; }
        public EmployeeRoleUiModel SelectedEmployeeRole { get; set; }
        public Guid PreviousSelectedEmployeeRoleId { get; set; }
        public bool EmployeeRoleWasChanged { get; set; }
        public Guid ChangedEmployeeRoleId { get; set; }
        public string ChangedEmployeeRoleName { get; set; }
        public string ChangedEmployeeRoleNotes { get; set; }
        public EmployeeRoleUiModel ChangedEmployeeRole { get; set; }
        public bool NewEmployeeRoleWasAdded { get; set; }
        public EmployeeRoleUiModel FocusedSelectedEmployeeRole { get; set; }
        public EmployeeRoleUiModel ModifiedEmployeeRole { get; set; }
        public EmployeeRoleUiModel DeletedEmployeeRole { get; set; }
        public string OnEmployeeRoleSaveMsgError { get; set; }
        public string OnEmployeeRoleDeleteMsgError { get; set; }

        public bool OnSuccessEmployeeRoleCreation
        {
            set
            {
                if (value)
                {
                    XtraMessageBox.Show("Η δημιουργία ενός νέου ρόλου εργαζομένου ολοκληρώθηκε με επιτυχία",
                        "Δημιουργία Ρόλου Εργαζομένου",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _employeeRolesPresenter.LoadAllEmployeeRoles();
                }
            }
        }

        public bool OnSuccessEmployeeRoleModification
        {
            set
            {
                if (value)
                {
                    XtraMessageBox.Show("Η επεξεργασία ενός νέου ρόλου εργαζομένου ολοκληρώθηκε με επιτυχία",
                        "Επεξεργασία Ρόλου Εργαζομένου",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _employeeRolesPresenter.LoadAllEmployeeRoles();
                }
            }
        }
        public bool OnSuccessEmployeeRoleDeletion { get; set; }
        public string OnEmployeeRoleGeneralMsg { get; set; }

        public bool VerifyForTheEmployeeRoleModification
        {
            set
            {
                if (value)
                {
                    var iResult = XtraMessageBox.Show("Πρόκειται να επεξεργαστείτε μια καταχώρηση Ρόλου Εργαζομένου. Παρακαλώ επιβεβαιώστε!", "Αλλαγή Ρόλου Εργαζομένου",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    ActionAfterVerifyForTheEmployeeRoleModification = iResult == DialogResult.OK;
                }
            }
        }
        public bool ActionAfterVerifyForTheEmployeeRoleModification { get; set; }
        public bool ActionAfterSuccessEmployeeRoleModification { get; set; }
        public bool VerifyForTheEmployeeRoleDeletion { get; set; }
        public bool ActionAfterVerifyForTheEmployeeRoleDeletion { get; set; }

        public bool UcWasLoadedOnDemand
        {
            set
            {
                if (value)
                {
                    _employeeRolesPresenter.LoadAllEmployeeRoles();
                }
            }
        }
        public string OnGeneralMsg { get; set; }

        #endregion

        #region IEmployeeRolesView

        public List<EmployeeRoleUiModel> EmployeeRoles
        {
            get => (List<EmployeeRoleUiModel>)gvEmployeeRoles.DataSource;
            set => gcEmployeeRoles.DataSource = value;
        }
        public bool NoneEmployeeRoleWasRetrieved { get; set; }

        #endregion

        #region Locals

        private void GvEmployeeRolesFocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                SelectedEmployeeRoleId = Guid.Empty;
                SelectedEmployeeRoleName = string.Empty;
            }
            else
            {
                SelectedEmployeeRoleId = (Guid)gvEmployeeRoles.GetRowCellValue(
                    e.FocusedRowHandle, "Id");
                SelectedEmployeeRoleName = (string)gvEmployeeRoles.GetRowCellValue(
                    e.FocusedRowHandle, "Name");
                SelectedEmployeeRoleNotes = (string)gvEmployeeRoles.GetRowCellValue(
                    e.FocusedRowHandle, "Notes");
                SelectedEmployeeRoleType = (EmployeeRoleType)gvEmployeeRoles.GetRowCellValue(
                    e.FocusedRowHandle, "Type");
            }

            _employeeRoleManagementPresenter.EmployeeRoleFromGridWasSelected();
        }

        private void UcClientsEmployeeRolesLoad(object sender, EventArgs e)
        {
            _employeeRoleManagementPresenter.UcLoadedOnDemand();
        }

        private void BtnAddEditAddEmployeeRoleClick(object sender, EventArgs e)
        {
            _employeeRoleManagementPresenter.NewEmployeeRoleBtnWasClicked();
        }

        private void BtnAddEditDeleteEmployeeRoleClick(object sender, EventArgs e)
        {
            _employeeRoleManagementPresenter.RemoveEmployeeRoleBtnWasClicked();
        }

        private void BtnAddEditCancelEmployeeRoleClick(object sender, EventArgs e)
        {
            _employeeRoleManagementPresenter.CancelEmployeeRoleBtnWasClicked();
        }

        private void BtnAddEditSaveEmployeeRoleClick(object sender, EventArgs e)
        {
            _employeeRoleManagementPresenter.SaveEmployeeRoleBtnWasClicked();
        }
        
        private void TxtEvtAddEditVehicleNumPlateEditValueChanged(object sender, EventArgs e)
        {
            _employeeRoleManagementPresenter.EmployeeRoleNameValueWasChanged();
        }
        private void ΜmEdtEditEmployeeRoleNotesChanged(object sender, EventArgs e)
        {
            _employeeRoleManagementPresenter.EmployeeRoleNotesValueWasChanged();
        }

        #endregion

    }
}
