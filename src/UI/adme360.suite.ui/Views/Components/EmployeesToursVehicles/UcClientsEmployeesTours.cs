using System;
using System.Collections.Generic;
using adme360.models.DTOs.Tours;
using adme360.presenter.ViewModel.Tours;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Tours;

namespace adme360.suite.ui.Views.Components.EmployeesToursVehicles
{
    public partial class UcClientsEmployeesTours : BaseModule, 
        ITourManagementView,
        IToursView
    {
        private ToursPresenter _toursPresenter;
        private TourManagementPresenter _tourManagementPresenter;

        public UcClientsEmployeesTours()
        {
            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _toursPresenter = new ToursPresenter(this);
            _tourManagementPresenter = new TourManagementPresenter(this);
        }

        #region IToursView

        public string OnGeneralMsg { get; set; }

        public List<TourUiModel> Tours
        {
            get => (List<TourUiModel>)gvAdvBndManagementEmployeeTours.DataSource;
            set => gcAdvBndManagementEmployeeTours.DataSource = value;
        }
        public bool NoneTourWasRetrieved { get; set; }

        #endregion

        #region ITourManagementView

        public bool UcWasLoadedOnDemand
        {
            set
            {
                if (value)
                {
                    _toursPresenter.LoadAllTours();
                }
            }
        }

        #endregion

        #region Locals

        private void UcClientsEmployeesToursLoad(object sender, EventArgs e)
        {
            _tourManagementPresenter.UcLoadedOnDemand();
        }

        private void ΤgglSwtchScheduledToursToggled(object sender, EventArgs e)
        {
            _tourManagementPresenter.FetchToursByScheduledDateWasToggled();
        }
        #endregion

    }
}
