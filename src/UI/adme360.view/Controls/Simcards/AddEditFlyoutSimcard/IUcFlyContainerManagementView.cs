using System;
using adme360.view;
using adme360.models.DTOs.Devices;
using adme360.models.DTOs.Simcards;

namespace adme360.view.Controls.Simcards.AddEditFlyoutSimcard
{
    public interface IUcFlySimcardManagementView : IView
    {
        bool IsAddMode { get; set; }

        bool TxtSimcardIccidEnabled { get; set; }
        string TxtSimcardIccidValue { get; set; }
        string SelectedSimcardIccid { get; set; }
        string ChangedSimcardIccid { get; set; }

        bool TxtSimcardImsiEnabled { get; set; }
        string TxtSimcardImsiValue { get; set; }
        string SelectedSimcardImsi { get; set; }
        string ChangedSimcardImsi { get; set; }

        bool TxtSimcardNumberEnabled { get; set; }
        string TxtSimcardNumberValue { get; set; }
        string SelectedSimcardNumber { get; set; }
        string ChangedSimcardNumber { get; set; }

        bool LueSimcardDeviceEnabled { get; set; }
        Guid LueSimcardDeviceValue { get; set; }
        Guid SelectedSimcardDeviceId { get; set; }
        DeviceUiModel SimcardDevice { get; set; }
        Guid PreviousSelectedSimcardDeviceId { get; set; }
        bool SelectedIndexDeviceOfSimcardIsDefault { set; }
        bool SelectedIndexDeviceOfSimcardIsFirstIndex { set; }
        bool SelectedIndexDeviceOfSimcardIsCustom { set; }
        Guid ChangedSimcardDeviceId { get; set; }


        bool CmbSimcardCountryIsoEnabled { get; set; }
        int SimcardCountryIso { get; set; }
        bool SelectedIndexCountryIsoOfSimcardIsDefault { set; }
        bool SelectedIndexCountryIsoOfSimcardIsFirstIndex { set; }
        bool SelectedIndexCountryIsoOfSimcardIsCustom { set; }
        string CmbSimcardCountryIsoValue { get; set; }
        string SelectedSimcardCountryIsoValue { get; set; }
        string ChangedSimcardCountryIsoValue { get; set; }

        bool CmbSimcardCardTypeEnabled { get; set; }
        int SimcardCardType { get; set; }
        bool SelectedIndexCardTypeOfSimcardIsDefault { set; }
        bool SelectedIndexCardTypeOfSimcardIsFirstIndex { set; }
        bool SelectedIndexCardTypeOfSimcardIsCustom { set; }
        int CmbSimcardCardTypeValue { get; set; }
        int SelectedSimcardCardTypeValue { get; set; }
        int ChangedSimcardCardTypeValue { get; set; }

        bool CmbSimcardNetworkTypeEnabled { get; set; }
        int SimcardNetworkType { get; set; }
        bool SelectedIndexNetworkTypeOfSimcardIsDefault { set; }
        bool SelectedIndexNetworkTypeOfSimcardIsFirstIndex { set; }
        bool SelectedIndexNetworkTypeOfSimcardIsCustom { set; }
        int CmbSimcardNetworkTypeValue { get; set; }
        int SelectedSimcardNetworkTypeValue { get; set; }
        int ChangedSimcardNetworkTypeValue { get; set; }

        bool ChckSimcardEnabledStatusEnabled { get; set; }
        bool ChckSimcardEnabledStatusValue { get; set; }
        bool SelectedSimcardEnabledStatus { get; set; }
        bool ChangedSimcardEnabledStatus { get; set; }

        bool DtSimcardPurchaseDateTimeEnabled { get; set; }
        DateTime DtSimcardPurchaseDateTimeValue { get; set; }
        DateTime SelectedSimcardPurchaseDateTime { get; set; }
        DateTime ChangedSimcardPurchaseDateTime { get; set; }



        bool OnDemandLoadFlyoutSimcardManagement { set; }

        SimcardUiModel SelectedSimcard { get; set; }
        SimcardUiModel ModifiedSimcard { get; set; }
        SimcardUiModel CreatedSimcard { get; set; }
        SimcardUiModel ChangedSimcard { get; set; }
        
        Guid SelectedSimcardId { get; set; }
        bool OnSuccessSimcardCreation { set; }
        bool ActionAfterVerifyForTheSimcardCreation { get; set; }
        bool VerifyForTheSimcardModification { get; set; }
        bool ActionAfterVerifyForTheSimcardModification { get; set; }
        string OnSimcardSaveMsgError { set; }
        bool OnSuccessSimcardModification { get; set; }

        bool BtnSimcardSaveEnabled { get; set; }
        bool BtnSimcardCancelEnabled { get; set; }
        bool OnDemandLoadDevicesWithoutSimLue { set; }
    }
}
