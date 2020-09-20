using adme360.suite.ui.Controls;
using DevExpress.Utils.Menu;

namespace adme360.suite.ui.Views.Modules
{
    public partial class UcAnalytics :  BaseModule
    {
        public override string ModuleCaption => "Analytics";
        public override bool AllowWaitDialog => false;

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
        }

        internal override void HideModule()
        {
            IsShown = false;
            base.HideModule();
        }

        public UcAnalytics()
        {
            InitializeComponent();
        }


    }
}