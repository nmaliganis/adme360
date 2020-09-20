using DevExpress.XtraEditors.Controls;
using DevExpress.XtraMap;
using adme360.models.DTOs.Maps;
using adme360.presenter.ViewModel.Containers;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Containers.AddEditFlyoutContainer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Map;
using DevExpress.XtraEditors;
using adme360.models.DTOs.Containers;
using adme360.presenter.ViewModel.Maps;
using adme360.view.Controls.Containers;
using adme360.view.Controls.Maps;

namespace adme360.suite.ui.Views.FlyOuts.AddEditContainer
{
    public partial class UcFlyContainerAddNewEditContainerManagement : BaseModule, IUcFlyContainerManagementView,  IMapView, IContainerImageView
    {
        public FlyoutAddEditContainerEventArgs EventArgs { get; }
        private MapPresenter _mapPresenter;
        private UcFlyContainerManagementPresenter _ucFlyContainerManagementPresenter;
        private ContainerImagePresenter _containerImagePresenter;

        public UcFlyContainerAddNewEditContainerManagement(FlyoutAddEditContainerEventArgs flyoutAddEditEditContainerEventArgs)
        {
            EventArgs = flyoutAddEditEditContainerEventArgs;
            if (EventArgs.SelectedContainerId != Guid.Empty)
            {
                IsAddMode = false;
                SelectedContainerId = EventArgs.SelectedContainerId;
            }
            else
            {
                IsAddMode = true;
            }

            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _ucFlyContainerManagementPresenter = new UcFlyContainerManagementPresenter(this);
            _mapPresenter = new MapPresenter(this);
            _containerImagePresenter = new ContainerImagePresenter(this);
        }

        #region Locals
        private void OpenFileDialogPhotoContainerFileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraOpenFileDialog fileDialog = sender as XtraOpenFileDialog;

            if (fileDialog == null)
                return;

            PctContainerImagePath = fileDialog.FileName;
            PctContainerImagePathName = fileDialog.SafeFileName;
            PctContainerImageValue = Image.FromFile(PctContainerImagePath);
            _ucFlyContainerManagementPresenter.ImageWasSelected();
        }
        private void ImgCmbBxEdtContainerFillLevelEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.FillLevelValueChanged();
        }

        private void ImgCmbBxEdtContainerTypeEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.TypeValueChanged();
        }

        private void ImgCmbBxEdtContainerStatusEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.StatusValueChanged();
        }

        private void ChckEdtContainerMandatoryPickupCheckedChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.MandatoryPickupValueChanged();
        }

        private void ImgCmbBxEdtContainerMandatoryTypeCollectionEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.MandatoryTypePickupValueChanged();
        }

        private void MpCntrlAddEditContainerMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ChangedMapContainer = new Geometry
            {
                type = "Point",
                coordinates = new List<List<double>>()
                {
                    new List<double>() {((MouseEventArgs) e).X, ((MouseEventArgs) e).Y}
                }
            };

            _ucFlyContainerManagementPresenter.MapWasClicked();
        }


        private void BtnAddEditContainerSaveClick(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.SaveContainerBtnWasClicked();
        }

        private void BtnAddEditContainerCancelClick(object sender, EventArgs e)
        {
            (this.Parent as CustomFlyoutDialog).Close();
        }

        private void TgglSwtchEditMapPointContainerClick(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.MapPointToggleWasChanged();
        }

        private void DtEdtContainerMandatoryPickupDateEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.MandatoryDateTimeWasChanged();
        }

        private void TrckBrCntrlLevelContainerEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.LevelValueChanged();
        }

        private void ChckEdtContainerMandatoryPickupEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.MandatoryPickupValueChanged();
        }

        private void TxtAddEditContainerNameEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.ContainerNameWasChanged();
        }

        private void PctrEdtContainerPhotoDoubleClick(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.ContainerPhotoWasDoubleClicked();
        }

        private void UcFlyContainerAddNewEditContainerManagementLoad(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.FlyoutContainerManagementWasLoaded();
        }

        private void OpenMapPopulate()
        {
            mpCntrlAddEditContainer.CenterPoint = new GeoPoint(40.6562959, 22.9092506);

            // Create a layer. 
            ImageLayer layerOpen = new ImageLayer();

            mpCntrlAddEditContainer.Layers.Add(layerOpen);

            // Create a data provider. 
            OpenStreetMapDataProvider providerOpen = new OpenStreetMapDataProvider
            {
                Kind = OpenStreetMapKind.Hot
            };
            layerOpen.DataProvider = providerOpen;
            providerOpen.CacheOptions.DiskFolder = "C://MapTiles"; 
            providerOpen.CacheOptions.DiskExpireTime = new TimeSpan(01,00,00);
            providerOpen.CacheOptions.MemoryLimit = 64;           
            providerOpen.CacheOptions.DiskLimit = 200;
        }

        private void SpnContainerCapacityEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.CapacityValueChanged();
        }

        private void MmEditContainerDescriptionEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.DescriptionValueChanged();
        }

        private void SpnContainerLoadEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.LoadValueChanged();
        }

        private void ImgCmbBxEdtContainerMaterialEditValueChanged(object sender, EventArgs e)
        {
            _ucFlyContainerManagementPresenter.MaterialValueChanged();
        }

        #endregion

        #region IUcFlyContainerManagementView

        public bool IsAddMode { get; set; }

        public bool TxtContainerLoadEnabled
        {
            get => cmbContainerLoad.Enabled;
            set => cmbContainerLoad.Enabled = value;
        }

        public int TxtContainerLoadValue
        {
            get => Int32.Parse((string)cmbContainerLoad.EditValue);
            set => cmbContainerLoad.EditValue = value;
        }
        public int SelectedContainerLoad { get; set; }

        public bool SelectedIndexLoadOfContainerIsDefault
        {
            set
            {
                if (value)
                    cmbContainerLoad.SelectedIndex = 1;
            }
        }
        public int ChangedContainerLoad { get; set; }

        public bool TxtContainerCapacityEnabled
        {
            get => cmbContainerCapacity.Enabled;
            set => cmbContainerCapacity.Enabled = value;
        }

        public int TxtContainerCapacityValue
        {
            get => Int32.Parse((string)cmbContainerCapacity.EditValue);
            set => cmbContainerCapacity.EditValue = value;
        }
        public int SelectedContainerCapacity { get; set; }

        public bool SelectedIndexCapacityOfContainerIsDefault
        {
            set
            {
                if (value)
                    cmbContainerCapacity.SelectedIndex = 1;
            }
        }
        public int ChangedContainerCapacity { get; set; }

        public bool TxtContainerDescriptionEnabled
        {
            get => mmEditContainerDescription.Enabled;
            set => mmEditContainerDescription.Enabled = value;
        }

        public string TxtContainerDescriptionValue
        {
            get => (string)mmEditContainerDescription.EditValue;
            set => mmEditContainerDescription.EditValue = value;
        }
        public string SelectedContainerDescription { get; set; }
        public string ChangedContainerDescription { get; set; }

        public bool TxtContainerNameEnabled
        {
            get => txtAddEditContainerName.Enabled;
            set => txtAddEditContainerName.Enabled = value;
        }

        public string TxtContainerNameValue
        {
            get => txtAddEditContainerName.Text;
            set => txtAddEditContainerName.Text = value;
        }

        public string SelectedContainerName
        {
            get; set;
        }
        public string ChangedContainerName { get; set; }

        public bool TxtContainerAddressEnabled
        {
            get => txtAddEditContainerAddress.Enabled;
            set => txtAddEditContainerAddress.Enabled = value;
        }

        public double PointLatValue { get; set; }
        public double PointLonValue { get; set; }

        public string TxtContainerAddressValue
        {
            get => txtAddEditContainerAddress.Text;
            set => txtAddEditContainerAddress.Text = value;
        }
        public string SelectedContainerAddress { get; set; }
        public string ChangedContainerAddress { get; set; }

        public bool PctContainerImageEnabled
        {
            get => pctrEdtContainerPhoto.Enabled;
            set => pctrEdtContainerPhoto.Enabled = value;

        }

        public bool PctContainerImageClear
        {
            set
            {
                if (value)
                {
                    pctrEdtContainerPhoto.Image = null;
                }
            }
        }

        public Image PctContainerImageValue
        {
            get => (Image)pctrEdtContainerPhoto.Image;
            set => pctrEdtContainerPhoto.Image = value;
        }


        public bool OnLoadAsyncImage
        {
            set
            {
                if (value)
                {
                    SelectedContainerImageNameImageView = PctContainerImagePath;
                    _containerImagePresenter.ContainerImagePopulate();
                }
            }
        }
        public string PctContainerImagePath { get; set; }
        public string PctContainerImageServerPath { get; set; }
        public string PctContainerImagePathName { get; set; }
        public string SelectedContainerImage { get; set; }
        public string ChangedContainerImage { get; set; }

        public bool BarContainerLevelEnabled
        {
            get => trckBrCntrlLevelContainer.Enabled;
            set => trckBrCntrlLevelContainer.Enabled = value;
        }

        public int BarContainerLevelValue
        {
            get => (int)trckBrCntrlLevelContainer.EditValue;
            set => trckBrCntrlLevelContainer.EditValue = value;
        }
        public int SelectedContainerLevel { get; set; }
        public int ChangedContainerLevel { get; set; }

        public bool MapContainerEnabled
        {
            get => mpCntrlAddEditContainer.Enabled;
            set => trckBrCntrlLevelContainer.Enabled = value;
        }
        public Geometry MapContainerValue { get; set; }
        public Geometry SelectedMapContainer { get; set; }
        public Geometry ChangedMapContainer { get; set; }

        public bool OnCheckMapAddNewPoint
        {
            set
            {
                if (value)
                {
                    PopulateNewPointForContainerIntoMap();
                    _mapPresenter.PopulateAddressWithSelectedMapPoint();
                    TxtContainerAddressValue = PointAddress;
                }
            }
        }

        public bool OnMapEditPoint
        {
            set
            {
                if (value)
                {
                    PopulatePointForContainer(PointLatValue, PointLonValue);
                }
            }
        }

        private void PopulateNewPointForContainerIntoMap()
        {
            VectorItemsLayer vectorLayerPointContainer = mpCntrlAddEditContainer.Layers[0] as VectorItemsLayer;

            ClearMapPoints(vectorLayerPointContainer);

            var containerPoint = ChangedMapContainer.coordinates.First(x => x.Count > 0);
            if (containerPoint.Count != 2)
                return;

            CoordPoint p = mpCntrlAddEditContainer.ScreenPointToCoordPoint(new MapPoint(containerPoint[0], containerPoint[1]));

            GeoPoint Gp = new GeoPoint()
            {
                Latitude = p.GetY(),
                Longitude = p.GetX(),
            };

            containerPoint.Add(p.GetY());
            containerPoint.Add(p.GetX());

            PointLat = PointLatValue = p.GetY();
            PointLon = PointLonValue = p.GetX();

            MapPushpin pin = new MapPushpin
            {
                Location = Gp
            };

            ((MapItemStorage)vectorLayerPointContainer.Data).Items.Add(pin);
        }
        private void PopulatePointForContainer(double lat, double lon)
        {
            VectorItemsLayer vectorLayerPointContainer = mpCntrlAddEditContainer.Layers[0] as VectorItemsLayer;

            GeoPoint Gp = new GeoPoint()
            {
                Latitude = lat,
                Longitude = lon,
            };

            MapPushpin pin = new MapPushpin
            {
                Location = Gp
            };

            ((MapItemStorage)vectorLayerPointContainer.Data).Items.Add(pin);
        }

        private static void ClearMapPoints(VectorItemsLayer vectorLayerPointContainer)
        {
            ((MapItemStorage) vectorLayerPointContainer.Data).Items.Clear();
        }

        public bool TgglContainerPointEnabled
        {
            get => tgglSwtchEditMapPointContainer.Enabled;
            set => tgglSwtchEditMapPointContainer.Enabled = value;
        }

        public bool TgglContainerPointValue
        {
            get => (bool)tgglSwtchEditMapPointContainer.EditValue;
            set => tgglSwtchEditMapPointContainer.EditValue = value;
        }
        public bool SelectedPointToggleContainer { get; set; }
        public bool ChangedPointToggleContainer { get; set; }

        public bool ChckContainerMandatoryEnabled
        {
            get => (bool)chckEdtContainerMandatoryPickup.Enabled;
            set => chckEdtContainerMandatoryPickup.Enabled = value;
        }

        public bool ChckContainerMandatoryValue
        {
            get => (bool)chckEdtContainerMandatoryPickup.EditValue;
            set => chckEdtContainerMandatoryPickup.EditValue = value;
        }
        public bool SelectedContainerMandatory { get; set; }
        public bool ChangedContainerMandatory { get; set; }

        public bool DtContainerMandatoryDateTimeEnabled
        {
            get => dtEdtContainerMandatoryPickupDate.Enabled;
            set => dtEdtContainerMandatoryPickupDate.Enabled = value;
        }

        public DateTime DtContainerMandatoryDateTimeValue
        {
            get => (DateTime)dtEdtContainerMandatoryPickupDate.EditValue;
            set => dtEdtContainerMandatoryPickupDate.EditValue = value;
        }

        public DateTime SelectedContainerMandatoryDateTime
        {
            get => (DateTime)dtEdtContainerMandatoryPickupDate.EditValue;
            set => dtEdtContainerMandatoryPickupDate.EditValue = value;
        }
        public DateTime ChangedContainerMandatoryDateTime { get; set; }

        public bool CmbContainerMandatoryOptionEnabled
        {
            get => (bool)imgCmbBxEdtContainerMandatoryTypeCollection.Enabled;
            set => imgCmbBxEdtContainerMandatoryTypeCollection.Enabled = value;
        }
        public int ContainerMandatoryOption { get; set; }

        public bool SelectedIndexMandatoryOptionOfContainerIsDefault
        {
            set
            {
                if (value)
                    imgCmbBxEdtContainerMandatoryTypeCollection.SelectedIndex = 0;
            }
        }

        public bool SelectedIndexMandatoryOptionOfContainerIsFirstIndex{ set{}}
        public bool SelectedIndexMandatoryOptionOfContainerIsCustom { set{} }

        public string CmbContainerMandatoryOptionValue
        {
            get => (string)((ImageComboBoxItem)imgCmbBxEdtContainerMandatoryTypeCollection.SelectedItem).Value;
            set
            {
                if (value != string.Empty)
                    imgCmbBxEdtContainerMandatoryTypeCollection.SelectedIndex =
                        PopulateCmbUMandatoryTypeWithSelectedMandatoryType(value);
            }
        }

        private int PopulateCmbUMandatoryTypeWithSelectedMandatoryType(string selectedMandatoryOption)
        {
            if (imgCmbBxEdtContainerMandatoryTypeCollection.Properties.Items == null)
            {
                return -1;
            }
            var mandatoryOptions = imgCmbBxEdtContainerMandatoryTypeCollection.Properties.Items;
            for (var i = 0; i < mandatoryOptions.Count; i++)
            {
                if ((string) mandatoryOptions[i].Value == selectedMandatoryOption)
                {
                    return i;
                }
            }
            return -1;
        }

        public string SelectedContainerMandatoryOptionValue { get; set; }
        public string ChangedContainerMandatoryOptionValue { get; set; }

        public bool CmbContainerFillLevelEnabled
        {
            get => (bool)imgCmbBxEdtContainerFillLevel.Enabled;
            set => imgCmbBxEdtContainerFillLevel.Enabled = value;
        }
        public int ContainerFillLevel { get; set; }

        public bool SelectedIndexFillLevelOfContainerIsDefault
        {
            set
            {
                if (value)
                    imgCmbBxEdtContainerFillLevel.SelectedIndex = 0;
            }
        }
        public bool SelectedIndexFillLevelOfContainerIsFirstIndex { get; set; }
        public bool SelectedIndexFillLevelOfContainerIsCustom { get; set; }

        public string CmbContainerFillLevelValue
        {
            get => (string)((ImageComboBoxItem)imgCmbBxEdtContainerFillLevel.SelectedItem).Value;
            set
            {
                if (value != String.Empty)
                {
                    imgCmbBxEdtContainerFillLevel.SelectedIndex =
                        PopulateCmbContainerFillLevelWithSelectedFillLevel(value);
                }
            }
        }

        private int PopulateCmbContainerFillLevelWithSelectedFillLevel(string selectedFillLevel)
        {
            if (imgCmbBxEdtContainerFillLevel.Properties.Items == null)
            {
                return -1;
            }
            var fillLevels = imgCmbBxEdtContainerFillLevel.Properties.Items;
            for (var i = 0; i < fillLevels.Count; i++)
            {
                if ((string)fillLevels[i].Value == selectedFillLevel)
                {
                    return i;
                }
            }
            return -1;
        }

        public string SelectedContainerFillLevelValue { get; set; }
        public string ChangedContainerFillLevelValue { get; set; }

        public bool CmbContainerMaterialEnabled
        {
            get => imgCmbBxEdtContainerMaterial.Enabled;
            set => imgCmbBxEdtContainerMaterial.Enabled = value;
        }
        public int ContainerMaterial { get; set; }

        public bool SelectedIndexMaterialOfContainerIsDefault
        {
            set
            {
                if (value)
                    imgCmbBxEdtContainerMaterial.SelectedIndex = 0;
            }
        }
        public bool SelectedIndexMaterialOfContainerIsFirstIndex { get; set; }
        public bool SelectedIndexMaterialOfContainerIsCustom { get; set; }

        public string CmbContainerMaterialValue
        {
            get => (string)((ImageComboBoxItem)imgCmbBxEdtContainerMaterial.SelectedItem).Value;
            set
            {
                if (value != string.Empty)
                    imgCmbBxEdtContainerMaterial.SelectedIndex =
                        PopulateCmbContainerMaterialWithSelectedContainerMaterial(value);
            }
        }

        private int PopulateCmbContainerMaterialWithSelectedContainerMaterial(string selectedContainerMaterial)
        {
            if (imgCmbBxEdtContainerMaterial.Properties.Items == null)
            {
                return -1;
            }
            var containerMaterials = imgCmbBxEdtContainerMaterial.Properties.Items;
            for (var i = 0; i < containerMaterials.Count; i++)
            {
                if ((string)containerMaterials[i].Value == selectedContainerMaterial)
                {
                    return i;
                }
            }
            return -1;
        }

        public string SelectedContainerMaterialValue { get; set; }
        public string ChangedContainerMaterialValue { get; set; }


        public bool CmbContainerTypeEnabled
        {
            get => imgCmbBxEdtContainerType.Enabled;
            set => imgCmbBxEdtContainerType.Enabled = value;
        }
        public int ContainerType { get; set; }

        public bool SelectedIndexTypeOfContainerIsDefault
        {
            set
            {
                if (value)
                    imgCmbBxEdtContainerType.SelectedIndex = 0;
            }
        }

        public bool SelectedIndexTypeOfContainerIsFirstIndex { get; set; }
        public bool SelectedIndexTypeOfContainerIsCustom { get; set; }

        public string CmbContainerTypeValue
        {
            get => (string)((ImageComboBoxItem)imgCmbBxEdtContainerType.SelectedItem).Value;
            set
            {
                if (value != string.Empty)
                    imgCmbBxEdtContainerType.SelectedIndex =
                        PopulateCmbContainerTypeWithSelectedContainerType(value);
            }
        }

        private int PopulateCmbContainerTypeWithSelectedContainerType(string selectedContainerType)
        {
            if (imgCmbBxEdtContainerType.Properties.Items == null)
            {
                return -1;
            }
            var containerTypes = imgCmbBxEdtContainerType.Properties.Items;
            for (var i = 0; i < containerTypes.Count; i++)
            {
                if ((string) containerTypes[i].Value == selectedContainerType)
                {
                    return i;
                }
            }
            return -1;
        }

        public string SelectedContainerTypeValue { get; set; }
        public string ChangedContainerTypeValue { get; set; }
        public bool CmbContainerStatusEnabled { get; set; }
        public int ContainerStatus { get; set; }

        public bool SelectedIndexStatusOfContainerIsDefault
        {
            set
            {
                if (value)
                    imgCmbBxEdtContainerStatus.SelectedIndex = 0;
            }
        }

        public bool SelectedIndexStatusOfContainerIsFirstIndex { get; set; }
        public bool SelectedIndexStatusOfContainerIsCustom { get; set; }

        public string CmbContainerStatusValue
        {
            get => (string)((ImageComboBoxItem)imgCmbBxEdtContainerStatus.SelectedItem).Value;
            set
            {
                if (value != string.Empty)
                    imgCmbBxEdtContainerStatus.SelectedIndex =
                        PopulateCmbContainerStatusWithSelectedContainerStatus(value);
            }
        }

        private int PopulateCmbContainerStatusWithSelectedContainerStatus(string selectedContainerStatus)
        {
            if (imgCmbBxEdtContainerStatus.Properties.Items == null)
            {
                return -1;
            }
            var containerStatuses = imgCmbBxEdtContainerStatus.Properties.Items;
            for (var i = 0; i < containerStatuses.Count; i++)
            {
                if ((string) containerStatuses[i].Value == selectedContainerStatus)
                {
                    return i;
                }
            }
            return -1;
        }

        public string SelectedContainerStatusValue { get; set; }
        public string ChangedContainerStatusValue { get; set; }
        public bool BtnContainerRedoEnabled { get; set; }
        public bool BtnContainerUndoEnabled { get; set; }

        public bool BtnContainerSaveEnabled
        {
            get => (bool)btnAddEditContainerSave.Enabled;
            set => btnAddEditContainerSave.Enabled = value;
        }

        public bool BtnContainerCancelEnabled
        {
            get => (bool)btnAddEditContainerCancel.Enabled;
            set => btnAddEditContainerCancel.Enabled = value;
        }

        public bool OnDemandLoadFlyoutContainerManagement
        {
            set
            {
                if (value)
                {
                    OpenMapPopulate();
                    if(!IsAddMode)
                        _ucFlyContainerManagementPresenter.PopulateContainerDataForModification();
                }
            }
        }

        public ContainerUiModel ChangedContainer { get; set; }
        public Guid SelectedContainerId { get; set; }

        public bool OnSuccessContainerCreation
        {
            set
            {
                if (value)
                {
                    Thread.Sleep(200);
                    var iResult = XtraMessageBox.Show("Η δημιουργία ενός νέου κάδου ολοκληρώθηκε με επιτυχία",
                        "Δημιουργία Κάδου",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    ActionAfterVerifyForTheContainerCreation = iResult == DialogResult.OK;
                    _ucFlyContainerManagementPresenter.ActionAfterVerifyForTheContainerCreation();
                }
            }
        }

        public bool ActionAfterVerifyForTheContainerCreation { get; set; }

        public bool VerifyForTheContainerModification { get; set; }
        public bool ActionAfterVerifyForTheContainerModification { get; set; }

        public string OnContainerSaveMsgError
        {
            set =>
                XtraMessageBox.Show(value,
                    "Λάθος εκτέλεση",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool OnSuccessContainerModification { get; set; }

        public bool OnDemandSelectContainerPhoto
        {
            set
            {
                if (value)
                {
                    openFileDialogPhotoContainer.Filter = "Images (*.jpg)|*.jpg";
                    openFileDialogPhotoContainer.Multiselect = false;
                    openFileDialogPhotoContainer.SupportMultiDottedExtensions = true;
                    openFileDialogPhotoContainer.CheckFileExists = true;
                    openFileDialogPhotoContainer.RestoreDirectory = true;

                    if (openFileDialogPhotoContainer.ShowDialog() == DialogResult.OK)
                    {  
                    }
                }
            }
        }

        public bool MapClearFromPoints
        {
            set
            {
                if (value)
                {
                    VectorItemsLayer vectorLayerPointContainer = mpCntrlAddEditContainer.Layers[0] as VectorItemsLayer;
                    ClearMapPoints(vectorLayerPointContainer);
                }
            }
        }

        public ContainerUiModel SelectedContainer { get; set; }

        public ContainerUiModel ModifiedContainer { get; set; }

        public ContainerUiModel CreatedContainer { get; set; }

        #endregion

        #region IMapView

        public double PointLat { get; set; }
        public double PointLon { get; set; }
        public string PointAddress { get; set; }


        #endregion

        #region IContainerImageView

        public string PctContainerImagePathValue
        {
            set
            {
                Uri blobUrl = new Uri(value);
                pctrEdtContainerPhoto.LoadAsync(value);
            }
        }

        public string SelectedContainerImageNameImageView { get; set; }



        #endregion

    }
}
