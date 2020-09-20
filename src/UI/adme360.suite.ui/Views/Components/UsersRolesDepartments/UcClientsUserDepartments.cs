using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using adme360.models.DTOs.Employees.Departments;
using adme360.presenter.ViewModel.Employees.Departments;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Employees.Departments;

namespace adme360.suite.ui.Views.Components.UsersRolesDepartments
{
    public partial class UcClientsEmployeeDepartments : BaseModule,
        IEmployeeDepartmentManagementView,
        IDepartmentsView
    {
        private DepartmentsPresenter _departmentsPresenter;
        private EmployeeDepartmentManagementPresenter _employeeDepartmentManagementPresenter;


        public UcClientsEmployeeDepartments()
        {
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _departmentsPresenter = new DepartmentsPresenter(this);
            _employeeDepartmentManagementPresenter = new EmployeeDepartmentManagementPresenter(this);
        }

        #region Locals
        private void UcClientsEmployeeDepartmentsLoad(object sender, EventArgs e)
        {
            _employeeDepartmentManagementPresenter.UcWasLoaded();
        }

        private void ΒtnAddEditAddEmployeeDepartmentClick(object sender, EventArgs e)
        {
            _employeeDepartmentManagementPresenter.NewEmployeeDepartmentBtnWasClicked();
        }

        private void BtnAddEditDeleteEmployeeDepartmentClick(object sender, EventArgs e)
        {
            _employeeDepartmentManagementPresenter.RemoveEmployeeDepartmentBtnWasClicked();
        }

        private void BtnAddEditCancelEmployeeDepartmentClick(object sender, EventArgs e)
        {
            _employeeDepartmentManagementPresenter.CancelEmployeeDepartmentBtnWasClicked();
        }

        private void BtnAddEditSaveEmployeeDepartmentClick(object sender, EventArgs e)
        {
            _employeeDepartmentManagementPresenter.SaveEmployeeDepartmentBtnWasClicked();
        }

        private void TxtAddEditEmployeeDepartmentDepartmentNameEditValueChanged(object sender, EventArgs e)
        {
            _employeeDepartmentManagementPresenter.EmployeeDepartmentNameValueWasChanged();
        }

        private void GvEmployeeDepartmentsFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                SelectedEmployeeDepartmentId = Guid.Empty;
                SelectedEmployeeDepartmentName = string.Empty;
            }
            else
            {
                SelectedEmployeeDepartmentId = (Guid)gvEmployeeDepartments.GetRowCellValue(
                    e.FocusedRowHandle, "Id");
                SelectedEmployeeDepartmentName = (string)gvEmployeeDepartments.GetRowCellValue(
                    e.FocusedRowHandle, "Name");
            }

            _employeeDepartmentManagementPresenter.EmployeeDepartmentFromGridWasSelected();
        }
        #endregion

        #region IEmployeeDepartmentManagementView

        public bool TxtEmployeeDepartmentNameEnabled
        {
            get => txtAddEditEmployeeDepartmentDepartmentName.Enabled;
            set => txtAddEditEmployeeDepartmentDepartmentName.Enabled = value;
        }

        public string TxtEmployeeDepartmentNameValue
        {
            get => txtAddEditEmployeeDepartmentDepartmentName.Text;
            set => txtAddEditEmployeeDepartmentDepartmentName.Text = value;
        }

        public bool BtnEmployeeDepartmentAddEnabled
        {
            get => btnAddEditAddEmployeeDepartment.Enabled;
            set => btnAddEditAddEmployeeDepartment.Enabled = value;
        }

        public bool BtnEmployeeDepartmentDeleteEnabled
        {
            get => btnAddEditDeleteEmployeeDepartment.Enabled;
            set => btnAddEditDeleteEmployeeDepartment.Enabled = value;
        }

        public bool BtnEmployeeDepartmentCancelEnabled
        {
            get => btnAddEditCancelEmployeeDepartment.Enabled;
            set => btnAddEditCancelEmployeeDepartment.Enabled = value;
        }

        public bool BtnEmployeeDepartmentSaveEnabled
        {
            get => btnAddEditSaveEmployeeDepartment.Enabled;
            set => btnAddEditSaveEmployeeDepartment.Enabled = value;
        }
        public DepartmentUiModel CreatedEmployeeDepartment { get; set; }
        public Guid SelectedEmployeeDepartmentId { get; set; }
        public string SelectedEmployeeDepartmentName { get; set; }
        public DepartmentUiModel SelectedEmployeeDepartment { get; set; }
        public Guid PreviousSelectedEmployeeDepartmentId { get; set; }
        public bool EmployeeDepartmentWasChanged { get; set; }
        public Guid ChangedEmployeeDepartmentId { get; set; }
        public string ChangedEmployeeDepartmentName { get; set; }
        public DepartmentUiModel ChangedEmployeeDepartment { get; set; }
        public bool NewEmployeeDepartmentWasAdded { get; set; }
        public DepartmentUiModel FocusedSelectedEmployeeDepartment { get; set; }
        public DepartmentUiModel ModifiedEmployeeDepartment { get; set; }
        public DepartmentUiModel DeletedEmployeeDepartment { get; set; }
        public string OnEmployeeDepartmentSaveMsgError { get; set; }
        public string OnEmployeeDepartmentDeleteMsgError { get; set; }

        public bool OnSuccessEmployeeDepartmentCreation
        {
            set
            {
                if (value)
                {
                    XtraMessageBox.Show("Η δημιουργία ενός νέου Τμήματος εργαζομένου ολοκληρώθηκε με επιτυχία",
                        "Δημιουργία Τμήματος Εργαζομένου",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _departmentsPresenter.LoadAllDepartments();
                }
            }
        }

        public bool OnSuccessEmployeeDepartmentModification
        {
            set
            {
                if (value)
                {
                    XtraMessageBox.Show("Η επεξεργασία ενός νέου τμήματος εργαζομένου ολοκληρώθηκε με επιτυχία",
                        "Επεξεργασία Τμήματος Εργαζομένου",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _departmentsPresenter.LoadAllDepartments();
                }
            }
        }
        public bool OnSuccessEmployeeDepartmentDeletion { get; set; }
        public string OnEmployeeDepartmentGeneralMsg { get; set; }

        public bool VerifyForTheEmployeeDepartmentModification
        {
            set
            {
                if (value)
                {
                    var iResult = XtraMessageBox.Show("Πρόκειται να επεξεργαστείτε μια καταχώρηση Τμήματος Εργαζομένου. Παρακαλώ επιβεβαιώστε!", "Αλλαγή Τμήματος Εργαζομένου",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    ActionAfterVerifyForTheEmployeeDepartmentModification = iResult == DialogResult.OK;
                }
            }
        }
        public bool ActionAfterVerifyForTheEmployeeDepartmentModification { get; set; }
        public bool ActionAfterSuccessEmployeeDepartmentModification { get; set; }
        public bool VerifyForTheEmployeeDepartmentDeletion { get; set; }
        public bool ActionAfterVerifyForTheEmployeeDepartmentDeletion { get; set; }

        public bool UcWasLoadedOnDemand
        {
            set
            {
                if (value)
                {
                    _departmentsPresenter.LoadAllDepartments();
                }
            }
        }
        public string OnGeneralMsg { get; set; }

        #endregion

        #region IDepartmentsView

        public List<DepartmentUiModel> Departments
        {
            get => (List<DepartmentUiModel>)gvEmployeeDepartments.DataSource;
            set => gcEmployeeDepartments.DataSource = value;
        }
        public bool NoneDepartmentWasRetrieved { get; set; }

        #endregion

    }
}
