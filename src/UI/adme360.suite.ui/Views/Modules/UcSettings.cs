using System;
using System.Drawing;
using DevExpress.Utils.Menu;
using In.Eye.Soft.Client.Ui.Win.Controls;
using In.Eye.Soft.Client.Ui.Win.Views.Wizards;
using In.Eye.Soft.Clients.Core.Presenter.Settings;
using In.Eye.Soft.Clients.Core.View.Controls.Settings;

namespace In.Eye.Soft.Client.Ui.Win.Views.Modules
{
    public partial class UcSettings : BaseModule,
                                        ISettingsManagementView
    {
        private readonly Color[] _logMsgTypeColor = { Color.Green, Color.Blue, Color.Red };

        public enum LogMsgType
        {
            Error,
            Normal,
            Warning
        }

        private SettingsManagementPresenter _settingsManagementPresenter;


        public override string ModuleCaption { get { return "Ρυθμίσεις"; } }
        public override bool AllowWaitDialog { get { return false; } }

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

        public UcSettings()
        {
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _settingsManagementPresenter = new SettingsManagementPresenter(this);
        }

        private void BtnConfigNetworkClick(object sender, EventArgs e)
        {
            _settingsManagementPresenter.ConfigNetworkWasClicked();
        }

        public bool OnConfigNetwork
        {
            set
            {
                if (value)
                {
                    var wNet = new WizardNetwork();
                    wNet.ShowDialog();
                }
            }
        }

        public bool ConfigNetworkButtonEnabled
        {
            get { return btnConfigNetwork.Enabled; }
            set { btnConfigNetwork.Enabled = value; }
        }

        public bool LogsMmEnabled
        {
            get { return mmEdtLogsTxt.Enabled; }
            set { mmEdtLogsTxt.Enabled = value; }
        }

        public string MmLogs
        {
            get
            {
                return mmEdtLogsTxt.Text;
            }
            set
            {
                Log(LogMsgType.Normal, value);
            }
        }

        private void Log(LogMsgType msgtype, string msg)
        {
            mmEdtLogsTxt.Invoke(new EventHandler(delegate
            {
                mmEdtLogsTxt.SelectedText = string.Empty;
                mmEdtLogsTxt.ForeColor = _logMsgTypeColor[(int)msgtype];
                mmEdtLogsTxt.MaskBox.AppendText(msg);
                mmEdtLogsTxt.ScrollToCaret();
            }));
        }


    }
}