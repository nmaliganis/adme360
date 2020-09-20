using System;
using System.Collections.Generic;
using System.Windows.Forms;
using adme360.models.DTOs.Vehicles;
using adme360.presenter.ViewModel.Vehicles;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Vehicles;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace adme360.suite.ui.Views.Components.EmployeesToursVehicles
{
    public partial class UcClientsVehicles : BaseModule,
        IVehiclesView,
        IVehicleManagementView
    {

        private VehiclesPresenter _vehiclesPresenter;
        private VehicleManagementPresenter _vehicleManagementPresenter;

        public UcClientsVehicles()
        {
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _vehiclesPresenter = new VehiclesPresenter(this);
            _vehicleManagementPresenter = new VehicleManagementPresenter(this);
        }

        private void GvEvtVehiclesFocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                SelectedVehicleId = Guid.Empty;
                SelectedVehicleBrand = string.Empty;
                SelectedVehicleNumPlate = string.Empty;
                SelectedVehicleTypeValue = string.Empty;
                SelectedVehicleStatusValue = string.Empty;
                SelectedVehicleRegisteredDateValue = DateTime.Now;
                SelectedVehicleGasValue = string.Empty;
            }
            else
            {
                SelectedVehicleId = (Guid)gvEvtVehicles.GetRowCellValue(
                    e.FocusedRowHandle, "Id");
                SelectedVehicleBrand = (string)gvEvtVehicles.GetRowCellValue(
                    e.FocusedRowHandle, "VehicleBrand");
                SelectedVehicleNumPlate = (string)gvEvtVehicles.GetRowCellValue(
                    e.FocusedRowHandle, "VehicleNumPlate");
                SelectedVehicleTypeValue = (string)gvEvtVehicles.GetRowCellValue(
                    e.FocusedRowHandle, "VehicleType");
                SelectedVehicleStatusValue = (string)gvEvtVehicles.GetRowCellValue(
                    e.FocusedRowHandle, "VehicleStatus");
                SelectedVehicleRegisteredDateValue = (DateTime)gvEvtVehicles.GetRowCellValue(
                    e.FocusedRowHandle, "VehicleRegisteredDate");
                SelectedVehicleGasValue = (string)gvEvtVehicles.GetRowCellValue(
                    e.FocusedRowHandle, "VehicleGas");
            }

            _vehicleManagementPresenter.VehicleFromGridWasSelected();
        }

        #region IVehicleView Impls

        public string OnGeneralMsg { get; set; }

        public List<VehicleUiModel> Vehicles
        {
            get => (List<VehicleUiModel>)gvEvtVehicles.DataSource;
            set => gcEvtVehicles.DataSource = value;
        }
        public bool NoneVehicleWasRetrieved { get; set; }

        #endregion

        #region IVehicleManagementView Impls

        public bool TxtVehicleBrandEnabled
        {
            get => txtEvtAddEditVehicleBrand.Enabled;
            set => txtEvtAddEditVehicleBrand.Enabled = value;
        }

        public bool TxtVehicleNumPlateEnabled
        {
            get => txtEvtAddEditVehicleNumPlate.Enabled;
            set => txtEvtAddEditVehicleNumPlate.Enabled = value;
        }

        public bool CmbVehicleTypeEnabled
        {
            get => imgCmbEdtEvtAddEditVehicleType.Enabled;
            set => imgCmbEdtEvtAddEditVehicleType.Enabled = value;
        }

        public bool CmbVehicleStatusEnabled
        {
            get => imgCmbEdtEvtAddEditVehicleStatus.Enabled;
            set => imgCmbEdtEvtAddEditVehicleStatus.Enabled = value;
        }

        public bool CmbVehicleGasEnabled
        {
            get => imgCmbEdtEvtAddEditVehicleGastype.Enabled;
            set => imgCmbEdtEvtAddEditVehicleGastype.Enabled = value;
        }
        public int TypeVehicle { get; set; }

        public bool SelectedIndexVehicleOfTypeIsDefault
        {
            set
            {
                if (value)
                    imgCmbEdtEvtAddEditVehicleType.SelectedIndex = 0;
            }
        }
        public int StatusVehicle { get; set; }

        public bool SelectedIndexVehicleOfStatusIsDefault
        {
            set
            {
                if (value)
                    imgCmbEdtEvtAddEditVehicleStatus.SelectedIndex = 0;
            }
        }
        public int GasVehicle { get; set; }

        public bool SelectedIndexVehicleOfGasIsDefault
        {
            set
            {
                if (value)
                    imgCmbEdtEvtAddEditVehicleGastype.SelectedIndex = 0;
            }
        }

        public bool BtnVehicleAddEnabled
        {
            get => btnEvtAddEditVehicleAddVehicle.Enabled;
            set => btnEvtAddEditVehicleAddVehicle.Enabled = value;
        }

        public bool BtnVehicleDeleteEnabled
        {
            get => btnEvtAddEditVehicleDeleteVehicle.Enabled;
            set => btnEvtAddEditVehicleDeleteVehicle.Enabled = value;
        }

        public bool BtnVehicleCancelEnabled
        {
            get => btnEvtAddEditVehicleCancelVehicle.Enabled;
            set => btnEvtAddEditVehicleCancelVehicle.Enabled = value;
        }

        public bool BtnVehicleSaveEnabled
        {
            get => btnEvtAddEditVehicleSaveVehicle.Enabled;
            set => btnEvtAddEditVehicleSaveVehicle.Enabled = value;
        }

        public string TxtVehicleBrand
        {
            get => txtEvtAddEditVehicleBrand.Text;
            set => txtEvtAddEditVehicleBrand.Text = value;
        }

        public string TxtVehicleNumPlate
        {
            get => txtEvtAddEditVehicleNumPlate.Text;
            set => txtEvtAddEditVehicleNumPlate.Text = value;
        }

        public string CmbVehicleTypeValue
        {
            get => (string)((ImageComboBoxItem)imgCmbEdtEvtAddEditVehicleType.SelectedItem).Value;
            set
            {
                if (value != String.Empty)
                {
                    imgCmbEdtEvtAddEditVehicleType.SelectedIndex =
                        PopulateCmbVehicleTypeWithSelectedVehicleType(value);
                }
            }
        }

        private int PopulateCmbVehicleTypeWithSelectedVehicleType(string selectedVehicleType)
        {
            if (imgCmbEdtEvtAddEditVehicleType.Properties.Items == null)
            {
                return -1;
            }
            var vehicleTypes = imgCmbEdtEvtAddEditVehicleType.Properties.Items;
            for (var i = 0; i < vehicleTypes.Count; i++)
            {
                if ((string) vehicleTypes[i].Value == selectedVehicleType)
                {
                    return i;
                }
            }
            return -1;
        }

        public string CmbVehicleStatusValue
        {
            get => (string)((ImageComboBoxItem)imgCmbEdtEvtAddEditVehicleStatus.SelectedItem).Value;
            set
            {
                if (value != String.Empty)
                {
                    imgCmbEdtEvtAddEditVehicleStatus.SelectedIndex =
                        PopulateCmbVehicleTypeWithSelectedVehicleStatus(value);
                }
            }
        }

        private int PopulateCmbVehicleTypeWithSelectedVehicleStatus(string selectedVehicleStatus)
        {
            if (imgCmbEdtEvtAddEditVehicleStatus.Properties.Items == null)
            {
                return -1;
            }
            var vehicleGasTypes = imgCmbEdtEvtAddEditVehicleStatus.Properties.Items;
            for (var i = 0; i < vehicleGasTypes.Count; i++)
            {
                if ((string) vehicleGasTypes[i].Value == selectedVehicleStatus)
                {
                    return i;
                }
            }
            return -1;
        }

        public string CmbVehicleGasValue
        {
            get => (string)((ImageComboBoxItem)imgCmbEdtEvtAddEditVehicleGastype.SelectedItem).Value;
            set
            {
                if (value != String.Empty)
                {
                    imgCmbEdtEvtAddEditVehicleGastype.SelectedIndex =
                        PopulateCmbVehicleTypeWithSelectedVehicleGasType(value);
                }
            }
        }

        private int PopulateCmbVehicleTypeWithSelectedVehicleGasType(string selectedVehicleGasType)
        {
            if (imgCmbEdtEvtAddEditVehicleGastype.Properties.Items == null)
            {
                return -1;
            }
            var vehicleGasTypes = imgCmbEdtEvtAddEditVehicleGastype.Properties.Items;
            for (var i = 0; i < vehicleGasTypes.Count; i++)
            {
                if ((string) vehicleGasTypes[i].Value == selectedVehicleGasType)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool VehicleWasSelected { get; set; }
        public Guid PreviousSelectedVehicleId { get; set; }
        public Guid SelectedVehicleId { get; set; }
        public string SelectedVehicleBrand { get; set; }
        public string SelectedVehicleNumPlate { get; set; }
        public string SelectedVehicleTypeValue { get; set; }
        public string SelectedVehicleStatusValue { get; set; }
        public DateTime SelectedVehicleRegisteredDateValue { get; set; }
        public string SelectedVehicleGasValue { get; set; }
        public VehicleUiModel SelectedVehicle { get; set; }
        public bool VehicleWasChanged { get; set; }
        public Guid ChangedVehicleId { get; set; }
        public string ChangedVehicleBrand { get; set; }
        public string ChangedVehicleNumPlate { get; set; }
        public string ChangedVehicleTypeValue { get; set; }
        public string ChangedVehicleStatusValue { get; set; }
        public string ChangedVehicleGasValue { get; set; }
        public VehicleUiModel ChangedVehicle { get; set; }
        public bool NewVehicleWasAdded { get; set; }
        public VehicleUiModel FocusedSelectedVehicle { get; set; }
        public string OnVehicleSaveMsgError { get; set; }
        public string OnVehicleDeleteMsgError { get; set; }

        public bool OnSuccessVehicleCreation
        {
            set
            {
                if (value)
                {
                    XtraMessageBox.Show("Η δημιουργία ενός νέου απορριμματοφόρου ολοκληρώθηκε με επιτυχία",
                        "Δημιουργία Απορριμματοφόρου",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _vehiclesPresenter.LoadAllVehicles();
                }
            }

        }
        public bool OnSuccessVehicleModification { get; set; }
        public bool OnSuccessVehicleDeletion { get; set; }
        public string OnVehicleGeneralMsg { get; set; }

        public bool VerifyForTheVehicleModification
        {
            set
            {
                if (value)
                {
                    var iResult = XtraMessageBox.Show("Πρόκειται να επεξεργαστείτε μια καταχώρηση απορριμματοφόρου. Παρακαλώ επιβεβαιώστε!", "Αλλαγή Απορριμματοφόρο",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    ActionAfterVerifyForTheVehicleModification = iResult == DialogResult.OK;
                }
            }
        }
        public bool ActionAfterVerifyForTheVehicleModification { get; set; }
        public bool ActionAfterSuccessVehicleModification { get; set; }
        public bool VerifyForTheVehicleDeletion { get; set; }
        public bool ActionAfterVerifyForTheVehicleDeletion { get; set; }

        public bool UcWasLoadedOnDemand
        {
            set
            {
                if (value)
                {
                    _vehiclesPresenter.LoadAllVehicles();
                }
            }
        }

        public VehicleUiModel CreatedVehicle { get; set; }

        #endregion

        private void UcClientsVehiclesLoad(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.UcLoadedOnDemand();
        }

        private void BtnEvtAddEditVehicleAddVehicleClick(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.NewVehicleBtnWasClicked();
        }

        private void BtnEvtAddEditVehicleDeleteVehicleClick(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.RemoveVehicleBtnWasClicked();
        }

        private void BtnEvtAddEditVehicleCancelVehicleClick(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.CancelVehicleBtnWasClicked();
        }

        private void BtnEvtAddEditVehicleSaveVehicleClick(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.SaveVehicleBtnWasClicked();
        }

        private void TxtEvtAddEditVehicleNumPlateEditValueChanged(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.VehicleNumPlateValueWasChanged();
        }

        private void TxtEvtAddEditVehicleBrandEditValueChanged(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.VehicleBrandValueWasChanged();
        }

        private void ImgCmbEdtEvtAddEditVehicleTypeEditValueChanged(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.VehicleTypeValueWasChanged();
        }

        private void ImgCmbEdtEvtAddEditVehicleStatusEditValueChanged(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.VehicleStatusValueWasChanged();
        }

        private void ImgCmbEdtEvtAddEditVehicleGastypeEditValueChanged(object sender, EventArgs e)
        {
            _vehicleManagementPresenter.VehicleGasValueWasChanged();
        }
    }
}
