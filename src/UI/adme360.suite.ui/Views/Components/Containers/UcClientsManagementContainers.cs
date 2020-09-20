using System;
using System.Collections.Generic;
using DevExpress.XtraBars;
using adme360.models.DTOs.Containers;
using adme360.presenter.ViewModel.Containers;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Containers;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraMap;

namespace adme360.suite.ui.Views.Components.Containers
{
    public partial class UcClientsManagementContainers : BaseModule,
        IUcContainerManagementView,
        IContainersView
    {

        private UcContainerManagementPresenter _ucContainerManagementPresenter;
        private ContainersPresenter _containersPresenter;

        public UcClientsManagementContainers()
        {
            InitializeComponent();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            _ucContainerManagementPresenter = new UcContainerManagementPresenter(this);
            _containersPresenter = new ContainersPresenter(this);
        }

        private void BtnAddContainerClick(object sender, System.EventArgs e)
        {
            _ucContainerManagementPresenter.OpenFlyoutForAddContainerWasClicked();
        }

        private void BtnEditContainerClick(object sender, EventArgs e)
        {
            _ucContainerManagementPresenter.OpenFlyoutForEditContainerWasClicked();
        }

        private void BtnRemoveContainerClick(object sender, EventArgs e)
        {
            _ucContainerManagementPresenter.RemoveContainerWasClicked();
        }

        private void UcClientsUcContainersLoad(object sender, EventArgs e)
        {
            OnLoaded();
        }

        private void OnLoaded()
        {
            _ucContainerManagementPresenter.UcWasLoaded();
        }

        #region Private Members

        private void OpenMapPopulate()
        {
            mpCntrlContainerViewer.CenterPoint = new GeoPoint(40.6562959, 22.9092506);

            // Create a layer. 
            ImageLayer layerOpen = new ImageLayer();

            mpCntrlContainerViewer.Layers.Add(layerOpen);

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


        private void PopulateNewPointForContainerIntoMap()
        {
            VectorItemsLayer vectorLayerPointContainer = mpCntrlContainerViewer.Layers[0] as VectorItemsLayer;

            ClearMapPoints(vectorLayerPointContainer);

            GeoPoint gp = new GeoPoint()
            {
                Latitude = SelectedContainerLocationLat,
                Longitude = SelectedContainerLocationLong,
            };

            MapPushpin pin = new MapPushpin
            {
                Location = gp
            };

            ((MapItemStorage)vectorLayerPointContainer.Data).Items.Add(pin);
        }
        private static void ClearMapPoints(VectorItemsLayer vectorLayerPointContainer)
        {
            ((MapItemStorage)vectorLayerPointContainer.Data).Items.Clear();
        }

        private void OnSaveFlyoutContainer()
        {
        }

        #endregion

        #region Locals

        private void GvContainersFocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                SelectedContainerId = Guid.Empty;
                SelectedContainerName = string.Empty;
                SelectedContainerLevel = string.Empty;
                SelectedContainerFillLevelValue = string.Empty;
                SelectedContainerAddress = string.Empty;
                SelectedContainerTimeToFull = string.Empty;
                SelectedContainerLastServicedDateValue = DateTime.Now;
                SelectedContainerFirstRegistrationDateValue = DateTime.Now;
                SelectedContainerTypeValue = string.Empty;
                SelectedContainerStatusValue = string.Empty;
                SelectedContainerLocationLat = 0;
                SelectedContainerLocationLong = 0;
                SelectedContainerImageName = string.Empty;
            }
            else
            {
                SelectedContainerId = (Guid)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "Id");
                SelectedContainerName = (string)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerName");
                SelectedContainerAddress = (string)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerAddress");
                SelectedContainerTimeToFull = ((double)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerTimeFull")).ToString();
                SelectedContainerLastServicedDateValue = (DateTime)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerLastServicedDate");
                SelectedContainerFirstRegistrationDateValue = (DateTime)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerCreatedDate");
                SelectedContainerTypeValue = (string)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerTypeValue");
                SelectedContainerStatusValue = (string)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerStatusValue");
                SelectedContainerLocationLat = (double)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerLocationLat");
                SelectedContainerLocationLong = (double)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerLocationLong");
                SelectedContainerImageName = (string)gvContainers.GetRowCellValue(
                    e.FocusedRowHandle, "ContainerImageName");
            }

            _ucContainerManagementPresenter.ContainerFromGridWasSelected();
        }

        #endregion

        #region IContainersView

        public bool NoneContainerWasRetrieved { get; set; }

        public List<ContainerUiModel> Containers
        {
            get => (List<ContainerUiModel>) gvContainers.DataSource;
            set => gcContainers.DataSource = value;
        }        

        #endregion
        
        #region IUcContainerManagementView

        public bool ContainerWasSelected { get; set; }
        public Guid PreviousSelectedContainerId { get; set; }
        public Guid SelectedContainerId { get; set; }
        public string SelectedContainerName { get; set; }
        public string SelectedContainerAddress { get; set; }
        public double SelectedContainerLocationLat { get; set; }
        public double SelectedContainerLocationLong { get; set; }
        public string SelectedContainerLevel { get; set; }
        public string SelectedContainerTimeToFull { get; set; }
        public string SelectedContainerFillLevelValue { get; set; }
        public string SelectedContainerTypeValue { get; set; }
        public string SelectedContainerStatusValue { get; set; }
        public DateTime SelectedContainerLastServicedDateValue { get; set; }
        public DateTime SelectedContainerFirstRegistrationDateValue { get; set; }
        public string SelectedContainerImageName { get; set; }
        public ContainerUiModel SelectedContainer { get; set; }
        public ContainerUiModel ChangedContainer { get; set; }
        public bool NewContainerWasAdded { get; set; }
        public ContainerUiModel FocusedSelectedContainer { get; set; }
        public Guid ChangedContainerId { get; set; }
        public string ChangedContainerName { get; set; }
        public string ChangedContainerAddress { get; set; }
        public double ChangedContainerLocationLat { get; set; }
        public double ChangedContainerLocationLong { get; set; }
        public string ChangedContainerLevel { get; set; }
        public string ChangedContainerTimeToFull { get; set; }
        public string ChangedContainerFillLevelValue { get; set; }
        public string ChangedContainerTypeValue { get; set; }
        public string ChangedContainerStatusValue { get; set; }
        public DateTime ChangedContainerLastServicedDateValue { get; set; }
        public DateTime ChangedContainerFirstRegistrationDateValue { get; set; }
        public string ChangedContainerImageName { get; set; }

        public string PctContainerImageValue
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Uri blobUrl = new Uri(value);
                    pctrEdtContainerPhoto.LoadAsync(value);
                }
            }
        }

        public bool InitialLoadingWasCaught
        {
            set
            {
                if (value)
                {
                    OpenMapPopulate();
                    _containersPresenter.LoadAllContainers();
                }
            }
        }        

        public bool OpenFlyoutForAddContainer
        {
            set
            {
                if (value)
                {
                    FlyoutAddEditContainerEventArgs args = new FlyoutAddEditContainerEventArgs("OnAddNewContainer", Guid.Empty);
                    this.OnAddNewEditContainerRequested(args);
                    if (args.IsAccepted)
                    {
                        OnSaveFlyoutContainer();
                    }
                    _containersPresenter.LoadAllContainers();
                }
            }
        }

        public bool OnPopulateContainerDataAfterSelection
        {
            set
            {
                if (value)
                {
                    PopulateNewPointForContainerIntoMap();
                }
            }
        }

        public bool OpenFlyoutForEditContainer
        {
            set
            {
                if (value)
                {
                    FlyoutAddEditContainerEventArgs args =
                        new FlyoutAddEditContainerEventArgs("OnAddNewContainer", SelectedContainerId);
                    this.OnAddNewEditContainerRequested(args);
                    if (args.IsAccepted)
                    {
                        OnSaveFlyoutContainer();
                    }
                    _containersPresenter.LoadAllContainers();
                }
            }
        }
        #endregion
    }
}
