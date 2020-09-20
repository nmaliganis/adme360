using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using adme360.models.DTOs.Containers;
using adme360.models.DTOs.Dashboards;
using adme360.presenter.ViewModel.Containers;
using adme360.presenter.ViewModel.Dashboards;
using adme360.presenter.ViewModel.Maps;
using adme360.view.Controls.Containers;
using adme360.view.Controls.Dashboards;
using adme360.view.Controls.Dashboards.Maps;
using adme360.models.DTOs.Dashboards;
using adme360.presenter.ViewModel.Dashboards;
using adme360.presenter.ViewModel.Maps;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Dashboards;
using adme360.view.Controls.Dashboards.Maps;
using DevExpress.Map;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Svg;
using DevExpress.XtraMap;
using adme360.models.DTOs.Containers;
using adme360.presenter.ViewModel.Containers;
using adme360.suite.ui.Views.Modules.Clustering;
using adme360.view.Controls.Containers;

namespace adme360.suite.ui.Views.Modules
{
    public partial class UcDashboard : BaseModule, IDashboardManagementView, IMapManagementView, IContainersPointsView
    {
        public override string ModuleCaption => "Dashboard";
        public override bool AllowWaitDialog => true;

        private ColorListLegend Legend => (ColorListLegend)(mpCntrlOpenDashboard.Legends[0]);
        private MapClustererBase _clusterer;
        static string LocationLegendHeader = "Tree location";

        #region Presenters

        private DashboardManagementPresenter _dashboardManagementPresenter;
        private MapManagementPresenter _mapManagementPresenter;
        private ContainerPointsPresenter _containerPointsPresenter;

        #endregion

        internal override void InitModule(IDXMenuManager manager, object data)
        {
            IsInitialized = true;
            base.InitModule(manager, data);
        }

        internal override void ShowModule(object item)
        {
            if (!IsInitialized)
                return;
            IsShown = true;
            base.ShowModule(item);

            OnShowModuleLocal();
        }

        private void OnShowModuleLocal()
        {
        }

        internal override void HideModule()
        {
            IsShown = false;
            base.HideModule();
        }

        public UcDashboard()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("el-EL");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("el-EL");
            InitializeComponent();
            InitializePresenters();
        }

        private void InitCluster()
        {
            listSourceDataAdapterOpenDashboardDumpsterSource.Mappings.Latitude = "ContainerLat";
            listSourceDataAdapterOpenDashboardDumpsterSource.Mappings.Longitude = "ContainerLon";

            listSourceDataAdapterOpenDashboardDumpsterSource.AttributeMappings.Add(new MapItemAttributeMapping() { Member = "Id", Name = "Id" });
            listSourceDataAdapterOpenDashboardDumpsterSource.AttributeMappings.Add(new MapItemAttributeMapping() { Member = "Name", Name = "ContainerPointType" });

            //_clusterer = new DistanceBasedClusterer();
            _clusterer = new MarkerClusterer();
            if (_clusterer != null)
            {
                _clusterer.Clustering += ClustererClustering;
                _clusterer.Clustered += ClustererClustered;
                _clusterer.SetClusterItemFactory(new CustomClusterItemFactory());
            }

            listSourceDataAdapterOpenDashboardDumpsterSource.Clusterer = _clusterer;
        }

        private void ClustererClustered(object sender, ClusteredEventArgs e)
        {
        }

        private void ClustererClustering(object sender, EventArgs e)
        {
        }

        private void InitializePresenters()
        {
            _containerPointsPresenter = new ContainerPointsPresenter(this);
            _dashboardManagementPresenter = new DashboardManagementPresenter(this);
            _mapManagementPresenter = new MapManagementPresenter(this);
        }

        private void UcDashboardLoad(object sender, System.EventArgs e)
        {
            
            _dashboardManagementPresenter.UcDashboardWasLoaded();
        }

        private void OnLoaded()
        {
            // Menemeni Center 40.6562959, 22.9092506
            mpCntrlOpenDashboard.CenterPoint = new GeoPoint(40.6562959, 22.9092506);

            // Create a layer. 
            ImageLayer layerOpen = new ImageLayer();
            
            mpCntrlOpenDashboard.Layers.Add(layerOpen);
            
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


        MapPolygon Poly;

        MapPushpin Pin { set; get; }

        private void MpCntrlOpenDashboardMapItemClick(object sender, MapItemClickEventArgs e)
        {
            IList<MapItem> groupItems = e.Item.ClusteredItems;
            if (groupItems != null)
                mpCntrlOpenDashboard.ZoomToFit(groupItems);
        }

        private void TggCmdAddRemoveDumpsterToggled(object sender, EventArgs e)
        {
            _mapManagementPresenter.ToggleAddRemoveDumpsterWasClicked();
        }

        private void BtnPopulatePointsGeofenceClick(object sender, EventArgs e)
        {
            try
            {
                VectorItemsLayer vectorLayerGeofencePoints = mpCntrlOpenDashboard.Layers[2] as VectorItemsLayer;

                foreach (var mapUiModel in Geofence)
                {
                    GeoPoint GP = new GeoPoint()
                    {
                        Latitude = mapUiModel.Latitude,
                        Longitude = mapUiModel.Longitude,
                    };

                    Pin = new MapPushpin
                    {
                        Location = GP
                    };

                    ((MapItemStorage) vectorLayerGeofencePoints.Data).Items.Add(Pin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPopulateGeofenceClick(object sender, EventArgs e)
        {
            try
            {
                VectorItemsLayer vectorLayerGeofence = mpCntrlOpenDashboard.Layers[1] as VectorItemsLayer;

                var vectorLayerGeofencePoints = ChkPopulateGeofenceOnDemand
                    ? mpCntrlOpenDashboard.Layers[3] as VectorItemsLayer
                    : mpCntrlOpenDashboard.Layers[2] as VectorItemsLayer;

                foreach (var mapUiModel in ChangedGeofence)
                {
                    GeoPoint GP = new GeoPoint()
                    {
                        Latitude = mapUiModel.Latitude,
                        Longitude = mapUiModel.Longitude,
                    };

                    Pin = new MapPushpin
                    {
                        Location = GP
                    };

                    ((MapItemStorage) vectorLayerGeofencePoints.Data).Items.Add(Pin);
                }

                Poly = new MapPolygon
                {
                    Fill = Color.FromArgb(20, 0, 0, 255)
                };

                foreach (MapPushpin mp in ((MapItemStorage)vectorLayerGeofencePoints.Data).Items)
                {
                    Poly.Points.Add(mp.Location);
                }

                ((MapItemStorage)vectorLayerGeofence.Data).Items.Add(Poly);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<MapUiModel> Geofence { get; set; }
        public List<MapUiModel> ChangedGeofence { get; set; } = new List<MapUiModel>();

        public bool NoneGeofencePointWasRetrieved
        {
            set
            {
                if (value)
                {

                }
            }

        }

        public bool CanAddPointToMap { get; set; }

        public bool ToggleCanAddPointToMap
        {
            get => (bool)tggCmdAddRemoveGeofencePoint.EditValue;
            set => tggCmdAddRemoveGeofencePoint.EditValue = value;
        }

        public bool ChkPopulateGeofenceOnDemand
        {
            get => (bool) chckEdtCmdGeofencePopulationFromSelection.EditValue;
            set => chckEdtCmdGeofencePopulationFromSelection.EditValue = value;
        }

        private void MpCntrlOpenDashboardMouseDown(object sender, MouseEventArgs e)
        {
            if (ToggleCanAddPointToMap)
            {
                VectorItemsLayer vectorLayerGeofencePoints = mpCntrlOpenDashboard.Layers[2] as VectorItemsLayer;

                MapPoint pressedPoint = new MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

                CoordPoint p = mpCntrlOpenDashboard.ScreenPointToCoordPoint(pressedPoint);  

                GeoPoint Gp = new GeoPoint()
                {
                    Latitude = p.GetY(),
                    Longitude = p.GetX(),
                };

                Pin = new MapPushpin
                {
                    Location = Gp
                };

                ((MapItemStorage) vectorLayerGeofencePoints.Data).Items.Add(Pin);

                return;
            }

            MapHitInfo info = this.mpCntrlOpenDashboard.CalcHitInfo(e.Location);  
            if (info.InMapPushpin) {  
                MapPushpin pin = (MapPushpin)info.MapPushpin;

                ChangedGeofence.Add(new MapUiModel()
                {
                    Longitude = pin.Location.GetX(),
                    Latitude = pin.Location.GetY(),
                });
            }  
        }

        private void BtnClearGeofenceAndSelectedPointsClick(object sender, EventArgs e)
        {
            VectorItemsLayer vectorLayerOpenGeofence = mpCntrlOpenDashboard.Layers[1] as VectorItemsLayer;
            VectorItemsLayer vectorLayerOpenGeofencePoints = mpCntrlOpenDashboard.Layers[3] as VectorItemsLayer;

            ((MapItemStorage)vectorLayerOpenGeofencePoints.Data).Items.Clear();
            ((MapItemStorage)vectorLayerOpenGeofence.Data).Items.Clear();
        }

        private void BtnStoreGeofenceClick(object sender, EventArgs e)
        {
            _mapManagementPresenter.StoreGeofenceWasClicked();
        }

        private void TggCmdAddRemoveGeofencePointToggled(object sender, EventArgs e)
        {
            _mapManagementPresenter.AddOrNotGeofencepoint();
        }

        private void btnClearPointsGeofence_Click(object sender, EventArgs e)
        {
            VectorItemsLayer vectorLayerOpenPointsGeofence = mpCntrlOpenDashboard.Layers[2] as VectorItemsLayer;
            ((MapItemStorage)vectorLayerOpenPointsGeofence.Data).Items.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _mapManagementPresenter.LoadDashboardGeofence();
        }


        #region IDashboardManagementView

        public bool OnDashboardLoaded
        {
            set
            {
                if (value)
                {
                    OnLoaded();
                    _containerPointsPresenter.LoadAllContainersPoints();
                    _mapManagementPresenter.LoadDashboardGeofence();
                    InitCluster();
                }
            }
        }

        public bool RibbonLockMapEnabled
        {
            get => brChckItmLockMap.Enabled;
            set => brChckItmLockMap.Enabled = value;
        }

        public bool RibbonLockMapValue
        {
            get => brChckItmLockMap.Checked;
            set => brChckItmLockMap.Checked = value;
        }

        public bool RibbonLockMapSvgImageIsBlack
        {
            set
            {
                if (value)
                {
                    brChckItmLockMap.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\lock_black.svg");;
                }
            }
        }

        public bool RibbonLockMapSvgImageIsOrange
        {
            set
            {
                if (value)
                {
                    brChckItmLockMap.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\lock_orange.svg");;
                }
            }
        }

        public bool RibbonGeofenceEnabled
        {
            get => brChckItmGeofence.Enabled;
            set => brChckItmGeofence.Enabled = value;
        }

        public bool RibbonGeofenceValue
        {
            get => brChckItmGeofence.Checked;
            set => brChckItmGeofence.Checked = value;
        }

        public bool RibbonGeofenceSvgImageIsBlack
        {
            set
            {
                if (value)
                {
                    brChckItmGeofence.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\geofence_black.svg");
                }
            }
        }

        public bool RibbonGeofenceSvgImageIsOrange
        {
            set
            {
                if (value)
                {
                    brChckItmGeofence.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\geofence_orange.svg");
                }
            }
        }

        public bool RibbonSphereEnabled
        {
            get => barCheckItemContainerOrange.Enabled;
            set => barCheckItemContainerOrange.Enabled = value;
        }

        public bool RibbonSphereValue
        {
            get => barCheckItemContainerOrange.Checked;
            set => barCheckItemContainerOrange.Checked = value;
        }

        public bool RibbonSphereSvgImageIsBlack
        {
            set
            {
                if (value)
                {
                    barCheckItemContainerOrange.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\sphere_black.svg");
                }
            }
        }

        public bool RibbonSphereSvgImageIsOrange
        {
            set
            {
                if (value)
                {
                    barCheckItemContainerOrange.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\sphere_orange.svg");
                }
            }
        }

        public bool RibbonWasteEnabled
        {
            get => brChckItmContainersWaste.Enabled;
            set => brChckItmContainersWaste.Enabled = value;
        }

        public bool RibbonWasteValue
        {
            get => brChckItmContainersWaste.Checked;
            set => brChckItmContainersWaste.Checked = value;
        }

        public bool RibbonWasteSvgImageIsBlack
        {
            set
            {
                if (value)
                {
                    brChckItmContainersWaste.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\waste_black.svg");
                }
            }
        }

        public bool RibbonWasteSvgImageIsOrange
        {
            set
            {
                if (value)
                {
                    brChckItmContainersWaste.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\waste_orange.svg");
                }
            }
        }

        public bool RibbonCompostEnabled
        {
            get => brChckItmContainersCompost.Enabled;
            set => brChckItmContainersCompost.Enabled = value;
        }

        public bool RibbonCompostValue
        {
            get => brChckItmContainersCompost.Checked;
            set => brChckItmContainersCompost.Checked = value;
        }

        public bool RibbonCompostSvgImageIsBlack
        {
            set
            {
                if (value)
                {
                    brChckItmContainersCompost.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\compost_black.svg");
                }
            }
        }

        public bool RibbonCompostSvgImageIsOrange
        {
            set
            {
                if (value)
                {
                    brChckItmContainersCompost.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\compost_orange.svg");
                }
            }
        }

        public bool RibbonRecycleEnabled
        {
            get => brChckItmContainersRecycle.Enabled;
            set => brChckItmContainersRecycle.Enabled = value;
        }

        public bool RibbonRecycleValue
        {
            get => brChckItmContainersRecycle.Checked;
            set => brChckItmContainersRecycle.Checked = value;
        }

        public bool RibbonRecycleSvgImageIsBlack
        {
            set
            {
                if (value)
                {
                    brChckItmContainersRecycle.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\recycle_black.svg");
                }
            }
        }

        public bool RibbonRecycleSvgImageIsOrange
        {
            set
            {
                if (value)
                {
                    brChckItmContainersRecycle.ImageOptions.SvgImage = SvgImage.FromFile("..\\..\\Assets\\recycle_orange.svg");
                }
            }
        }

        public bool OnClusterStepInPixelsChange
        {
            set
            {
                if (value)
                {
                    if (_clusterer != null)
                    {
                        this._clusterer.StepInPixels = RibbonBarTrackStepInPixelsValue;
                    }
                }
            }
        }

        public bool RibbonBarTrackStepInPixelsEnabled
        {
            get => (bool) brTrckItmStepInPixels.Enabled;
            set => brTrckItmStepInPixels.Enabled = value;
        }

        public int RibbonBarTrackStepInPixelsValue
        {
            get => (int) brTrckItmStepInPixels.EditValue;
            set => brTrckItmStepInPixels.EditValue = value;
        }

        #endregion

        #region IContainersPointsView

        public bool NoneContainerPointWasRetrieved { get; set; }

        public List<ContainerPointUiModel> ContainersPoints
        {
            set => listSourceDataAdapterOpenDashboardDumpsterSource.DataSource = value;
        }

        public string OnContainerPointsMsgError
        {
            set
            {
                //Todo: 
                throw new Exception();
            }
        }

        #endregion

        private void brEditItmAddressName_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarCheckItemContainerOrangeCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _dashboardManagementPresenter.RibbonCheckOrangeSphereClicked();
        }

        private void BarCheckItemContainerGrayCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarCheckItemContainerRedCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarCheckItemContainerYellowCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarCheckItemContainerGreenCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BrChckItmGeofenceCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _dashboardManagementPresenter.RibbonCheckGeofenceWasClicked();
        }

        private void BrChckItmLockMapCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _dashboardManagementPresenter.RibbonCheckLockMapWasClicked();
        }

        private void BrChckItmContainersWasteCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _dashboardManagementPresenter.RibbonCheckWasteWasClicked();
        }

        private void BrChckItmContainersRecycleCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _dashboardManagementPresenter.RibbonCheckRecycleWasClicked();
        }

        private void BrChckItmContainersCompostCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _dashboardManagementPresenter.RibbonCheckCompostWasClicked();
        }

        private void BrTrckItmStepInPixelsEditValueChanged(object sender, EventArgs e)
        {
            _dashboardManagementPresenter.StepInPixelsWasChanged();
        }
    }
}
