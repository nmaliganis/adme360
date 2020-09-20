using System;
using System.Collections.Generic;
using System.Windows.Forms;
using adme360.presenter.ViewModel.Employees.Departments;
using adme360.presenter.ViewModel.Employees.EmployeeRoles;
using adme360.presenter.ViewModel.Users;
using adme360.presenter.ViewModel.Users.Roles;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Employees.Departments;
using adme360.view.Controls.Employees.EmployeeRoles;
using adme360.view.Controls.Users;
using adme360.view.Controls.Users.Roles;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using adme360.models.DTOs.Employees.Departments;
using adme360.models.DTOs.Employees.EmployeeRoles;
using adme360.models.DTOs.Users;
using adme360.models.DTOs.Users.Roles;

namespace adme360.suite.ui.Views.FlyOuts.AddEditUser
{
    public partial class UcFlyUserAddNewEditUserManagement : BaseModule, 
        IUcFlyUserManagementView, IUserRolesView, IEmployeeRolesView, IDepartmentsView
    {
        public FlyoutAddEditUserEventArgs FlyoutAddEditUserEventArgs { get; private set; }

        #region Class Variables

        private UserRolesPresenter _userRolesPresenter;
        private EmployeeRolesPresenter _employeeRolesPresenter;
        private DepartmentsPresenter _departmentsPresenter;
        private UcFlyUserManagementPresenter _flyUserManagementPresenter;

        #endregion

        public UcFlyUserAddNewEditUserManagement(FlyoutAddEditUserEventArgs flyoutAddEditUserEventArgs)
        {
            FlyoutAddEditUserEventArgs = flyoutAddEditUserEventArgs;
            SelectedUserId = flyoutAddEditUserEventArgs.SelectedUserId;
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _userRolesPresenter = new UserRolesPresenter(this);
            _employeeRolesPresenter = new EmployeeRolesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _flyUserManagementPresenter = new UcFlyUserManagementPresenter(this);
        }

        #region IUserRolesView

        public string OnGeneralMsg { get; set; }

        public List<UserRoleUiModel> UserRoles
        {
            get => (List<UserRoleUiModel>) lueAddEditUserRoles.Properties.DataSource;
            set => lueAddEditUserRoles.Properties.DataSource = value;
        }
        public bool NoneUserRoleWasRetrieved { get; set; }

        #endregion

        #region IEmployeeRolesView

        public List<EmployeeRoleUiModel> EmployeeRoles
        {
            get => (List<EmployeeRoleUiModel>) lueAddEditUserEmployeeRole.Properties.DataSource;
            set => lueAddEditUserEmployeeRole.Properties.DataSource = value;
        }
        public bool NoneEmployeeRoleWasRetrieved { get; set; }
        
        #endregion

        #region IDepartmentsView

        public List<DepartmentUiModel> Departments
        {
            get => (List<DepartmentUiModel>) lueAddEditUserEmployeeDepartment.Properties.DataSource;
            set => lueAddEditUserEmployeeDepartment.Properties.DataSource = value;
        }

        public bool NoneDepartmentWasRetrieved
        {
            set
            {
                if (value)
                {

                }
            }
        }

        #endregion

        #region Locals

        private void UcFlyUserAddNewEditUserManagementLoad(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.FlyoutUserManagementWasLoaded();
        }

        private void LueAddEditUserRolesEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.UserRoleWasChanged();
        }

        private void LueAddEditUserEmployeeDepartmentEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.DepartmentWasChanged();
        }

        private void LueAddEditUserEmployeeRoleEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.EmployeeRoleWasChanged();
        }

        private void TxtAddEditUserFirstnameEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.FirstnameWasChanged();
        }

        private void TxtAddEditUserLastnameEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.LastnameWasChanged();
        }

        private void TxtlAddEditUserEmailEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.EmailWasChanged();
        }

        private void TxtlAddEditUserPasswordEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.PasswordWasChanged();
        }

        private void ImgCmbBxAddEditUserGenderEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.GenderWasChanged();
        }

        private void TxtAddEditUserAddreessStreetTwoEnabledChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.AddressStreetTwoWasChanged();
        }

        private void TxtAddEditUserAddreessStreetOneEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.AddressStreetOneWasChanged();
        }

        private void TxtAddEditUserAddreessCityEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.AddressCityWasChanged();
        }

        private void TxtAddEditUserAddreessPostcodeEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.AddressPostcodeWasChanged();
        }

        private void ImgCmbBxEdtAddEditUserMobileExtEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.ExtMobileWasChanged();
        }

        private void TxtAddEditUserMobileEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.MobileWasChanged();
        }

        private void TxtAddEditUserPhoneEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.PhoneWasChanged();
        }

        private void ImgCmbBxEdtAddEditUserPhoneExtEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.ExtPhoneWasChanged();
        }

        private void MmEdtlAddEditUserNotesEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.NotesWasChanged();
        }

        private void TxtAddEditUserAddreessRegionEditValueChanged(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.AddressRegionWasChanged();
        }

        private void BtnAddEditUserSaveClick(object sender, EventArgs e)
        {
            _flyUserManagementPresenter.SaveUserBtnWasClicked();
        }

        private void BtnEvtAddEditEmployeeCancelClick(object sender, EventArgs e)
        {
            (this.Parent as CustomFlyoutDialog).Close();
        }

        #endregion

        #region IUcFlyUserManagementView

        public bool TxtUserFirstNameEnabled
        {
            get => txtAddEditUserFirstname.Enabled;
            set => txtAddEditUserFirstname.Enabled = value;
        }

        public string TxtUserFirstNameValue
        {
            get => txtAddEditUserFirstname.Text;
            set => txtAddEditUserFirstname.Text = value;
        }

        public string SelectedUserEmployeeFirstname { get; set; }
        public string ChangedUserEmployeeFirstname { get; set; }

        public bool TxtUserLastNameEnabled
        {
            get => txtAddEditUserLastname.Enabled;
            set => txtAddEditUserLastname.Enabled = value;
        }

        public string TxtUserLastNameValue
        {
            get => txtAddEditUserLastname.Text;
            set => txtAddEditUserLastname.Text = value;
        }

        public string SelectedUserEmployeeLastname { get; set; }
        public string ChangedUserEmployeeLastname { get; set; }

        public bool TxtUserEmailEnabled
        {
            get => txtlAddEditUserEmail.Enabled;
            set => txtlAddEditUserEmail.Enabled = value;
        }

        public string TxtUserEmailValue
        {
            get => txtlAddEditUserEmail.Text;
            set => txtlAddEditUserEmail.Text = value;
        }

        public string ChangedUserEmployeeEmail { get; set; }

        public bool TxtUserPasswordEnabled
        {
            get => txtlAddEditUserPassword.Enabled;
            set => txtlAddEditUserPassword.Enabled = value;
        }

        public string TxtUserPasswordValue
        {
            get => txtlAddEditUserPassword.Text;
            set => txtlAddEditUserPassword.Text = value;
        }
        public string SelectedUserPassword { get; set; }
        public string ChangedUserPassword { get; set; }

        public bool TxtUserAddressStreetOneEnabled
        {
            get => txtAddEditUserAddreessStreetOne.Enabled;
            set => txtAddEditUserAddreessStreetOne.Enabled = value;
        }

        public string TxtAddressStreetOneValue
        {
            get => txtAddEditUserAddreessStreetOne.Text;
            set => txtAddEditUserAddreessStreetOne.Text = value;
        }

        public string ChangedUserEmployeeAddressStreetOne { get; set; }

        public bool TxtUserAddressStreetTwoEnabled
        {
            get => txtAddEditUserAddreessStreetTwo.Enabled;
            set => txtAddEditUserAddreessStreetTwo.Enabled = value;
        }

        public string TxtAddressStreetTwoValue
        {
            get => txtAddEditUserAddreessStreetTwo.Text;
            set => txtAddEditUserAddreessStreetTwo.Text = value;
        }

        public string ChangedUserEmployeeAddressStreetTwo { get; set; }

        public bool TxtUserAddressPostcodeEnabled
        {
            get => txtAddEditUserAddreessPostcode.Enabled;
            set => txtAddEditUserAddreessPostcode.Enabled = value;
        }

        public string TxtAddressPostcodeValue
        {
            get => txtAddEditUserAddreessPostcode.Text;
            set => txtAddEditUserAddreessPostcode.Text = value;
        }

        public string ChangedUserEmployeeAddressPostcode { get; set; }

        public bool TxtUserAddressCityEnabled
        {
            get => txtAddEditUserAddreessCity.Enabled;
            set => txtAddEditUserAddreessCity.Enabled = value;
        }

        public string TxtAddressCityValue
        {
            get => txtAddEditUserAddreessCity.Text;
            set => txtAddEditUserAddreessCity.Text = value;
        }

        public string ChangedUserEmployeeAddressCity { get; set; }

        public bool TxtUserAddressRegionEnabled
        {
            get => txtAddEditUserAddreessRegion.Enabled;
            set => txtAddEditUserAddreessRegion.Enabled = value;
        }

        public string TxtAddressRegionValue
        {
            get => txtAddEditUserAddreessRegion.Text;
            set => txtAddEditUserAddreessRegion.Text = value;
        }

        public string ChangedUserEmployeeAddressRegion { get; set; }

        public bool TxtUserMobileEnabled
        {
            get => txtAddEditUserMobile.Enabled;
            set => txtAddEditUserMobile.Enabled= value;
        }

        public string TxtMobileValue
        {
            get => txtAddEditUserMobile.Text;
            set => txtAddEditUserMobile.Text = value;
        }

        public string ChangedUserEmployeeMobile { get; set; }

        public bool TxtUserPhoneEnabled
        {
            get => txtAddEditUserPhone.Enabled;
            set => txtAddEditUserPhone.Enabled = value;
        }

        public string TxtPhoneValue
        {
            get => txtAddEditUserPhone.Text;
            set => txtAddEditUserPhone.Text = value;
        }

        public string ChangedUserEmployeePhone { get; set; }

        public bool MmUserNotesEnabled
        {
            get => mmEdtlAddEditUserNotes.Enabled;
            set => mmEdtlAddEditUserNotes.Enabled = value;
        }

        public string MmUserNotesValue
        {
            get => mmEdtlAddEditUserNotes.Text;
            set => mmEdtlAddEditUserNotes.Text = value;
        }

        public string ChangedUserEmployeeNotes { get; set; }

        public bool BtnUserSaveEnabled
        {
            get => btnAddEditUserSave.Enabled;
            set => btnAddEditUserSave.Enabled = value;
        }

        public bool BtnUserCancelEnabled
        {
            get => btnAddEditUserCancel.Enabled;
            set => btnAddEditUserCancel.Enabled = value;
        }

        public bool CmbUserMobileExtEnabled
        {
            get => imgCmbBxEdtAddEditUserMobileExt.Enabled;
            set => imgCmbBxEdtAddEditUserMobileExt.Enabled = value;
        }
        public int UserMobileExt { get; set; }
        public bool SelectedIndexMobileExtOfUserIsDefault { get; set; }

        public string CmbUserMobileExtValue
        {
            get => (string)((ImageComboBoxItem)imgCmbBxEdtAddEditUserMobileExt.SelectedItem).Value;
            set
            {
                if (value != String.Empty)
                {
                    imgCmbBxEdtAddEditUserMobileExt.SelectedIndex =
                        PopulateCmbUserExtMobileWithSelectedExtMobile(value);
                }
            }
        }

        private int PopulateCmbUserExtMobileWithSelectedExtMobile(string selectedExtMobile)
        {
            if (imgCmbBxEdtAddEditUserMobileExt.Properties.Items == null)
            {
                return -1;
            }
            var extMobiles = imgCmbBxEdtAddEditUserMobileExt.Properties.Items;
            for (var i = 0; i < extMobiles.Count; i++)
            {
                if ((string) extMobiles[i].Value == selectedExtMobile)
                {
                    return i;
                }
            }
            return -1;
        }

        public string SelectedUserMobileExtValue { get; set; }
        public string ChangedUserMobileExtValue { get; set; }

        public bool CmbUserPhoneExtEnabled
        {
            get => imgCmbBxEdtAddEditUserPhoneExt.Enabled;
            set => imgCmbBxEdtAddEditUserPhoneExt.Enabled = value;
        }
        public int UserPhoneExt { get; set; }
        public bool SelectedIndexPhoneExtOfUserIsDefault { get; set; }

        public string CmbUserPhoneExtValue
        {
            get => (string)((ImageComboBoxItem)imgCmbBxEdtAddEditUserPhoneExt.SelectedItem).Value;
            set
            {
                if (value != string.Empty)
                    imgCmbBxEdtAddEditUserPhoneExt.SelectedIndex =
                        PopulateCmbEmployeeExtPhoneWithSelectedExtPhone(value);
            }
        }

        private int PopulateCmbEmployeeExtPhoneWithSelectedExtPhone(string selectedExtPhone)
        {
            if (imgCmbBxEdtAddEditUserPhoneExt.Properties.Items == null)
            {
                return -1;
            }
            var extPhones = imgCmbBxEdtAddEditUserPhoneExt.Properties.Items;
            for (var i = 0; i < extPhones.Count; i++)
            {
                if ((string) extPhones[i].Value == selectedExtPhone)
                {
                    return i;
                }
            }
            return -1;
        }

        public string SelectedUserPhoneExtValue { get; set; }
        public string ChangedUserPhoneExtValue { get; set; }

        public bool CmbUserGenderEnabled
        {
            get => imgCmbBxAddEditUserGender.Enabled;
            set => imgCmbBxAddEditUserGender.Enabled = value;
        }
        public int UserGender { get; set; }

        public bool SelectedIndexGenderOfUserIsDefault
        {
            set
            {
                if (value)
                    imgCmbBxAddEditUserGender.SelectedIndex = 0;
            }
        }

        public string CmbUserGenderValue
        {
            get => (string)((ImageComboBoxItem)imgCmbBxAddEditUserGender.SelectedItem).Value;
            set
            {
                if (value != string.Empty)
                    imgCmbBxAddEditUserGender.SelectedIndex =
                        PopulateCmbUserGenderWithSelectedUserGender(value);
            }
        }

        private int PopulateCmbUserGenderWithSelectedUserGender(string selectedUserGender)
        {
            if (imgCmbBxAddEditUserGender.Properties.Items == null)
            {
                return -1;
            }
            var userGenders = imgCmbBxAddEditUserGender.Properties.Items;
            for (var i = 0; i < userGenders.Count; i++)
            {
                if ((string) userGenders[i].Value == selectedUserGender)
                {
                    return i;
                }
            }
            return -1;
        }

        public string SelectedUserGenderValue { get; set; }
        public string ChangedUserGenderValue { get; set; }

        public bool LueUserRoleUserManagementEnabled
        {
            get => lueAddEditUserRoles.Enabled;
            set => lueAddEditUserRoles.Enabled = value;
        }

        public UserRoleUiModel UserRoleUserManagement
        {
            get => (UserRoleUiModel)lueAddEditUserRoles.EditValue;
            set
            {
                lueAddEditUserRoles.EditValue = value;
                lueAddEditUserRoles.ItemIndex = PopulateLueUserRolesWithSelectedUserRole(value);
            }
        }

        private int PopulateLueUserRolesWithSelectedUserRole(UserRoleUiModel focusedUserRole)
        {
            if (lueAddEditUserRoles.Properties.DataSource == null)
            {
                return -1;
            }
            var userRolesUiModels = (List<UserRoleUiModel>)lueAddEditUserRoles.Properties.DataSource;
            for (var i = 0; i < userRolesUiModels.Count; i++)
            {
                if (userRolesUiModels[i].Id == focusedUserRole.Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool SelectedIndexUserRoleOfUserManagementIsDefault
        {
            set
            {
                if (value)
                    lueAddEditUserRoles.EditValue = null;
            }
        }

        public bool SelectedIndexUserRoleOfUserManagementIsFirstIndex
        {
            set
            {
                if (value)
                    lueAddEditUserRoles.ItemIndex = 0;
            }
        }

        public bool SelectedIndexUserRoleOfUserManagementIsCustom
        {
            set
            {
                if (value)
                    lueAddEditUserRoles.ItemIndex =
                        PopulateLueUserRoleWithSelectedUserRole(
                            SelectedUserRoleUserManagementId);
            }
        }

        private int PopulateLueUserRoleWithSelectedUserRole(Guid focusedUserRole)
        {
            if (lueAddEditUserRoles.Properties.DataSource == null)
            {
                return -1;
            }
            var userRoleUiModels = (List<UserRoleUiModel>)lueAddEditUserRoles.Properties.DataSource;
            for (var i = 0; i < userRoleUiModels.Count; i++)
            {
                if (userRoleUiModels[i].Id == focusedUserRole)
                {
                    return i;
                }
            }
            return -1;
        }

        public Guid SelectedUserRoleUserManagementId { get; set; }
        public Guid PreviousSelectedUserRoleUserManagementId { get; set; }
        public Guid ChangedUserRoleUserManagementId { get; set; }

        public bool LueDepartmentUserManagementEnabled
        {
            get => lueAddEditUserEmployeeDepartment.Enabled;
            set => lueAddEditUserEmployeeDepartment.Enabled = value;
        }

        public DepartmentUiModel DepartmentUserManagement
        {
            get => (DepartmentUiModel)lueAddEditUserEmployeeDepartment.EditValue;
            set
            {
                lueAddEditUserEmployeeDepartment.EditValue = value;
                lueAddEditUserEmployeeDepartment.ItemIndex = PopulateLueDepartmentsWithSelectedDepartment(value);
            }
        }

        private int PopulateLueDepartmentsWithSelectedDepartment(DepartmentUiModel focusedDepartment)
        {
            if (lueAddEditUserEmployeeDepartment.Properties.DataSource == null)
            {
                return -1;
            }
            var departmentsUiModels = (List<DepartmentUiModel>)lueAddEditUserEmployeeDepartment.Properties.DataSource;
            for (var i = 0; i < departmentsUiModels.Count; i++)
            {
                if (departmentsUiModels[i].Id == focusedDepartment.Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool SelectedIndexDepartmentOfUserManagementIsDefault
        {
            set
            {
                if (value)
                    lueAddEditUserEmployeeDepartment.EditValue = null;
            }
        }

        public bool SelectedIndexDepartmentOfUserManagementIsFirstIndex
        {
            set
            {
                if (value)
                    lueAddEditUserEmployeeDepartment.ItemIndex = 0;
            }
        }

        public bool SelectedIndexDepartmentOfUserManagementIsCustom
        {
            set
            {
                if (value)
                    lueAddEditUserEmployeeDepartment.ItemIndex =
                        PopulateLueDepartmentWithSelectedDepartment(
                            SelectedDepartmentUserManagementId);
            }
        }

        private int PopulateLueDepartmentWithSelectedDepartment(Guid focusedDepartmentId)
        {
            if (lueAddEditUserEmployeeDepartment.Properties.DataSource == null)
            {
                return -1;
            }
            var departmentUiModels = (List<DepartmentUiModel>)lueAddEditUserEmployeeDepartment.Properties.DataSource;
            for (var i = 0; i < departmentUiModels.Count; i++)
            {
                if (departmentUiModels[i].Id == focusedDepartmentId)
                {
                    return i;
                }
            }
            return -1;
        }

        public Guid SelectedDepartmentUserManagementId { get; set; }
        public Guid PreviousSelectedDepartmentUserManagementId { get; set; }
        public Guid ChangedDepartmentUserManagementId { get; set; }


        public bool LueEmployeeRoleUserManagementEnabled
        {
            get => lueAddEditUserEmployeeRole.Enabled;
            set => lueAddEditUserEmployeeRole.Enabled = value;
        }

        public EmployeeRoleUiModel EmployeeRoleUserManagement
        {
            get => (EmployeeRoleUiModel)lueAddEditUserEmployeeRole.EditValue;
            set
            {
                lueAddEditUserEmployeeRole.EditValue = value;
                lueAddEditUserEmployeeRole.ItemIndex = PopulateLueEmployeeRolesWithSelectedEmployeeRole(value);
            }
        }

        private int PopulateLueEmployeeRolesWithSelectedEmployeeRole(EmployeeRoleUiModel focusedEmployeeRole)
        {
            if (lueAddEditUserEmployeeRole.Properties.DataSource == null)
            {
                return -1;
            }
            var employeeRolesUiModels = (List<DepartmentUiModel>)lueAddEditUserEmployeeRole.Properties.DataSource;
            for (var i = 0; i < employeeRolesUiModels.Count; i++)
            {
                if (employeeRolesUiModels[i].Id == focusedEmployeeRole.Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool SelectedIndexEmployeeRoleOfUserManagementIsDefault
        {
            set
            {
                if (value)
                    lueAddEditUserEmployeeRole.EditValue = null;
            }
        }

        public bool SelectedIndexEmployeeRoleOfUserManagementIsFirstIndex
        {
            set
            {
                if (value)
                    lueAddEditUserEmployeeRole.ItemIndex = 0;
            }
        }

        public bool SelectedIndexEmployeeRoleOfUserManagementIsCustom
        {
            set
            {
                if (value)
                    lueAddEditUserEmployeeRole.ItemIndex =
                        PopulateLueEmployeeRoleWithSelectedEmployeeRole(
                            SelectedEmployeeRoleUserManagementId);
            }
        }

        private int PopulateLueEmployeeRoleWithSelectedEmployeeRole(Guid focusedEmployeeRole)
        {
            if (lueAddEditUserEmployeeRole.Properties.DataSource == null)
            {
                return -1;
            }
            var employeeRoleUiModels = (List<EmployeeRoleUiModel>)lueAddEditUserEmployeeRole.Properties.DataSource;
            for (var i = 0; i < employeeRoleUiModels.Count; i++)
            {
                if (employeeRoleUiModels[i].Id == focusedEmployeeRole)
                {
                    return i;
                }
            }
            return -1;
        }

        public Guid SelectedEmployeeRoleUserManagementId { get; set; }
        public Guid PreviousSelectedEmployeeRoleUserManagementId { get; set; }
        public Guid ChangedEmployeeRoleUserManagementId { get; set; }
        public UserUiModel ModifiedUser { get; set; }
        public AccountUiModel ChangedUser { get; set; }
        public Guid SelectedUserId { get; set; }
        public UserUiModel CreatedUser { get; set; }

        public bool OnSuccessUserCreation
        {
            set
            {
                if (value)
                {
                    var iResult = XtraMessageBox.Show("Η δημιουργία ενός νέου χρήστη ολοκληρώθηκε με επιτυχία",
                        "Δημιουργία Χρήστη",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    ActionAfterVerifyForTheUserCreation = iResult == DialogResult.OK;
                    _flyUserManagementPresenter.ActionAfterVerifyForTheUserCreation();
                }
            }
        }

        public bool ActionAfterVerifyForTheUserCreation { get; set; }
        public bool VerifyForTheUserModification { get; set; }
        public bool ActionAfterVerifyForTheUserModification { get; set; }

        public bool OnDemandLoadFlyoutUserManagement
        {
            set
            {
                if (value)
                {
                    _departmentsPresenter.LoadAllDepartments();
                    _userRolesPresenter.LoadAllUserRoles();
                    _employeeRolesPresenter.LoadAllEmployeeRoles();
                }
            }
        }

        public string OnUserSaveMsgError
        {
            set =>
                XtraMessageBox.Show(value,
                    "Λάθος εκτέλεση",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public string SelectedUserEmployeeEmail { get; set; }
        public string SelectedUserEmployeeNotes { get; set; }
        public string SelectedUserEmployeeAddressStreetOne { get; set; }
        public string SelectedUserEmployeeAddressStreetTwo { get; set; }
        public string SelectedUserEmployeeAddressCity { get; set; }
        public string SelectedUserEmployeeAddressPostcode { get; set; }
        public string SelectedUserEmployeeAddressRegion { get; set; }
        public string SelectedUserEmployeePhone { get; set; }
        public string SelectedUserEmployeeMobile { get; set; }
        public string SelectedUserRoleValue { get; set; }
        public string SelectedUserEmployeeDepartmentValue { get; set; }
        public string SelectedUserEmployeeRoleValue { get; set; }
        public string SelectedUserEmployeeGenderValue { get; set; }
        public string SelectedUserEmployeeStatusValue { get; set; }
        public bool OnSuccessUserModification { get; set; }

        #endregion

    }
}
