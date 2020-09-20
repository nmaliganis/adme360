using System;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using adme360.models.DTOs.Simcards;
using adme360.presenter.ViewModel.Simcards;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Sensors;
using adme360.view.Controls.Simcards;

namespace adme360.suite.ui.Views.Components.Sensors
{
    public partial class UcClientsSettingsSimcardSensors : BaseModule, ISimcardsView, IUcManagementSensorSettingsSimcardView
    {
        private SimcardsPresenter _simcardsPresenter;
        private UcSimcardManagementPresenter _ucSimcardManagementPresenter;

        public UcClientsSettingsSimcardSensors()
        {
            InitializeComponent();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            _simcardsPresenter = new SimcardsPresenter(this);
            _ucSimcardManagementPresenter = new UcSimcardManagementPresenter(this);
        }

        private void UcClientsUcContainersLoad(object sender, EventArgs e)
        {
            OnLoaded();
        }


        #region Locals
        private void OnLoaded()
        {
            _ucSimcardManagementPresenter.UcWasLoaded();
        }

        private void GvSimcardsFocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        private void BtnAddSimcardClick(object sender, EventArgs e)
        {
            _ucSimcardManagementPresenter.OpenFlyoutForAddSimcardWasClicked();
        }

        private void BtnEditSimcardClick(object sender, EventArgs e)
        {
            _ucSimcardManagementPresenter.OpenFlyoutForEditSimcardWasClicked();
        }

        private void BtnRemoveSimcardClick(object sender, EventArgs e)
        {

        }

        private void BtnBatchAddSimcardClick(object sender, EventArgs e)
        {

        }

        #endregion

        #region IUcManagementSensorSettingsSimcardView

        public Guid SelectedSimcardId { get; set; }

        public bool OpenFlyoutForAddSimcard
        {
            set
            {
                if (value)
                {
                    FlyoutAddEditSimcardEventArgs args =
                        new FlyoutAddEditSimcardEventArgs("OnAddNewSimcard", Guid.Empty);
                    this.OnAddNewEditSimcardRequested(args);
                    if (args.IsAccepted)
                    {
                        OnSaveFlyoutSimcard();
                    }
                    _simcardsPresenter.LoadAllSimcards();
                }
            }
        }
        private void OnSaveFlyoutSimcard()
        {
        }

        public bool OpenFlyoutForEditSimcard
        {
            set
            {
                if (value)
                {
                    FlyoutAddEditSimcardEventArgs args =
                        new FlyoutAddEditSimcardEventArgs("OnEditExistingSimcard", SelectedSimcardId);
                    this.OnAddNewEditSimcardRequested(args);
                    if (args.IsAccepted)
                    {
                        OnSaveFlyoutSimcard();
                    }
                    _simcardsPresenter.LoadAllSimcards();
                }
            }
        }

        public bool InitialLoadingWasCaught
        {
            set
            {
                if (value)
                {
                    _simcardsPresenter.LoadAllSimcards();
                }
            }
        }
        public bool RemoveSimcardWasCaught { get; set; }

        #endregion

        #region ISimcardsView

        public bool NoneSimcardWasRetrieved { get; set; }

        public List<SimcardUiModel> Simcards
        {
            get => (List<SimcardUiModel>) gvSimcards.DataSource;
            set => gcSimcards.DataSource = value;
        }

        #endregion
    }
}
