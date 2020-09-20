using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraWizard;
using Timer = System.Windows.Forms.Timer;

namespace adme360.suite.ui
{
    public partial class WizardNetwork : XtraForm
    {
        private Timer _progressTimer = null;
        private bool _finish = false;
        private bool _eCancel = false;
        private bool _toggleOn = false;
        private bool _correctComplition = false;
        private string _ipAddress = String.Empty;
        private string _domainAddress = String.Empty;

        private readonly AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private int _pingsSent;

        public WizardNetwork()
        {
            InitializeComponent();
            InitializeLocalComponents(true, WizardStyle.Wizard97);
            InitializeValidationRules();
        }

        private void InitializeValidationRules()
        {
            ValidateControls();

            var rangeByteValidationRule = new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.Between,
                Value1 = 1,
                Value2 = 255,
                ErrorText = "Η τιμή θα πρέπει να είναι μεταξύ 0-255."
            };

            //dxValidationProviderNetByte.SetValidationRule(rngeTxt1stByte, rangeByteValidationRule);
            //dxValidationProviderNetByte.SetValidationRule(rngeTxt2ndByte, rangeByteValidationRule);
            //dxValidationProviderNetByte.SetValidationRule(rngeTxt3rdByte, rangeByteValidationRule);
            //dxValidationProviderNetByte.SetValidationRule(rngeTxt4thByte, rangeByteValidationRule);
            
            //dxValidationProviderNetByte.ValidationMode = ValidationMode.Auto;
        }

        private void InitializeLocalComponents(bool allowAnimation, WizardStyle style)
        {
            wzdCtrlNetwork.AllowTransitionAnimation = allowAnimation;
            wzdCtrlNetwork.WizardStyle = style;
        }

        private void CreateProgressTimer()
        {
            if (_progressTimer != null)
            {
                return;
            }
            wpBcrPrntrProgress.AllowNext = false;
            wpBcrPrntrProgress.AllowBack = false;
            lblBcrPrntrProgressBottom.Visible = false;
            _progressTimer = new Timer
            {
                Interval = 40
            };
            _progressTimer.Tick += new EventHandler(ProgressTimerTick);
            _progressTimer.Start();
        }

        private void ProgressTimerTick(object sender, EventArgs e)
        {
            prgrsBrCtrlBcrPrntrSucces.Position++;
            if (prgrsBrCtrlBcrPrntrSucces.Position >= 100)
            {
                _progressTimer.Stop();
                lblBcrPrntrProgressBottom.Visible = true;
                wpBcrPrntrProgress.AllowNext = true;
                wpBcrPrntrProgress.AllowBack = true;
            }
        }

        private void WizardNetworkFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_finish)
            {
                return;
            }
            if (XtraMessageBox.Show(this, "Επιθυμείτε να εξέλθετε από τη διαδικασία ρύθμισης διεύθυνσης διακομιστή;",
                                    "Διαδικασία ρύθμισης διεύθυνσης διακομιστή", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
            {
                _eCancel = true;
                e.Cancel = true;
            }
        }

        private void WzdCtrlNetworkCancelClick(object sender, CancelEventArgs e)
        {
            if (!_eCancel)
            {
                Close();
            }
        }

        private void WzdCtrlNetworkFinishClick(object sender, CancelEventArgs e)
        {
            _finish = true;
            Close();
        }

        private void WzdCtrlNetworkSelectedPageChanging(object sender, WizardPageChangingEventArgs e)
        {
            if (e.Page == wpBcrPrntrConfiguration)
            {
                e.Page.AllowNext = false;
                e.Page.AllowBack = false;
            }
            if (e.PrevPage == wpNetworkQuestion && e.Direction == Direction.Forward)
            {
                e.Page.AllowNext = (bool)ceYesAnswer.EditValue;
                if ((bool)ceYesAnswer.EditValue)
                {
                    e.Page = wpBcrPrntrProgress;
                }
            }
            if (e.PrevPage == wpNetworkQuestion && e.Direction == Direction.Backward)
            {
                e.Page = wpBcrPrntrConfiguration;
                ValidatePingButton();
            }
            if (e.PrevPage == wpBcrPrntrProgress && e.Direction == Direction.Backward)
            {
                e.Page = wpNetworkQuestion;
            }
            if (e.PrevPage == wpNetworkCompletion && e.Direction == Direction.Backward)
            {
                e.Page = wpBcrPrntrConfiguration;
            }
            if (e.Page == wpBcrPrntrProgress)
            {
                CreateProgressTimer();
                StoreIpAddressChanges();
                _correctComplition = CheckStoredIpAddressChanges();
            }
            if (e.PrevPage == wpBcrPrntrProgress)
            {
                _progressTimer.Tick -= new EventHandler(ProgressTimerTick);
                _progressTimer.Dispose();
                _progressTimer = null;
                prgrsBrCtrlBcrPrntrSucces.Position = 0;
                lblBcrPrntrProgressBottom.Visible = false;
            }
            if (e.Page == wpNetworkCompletion)
            {
                if (_correctComplition)
                {
                    wpNetworkCompletion.Text = "Συγχαρητήρια  – Περάσατε όλα τα βήματα επιτυχώς!";
                    wpNetworkCompletion.FinishText =
                        String.Format("Ευχαριστούμε για τη ορθή διαδικασία ρύθμισης διεύθυνσης διακομιστή!");
                }
                else
                {
                    wpNetworkCompletion.Text = "Μας συγχωρείτε, η διαδικασία ρύθμισης διεύθυνσης διακομιστή απέτυχε.";
                    wpNetworkCompletion.FinishText = "Μας συγχωρείτε πολύ , αλλά η διαδικασία ρύθμισης διεύθυνσης διακομιστή δεν μπορεί να ολοκληρωθεί. Παρακαλούμε επιλέξτε Ολοκλήρωση για να εξέλθετε.";
                }
            }
        }

        private void StoreIpAddressChanges()
        {
/*            if (_toggleOn)
                ClientSettingsSingleton.Instance().IpAddressConfigValue = _ipAddress;
            else
                ClientSettingsSingleton.Instance().IpAddressConfigValue = _domainAddress;*/
        }

        private bool CheckStoredIpAddressChanges()
        {
            return true;
            //return ClientSettingsSingleton.Instance().IpAddressConfigValue == _ipAddress;
        }

        private void CeYesAnswerSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((bool) ceYesAnswer.EditValue)
                wpNetworkQuestion.AllowNext = true;
            else
                wpNetworkQuestion.AllowNext = false;
        }

        private void BtnIpAddressPingClick(object sender, EventArgs e)
        {
            _pingsSent = 0;
            mmEdtPingResults.MaskBox.Clear();

            if (_toggleOn)
                mmEdtPingResults.Text += "Pinging " + mmEdtPingResults.Text + " with 32 bytes of data:\r\n\r\n";
            else
                mmEdtPingResults.Text += "Pinging " + txtEdtDomainAddress.Text + " with 32 bytes of data:\r\n\r\n";
            PrepareForPing(_toggleOn);
            SendPing(_toggleOn);
            wpBcrPrntrConfiguration.AllowNext = true;
            wpBcrPrntrConfiguration.AllowBack = true;
        }

        private void PrepareForPing(bool type)
        {
            if (type)
                _ipAddress = rngeTxt1stByte.Text + "."
                             + rngeTxt2ndByte.Text + "."
                             + rngeTxt3rdByte.Text + "."
                             + rngeTxt4thByte.Text;
            else
                _domainAddress = txtEdtDomainAddress.Text;
        }

        private void SendPing(bool type)
        {
            var pingSender = new Ping();
            pingSender.PingCompleted += new PingCompletedEventHandler(PingSenderComplete);
            var packetData = Encoding.ASCII.GetBytes("................................");
            var packetOptions = new PingOptions(50, true);
            try
            {
                if (type)
                    pingSender.SendAsync(_ipAddress, 5000, packetData, packetOptions, _resetEvent);
                else
                    pingSender.SendAsync(_domainAddress, 5000, packetData, packetOptions, _resetEvent);
            }
            catch (Exception)
            {
                XtraMessageBox.Show(this, " Παρουσιάστηκε σφάλμα κατα τη διάρκεια ρύθμισης της διεύθυνσης διακομιστή !",
                                    "Σφάλμα ρύθμισης διεύθυνσης διακομιστή", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }


        private void PingSenderComplete(object sender, PingCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                mmEdtPingResults.Text += "Χειραψία ακυρώθηκε...\r\n";
                ((AutoResetEvent)e.UserState).Set();
            }
            else
            {
                if (e.Error != null)
                {
                    mmEdtPingResults.Text += "Παρουσιάστηκε σφάλμα: " + e.Error + "\r\n";
                    ((AutoResetEvent)e.UserState).Set();
                }
                else
                {
                    var pingResponse = e.Reply;
                    ShowPingResults(pingResponse);
                }
            }
        }

        public void ShowPingResults(PingReply pingResponse)
        {
            if (pingResponse == null)
            {
                mmEdtPingResults.Text += "Δεν ανταποκρίνεται.\r\n\r\n";
                return;
            }
            if (pingResponse.Status == IPStatus.Success)
            {
                mmEdtPingResults.Text += "Reply from " + pingResponse.Address.ToString() + ": bytes="
                                         + pingResponse.Buffer.Length + " time="
                                         + pingResponse.RoundtripTime + " TTL="
                                         + pingResponse.Options.Ttl + "\r\n";
            }
            else
            {
                mmEdtPingResults.Text += "Η χειραψία δεν ολοκληρώθηκε: " + pingResponse.Status + "\r\n\r\n";
            }
            _pingsSent++;
            if (_pingsSent < 4)
            {
                SendPing(_toggleOn);
            }
        }

        private void ValidatePingButton()
        {
            if ((!string.IsNullOrEmpty(rngeTxt1stByte.Text) &&
                !string.IsNullOrEmpty(rngeTxt2ndByte.Text) &&
                !string.IsNullOrEmpty(rngeTxt3rdByte.Text) &&
                !string.IsNullOrEmpty(rngeTxt4thByte.Text) ||
                rngeTxt1stByte.Text != "0" &&
                rngeTxt2ndByte.Text != "0" &&
                rngeTxt3rdByte.Text != "0" &&
                rngeTxt4thByte.Text != "0")
            )
            {
                btnIPAddressPing.Enabled = true;
            }
        }

        private void rngeTxt1stByte_EditValueChanged(object sender, EventArgs e)
        {
            ValidatePingButton();
        }

        private void rngeTxt2ndByte_EditValueChanged(object sender, EventArgs e)
        {
            ValidatePingButton();
        }

        private void rngeTxt3rdByte_EditValueChanged(object sender, EventArgs e)
        {
            ValidatePingButton();
        }

        private void rngeTxt4thByte_EditValueChanged(object sender, EventArgs e)
        {
            ValidatePingButton();
        }

        private void TgglSwDomainSelectionToggled(object sender, EventArgs e)
        {
            _toggleOn = tggleSwDomainSelection.IsOn;
            ValidateControls();
        }

        private void ValidateControls()
        {
            if (_toggleOn)
            {
                btnIPAddressPing.Enabled = false;
                txtEdtDomainAddress.Enabled = false;
                rngeTxt1stByte.Enabled = true;
                rngeTxt2ndByte.Enabled = true;
                rngeTxt3rdByte.Enabled = true;
                rngeTxt4thByte.Enabled = true;
            }
            else
            {
                btnIPAddressPing.Enabled = true;
                txtEdtDomainAddress.Enabled = true;
                rngeTxt1stByte.Enabled = false;
                rngeTxt2ndByte.Enabled = false;
                rngeTxt3rdByte.Enabled = false;
                rngeTxt4thByte.Enabled = false;
            }
        }
    }
}
