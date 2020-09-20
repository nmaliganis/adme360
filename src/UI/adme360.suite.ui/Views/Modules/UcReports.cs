using adme360.suite.ui.Controls;
using DevExpress.Utils.Menu;

namespace adme360.suite.ui.Views.Modules
{
    public partial class UcReports : BaseModule
    {
        public override string ModuleCaption => "Reports";
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

        public UcReports()
        {
            InitializeComponent();
        }
    }
}
