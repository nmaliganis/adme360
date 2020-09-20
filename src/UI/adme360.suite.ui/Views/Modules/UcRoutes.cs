using System;
using adme360.suite.ui.Controls;
using DevExpress.Utils.Menu;
using DevExpress.XtraMap;
using adme360.presenter.ViewModel.Routes;
using adme360.view.Controls.Routes;

namespace adme360.suite.ui.Views.Modules
{
    public partial class UcRoutes : BaseModule, IUcRoutesManagementView
    {
        public override string ModuleCaption => "Routes";
        public override bool AllowWaitDialog => true;

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

        private UcRoutesManagementPresenter _ucRoutesManagementPresenter;


        #region Private Members

        private void OpenMapPopulate()
        {
            mpCntrlRoutes.CenterPoint = new GeoPoint(40.6562959, 22.9092506);

            // Create a layer. 
            ImageLayer layerOpen = new ImageLayer();

            mpCntrlRoutes.Layers.Add(layerOpen);

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

        #endregion

        public UcRoutes()
        {
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _ucRoutesManagementPresenter = new UcRoutesManagementPresenter(this);
        }

        #region IUcRoutesManagementView

        public bool InitialLoadingWasCaught
        {
            set
            {
                if (value)
                {
                    OpenMapPopulate();
                }
            }
        }

        #endregion

        #region Locals

        private void UcRoutesLoad(object sender, EventArgs e)
        {
            _ucRoutesManagementPresenter.UcWasLoaded();
        }

        #endregion
    }
}
