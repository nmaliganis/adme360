using System;
using adme360.view;
using adme360.models.DTOs.Vehicles;

namespace adme360.view.Controls.Vehicles
{
    public interface IVehicleManagementView : IView
    {
        bool TxtVehicleBrandEnabled { get; set; }
        bool TxtVehicleNumPlateEnabled { get; set; }
        bool CmbVehicleTypeEnabled { get; set; }
        bool CmbVehicleStatusEnabled { get; set; }
        bool CmbVehicleGasEnabled { get; set; }

        int TypeVehicle { get; set; }
        bool SelectedIndexVehicleOfTypeIsDefault { set; }
        int StatusVehicle { get; set; }
        bool SelectedIndexVehicleOfStatusIsDefault { set; }
        int GasVehicle { get; set; }
        bool SelectedIndexVehicleOfGasIsDefault { set; }
        
        bool BtnVehicleAddEnabled { get; set; }
        bool BtnVehicleDeleteEnabled { get; set; }
        bool BtnVehicleCancelEnabled { get; set; }
        bool BtnVehicleSaveEnabled { get; set; }

        string TxtVehicleBrand { get; set; }
        string TxtVehicleNumPlate { get; set; }
        string CmbVehicleTypeValue { get; set; }
        string CmbVehicleStatusValue { get; set; }
        string CmbVehicleGasValue { get; set; }


        bool VehicleWasSelected { get; set; }
        Guid PreviousSelectedVehicleId { get; set; }
        Guid SelectedVehicleId { get; set; }
        string SelectedVehicleBrand { get; set; }
        string SelectedVehicleNumPlate { get; set; }
        string SelectedVehicleTypeValue { get; set; }
        string SelectedVehicleStatusValue { get; set; }
        DateTime SelectedVehicleRegisteredDateValue { get; set; }
        string SelectedVehicleGasValue { get; set; }


        VehicleUiModel SelectedVehicle { get; set; }


        bool VehicleWasChanged { get; set; }
        Guid ChangedVehicleId { get; set; }
        string ChangedVehicleBrand { get; set; }
        string ChangedVehicleNumPlate { get; set; }
        string ChangedVehicleTypeValue { get; set; }
        string ChangedVehicleStatusValue { get; set; }
        string ChangedVehicleGasValue { get; set; }

        VehicleUiModel ChangedVehicle { get; set; }
        
        bool NewVehicleWasAdded { get; set; }

        VehicleUiModel FocusedSelectedVehicle { get; set; }


        string OnVehicleSaveMsgError { set; }
        string OnVehicleDeleteMsgError { set; }
        bool OnSuccessVehicleCreation { set; }
        bool OnSuccessVehicleModification { set; }
        bool OnSuccessVehicleDeletion { set; }
        string OnVehicleGeneralMsg { set; }
        bool VerifyForTheVehicleModification { set; }
        bool ActionAfterVerifyForTheVehicleModification { get; set; }
        bool ActionAfterSuccessVehicleModification { get; set; }
        bool VerifyForTheVehicleDeletion { set; }
        bool ActionAfterVerifyForTheVehicleDeletion { get; set; }
        bool UcWasLoadedOnDemand { set; }
        VehicleUiModel CreatedVehicle { get; set; }
    }
}
