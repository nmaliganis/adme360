using System;
using System.Collections.Generic;
using adme360.models.DTOs.Employees;
using adme360.models.DTOs.Employees.Departments;
using adme360.models.DTOs.Employees.EmployeeRoles;
using adme360.presenter.ViewModel.Employees;
using adme360.presenter.ViewModel.Employees.Departments;
using adme360.presenter.ViewModel.Employees.EmployeeRoles;
using adme360.presenter.ViewModel.Etvs;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Employees;
using adme360.view.Controls.Employees.Departments;
using adme360.view.Controls.Employees.EmployeeRoles;
using adme360.view.Controls.Evts;

namespace adme360.suite.ui.Views.Components.EmployeesToursVehicles
{
    public partial class UcClientsEmployees : BaseModule, IUcEvtEmployeeManagementView, 
        IEmployeesView, 
        IDepartmentsView, 
        IEmployeeRolesView
    {

        private UcEvtEmployeeManagementPresenter _ucEvtEmployeeManagementPresenter;
        private EmployeesPresenter _employeesPresenter;
        private DepartmentsPresenter _departmentsPresenter;
        private EmployeeRolesPresenter _employeeRolesPresenter;
        public UcClientsEmployees()
        {
            InitializeComponent();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            _ucEvtEmployeeManagementPresenter = new UcEvtEmployeeManagementPresenter(this);
            _employeesPresenter = new EmployeesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _employeeRolesPresenter = new EmployeeRolesPresenter(this);
        }

        private void BtnEvtAddEmployeeClick(object sender, System.EventArgs e)
        {
            _ucEvtEmployeeManagementPresenter.OpenFlyoutForAddEmployeeWasClicked();
        }

        #region IUcEvtEmployeeManagementView

        public bool OpenFlyoutForAddEmployee
        {
            set
            {
                if (value)
                {
                    FlyoutAddEmployeeEventArgs args =
                        new FlyoutAddEmployeeEventArgs( "OnEvtAddNewEmployee");
                    this.OnEvtAddNewEmployeeRequested(args);
                    if (args.IsAccepted)
                    {
                        MySaveMethod();
                    }
                }
            }
        }

        public bool OnEmployeeManagementLoaded
        {
            set
            {
                if (value)
                {
                    _employeesPresenter.LoadAllActiveEmployees();
                    _departmentsPresenter.LoadAllDepartments();
                    _employeeRolesPresenter.LoadAllEmployeeRoles();
                }
            }
        }

        public bool BtnEmployeeManagementAddEmployee
        {
            get => btnEvtAddEmployee.Enabled;
            set => btnEvtAddEmployee.Enabled = value;
        }

        public bool BtnEmployeeManagementEditEmployee
        {
            get => btnEvtEditEmployee.Enabled;
            set => btnEvtEditEmployee.Enabled = value;
        }

        public bool BtnEmployeeManagementDeleteEmployee
        {
            get => btnEvtRemoveEmployee.Enabled;
            set => btnEvtRemoveEmployee.Enabled = value;
        }

        private void MySaveMethod()
        {
        }

        #endregion

        #region IEmployeesView

        public string OnGeneralMsg { get; set; }

        public List<EmployeeUiModel> Employees
        {
            get => (List<EmployeeUiModel>) gvAdvBndEvtEmployees.DataSource;
            set
            {
                gcAdvBndEvtEmployees.DataSource = value;
                gcAdvBndEvtEmployees.ForceInitialize();;
            } 
        }
        public bool NoneEmployeeWasRetrieved { get; set; }
        public string OnEmployeesMsgError { get; set; }

        #endregion

        #region Locals

        private void UcClientsEmployeesLoad(object sender, EventArgs e)
        {
            _ucEvtEmployeeManagementPresenter.UcWasLoaded();
        }

        #endregion

        #region IDepartmentsView

        public List<DepartmentUiModel> Departments
        {
            get => (List<DepartmentUiModel>) repoItmLueEmployeeDepartment.DataSource;
            set => repoItmLueEmployeeDepartment.DataSource = value;
        }

        public bool NoneDepartmentWasRetrieved
        {
            set
            {
                if (value)
                {
                    //Todo: 
                }
            }
        }

        #endregion

        #region IEmployeeRolesView

        public List<EmployeeRoleUiModel> EmployeeRoles
        {
            get => (List<EmployeeRoleUiModel>) repoItmLueEmployeeRoles.DataSource;
            set
            {
                repoItmLueEmployeeRoles.DataSource = value;
                repoItmLueEmployeeRoles.ForceInitialize();
                repoItmLueEmployeeRoles.PopulateColumns();
            } 
        }

        public bool NoneEmployeeRoleWasRetrieved
        {
            set
            {
                if (value)
                {
                    //Todo: 
                }
            }
        }

        #endregion
    }
}
