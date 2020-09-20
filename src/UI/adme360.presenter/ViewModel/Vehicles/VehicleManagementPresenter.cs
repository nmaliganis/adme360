using System;
using dl.wm.models.DTOs.Vehicles;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Vehicles;
using dl.wm.presenter.Base;
using dl.wm.presenter.Helpers;

namespace dl.wm.presenter.ViewModel.Vehicles
{
    public class VehicleManagementPresenter : BasePresenter<IVehicleManagementView, IVehiclesService>
    {
        private bool _bVehicleBrandValidated;
        private bool _bVehicleNumPlateValidated;
        private bool _bVehicleTypeValidated;
        private bool _bVehicleStatusValidated;
        private bool _bVehicleGasValidated;

        private readonly string _role = string.Empty;

        public VehicleManagementPresenter(IVehicleManagementView view)
            : this(view, new VehiclesService())
        {
        }

        public VehicleManagementPresenter(IVehicleManagementView view, IVehiclesService service)
            : base(view, service)
        {
            _role = JwtHelper.ExtractRoleFromToken(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
        }

        public void UcLoadedOnDemand()
        {
            View.UcWasLoadedOnDemand = true;
            PopulateCtrlsOnLoadingWithRole();
        }

        private void PopulateCtrlsOnLoadingWithRole()
        {
            if (_role == "SU" || _role == "ADMIN")
            {
                PrepareUiAfterVehicleSelection();
            }
            else
            {
                View.BtnVehicleAddEnabled = false;
                View.BtnVehicleCancelEnabled = false;
                View.BtnVehicleDeleteEnabled = false;
                View.BtnVehicleSaveEnabled = false;                
            }
        }
        public void VehicleFromGridWasSelected()
        {
            PopulateVehicleDataAfterVehicleSelection();

            if (_role == "SU" || _role == "ADMIN")
            {
                PrepareUiAfterVehicleSelection();
            }
            else
            {
                View.BtnVehicleAddEnabled = false;
                View.BtnVehicleCancelEnabled = false;
                View.BtnVehicleDeleteEnabled = false;
                View.BtnVehicleSaveEnabled = false;                
            }
        }

        private async void PopulateVehicleDataAfterVehicleSelection()
        {
            if(View.SelectedVehicleId == Guid.Empty)
                return;

            View.SelectedVehicle = await Service.GetEntityByIdAsync(View.SelectedVehicleId, 
                ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
            PrepareUiCtrlsAfterVehicleSelection();
        }

        private void PrepareUiCtrlsAfterVehicleSelection()
        {
            View.TxtVehicleBrand = View.SelectedVehicle?.VehicleBrand;
            View.TxtVehicleNumPlate = View.SelectedVehicle?.VehicleNumPlate;
            if (View.SelectedVehicle?.VehicleType != null)
                View.CmbVehicleTypeValue = View.SelectedVehicle?.VehicleType;
            if (View.SelectedVehicle?.VehicleStatus != null)
                View.CmbVehicleStatusValue = View.SelectedVehicle?.VehicleStatus;
            if (View.SelectedVehicle?.VehicleGas != null)
                View.CmbVehicleGasValue = View.SelectedVehicle?.VehicleGas;
        }

        private void PrepareUiAfterVehicleSelection()
        {
            View.BtnVehicleAddEnabled = true;
            View.BtnVehicleDeleteEnabled = true;
            View.BtnVehicleCancelEnabled = false;
            View.BtnVehicleSaveEnabled = false;

            View.TxtVehicleBrandEnabled = true;
            View.TxtVehicleNumPlateEnabled = true;
            View.CmbVehicleTypeEnabled = true;
            View.CmbVehicleStatusEnabled = true;
            View.CmbVehicleGasEnabled = true;
        }

        public void NewVehicleBtnWasClicked()
        {
            PrepareUiAfterNewVehicleSelection();
            PrepareUiCtrlsAfterNewVehicleSelection();
        }

        private void PrepareUiAfterNewVehicleSelection()
        {
            View.BtnVehicleAddEnabled = false;
            View.BtnVehicleDeleteEnabled = false;
            View.BtnVehicleCancelEnabled = true;
            View.BtnVehicleSaveEnabled = false;

            View.TxtVehicleBrandEnabled = true;
            View.TxtVehicleNumPlateEnabled = true;
            View.CmbVehicleTypeEnabled = true;
            View.CmbVehicleStatusEnabled = true;
            View.CmbVehicleGasEnabled = true;
        }

        private void PrepareUiCtrlsAfterNewVehicleSelection()
        {
            View.PreviousSelectedVehicleId = View.SelectedVehicleId;
            View.SelectedVehicleId = Guid.Empty;
            View.SelectedVehicleBrand = string.Empty;
            View.SelectedVehicleNumPlate = string.Empty;
            View.SelectedVehicleTypeValue = string.Empty;
            View.SelectedVehicleStatusValue = string.Empty;
            View.SelectedVehicleGasValue = string.Empty;

            View.TxtVehicleBrand = string.Empty;
            View.TxtVehicleNumPlate = string.Empty;
            View.SelectedIndexVehicleOfTypeIsDefault = true;
            View.SelectedIndexVehicleOfStatusIsDefault = true;
            View.SelectedIndexVehicleOfGasIsDefault = true;
        }


        public void CancelVehicleBtnWasClicked()
        {
            PrepareUiAfterCancelVehicleSelection();
            PrepareUiCtrlsAfterCancelVehicleSelection();
        }

        private void PrepareUiAfterCancelVehicleSelection()
        {
            View.BtnVehicleAddEnabled = true;
            View.BtnVehicleDeleteEnabled = false;
            View.BtnVehicleCancelEnabled = false;
            View.BtnVehicleSaveEnabled = false;

            View.TxtVehicleBrandEnabled = true;
            View.TxtVehicleNumPlateEnabled = true;
            View.CmbVehicleTypeEnabled = true;
            View.CmbVehicleStatusEnabled = true;
            View.CmbVehicleGasEnabled = true;
        }
        private void PrepareUiCtrlsAfterCancelVehicleSelection()
        {
            View.SelectedVehicleId = View.PreviousSelectedVehicleId;
            PopulateVehicleDataAfterVehicleSelection();
        }

        #region For Create - Edit (POST - PUT) Vehicle Was Clicked - Cmd

        public async void SaveVehicleBtnWasClicked()
        {
            View.ChangedVehicle = new VehicleUiModel();
            PrepareChangedVehicleForSaving();

            if (!CheckIfVehicleCanBeSaved())
            {
                View.OnVehicleSaveMsgError = "Correction. " +
                                             "Fill in all required fields!";
                return;
            }

            try
            {
                //Create
                if (View.SelectedVehicleId == Guid.Empty)
                {
                    View.CreatedVehicle = await Service.CreateEntityAsync(View.ChangedVehicle);

                    if (View.CreatedVehicle != null)
                        View.OnSuccessVehicleCreation = true;
                }
                //Modify
                else
                {
                    if (!CheckVehicleForValidation())
                        return;
                    View.VerifyForTheVehicleModification = true;
                    if (View.ActionAfterVerifyForTheVehicleModification)
                    {
                        View.ChangedVehicle.Id = View.SelectedVehicleId;
                        //View.ModifiedVehicle = await Service.UpdateEntityAsync(View.ChangedVehicle);
                        //View.OnSuccessVehicleModification = View.ModifiedVehicle?.Content != null;
                    }
                }
            }
            catch (Exception e)
            {
                //HandleServiceException(e);
            }
        }

        #endregion


        #region For Remove (DELETE) Vehicle Was Clicked - Cmd

        public async void RemoveVehicleBtnWasClicked()
        {
            if (!CheckIfVehicleCanBeRemoved())
            {
                View.OnVehicleDeleteMsgError = "Correction. " +
                                                "Fill in all required fields!";
            }
            else
            {
                View.VerifyForTheVehicleDeletion = true;
                if (View.ActionAfterVerifyForTheVehicleDeletion)
                {
                    try
                    {
                        //View.DeletedVehicle = await Service.RemoveEntityAsync(View.SelectedVehicleId);
                        //if (View.DeletedVehicle.Status == VehicleActionStatus.Success)
                        //    View.OnSuccessVehicleDeletion = View.DeletedVehicle?.Content != null;
                    }
                    catch (Exception e)
                    {
                        //HandleServiceException(e);
                    }
                }
            }
        }

        #endregion

        #region Others

        private bool CheckIfVehicleCanBeRemoved()
        {
            return true;
        }

        private bool CheckIfVehicleCanBeSaved()
        {
            return (!String.IsNullOrEmpty(View.ChangedVehicle.VehicleBrand)
                    && !String.IsNullOrEmpty(View.ChangedVehicle.VehicleNumPlate)
                    && !String.IsNullOrEmpty(View.ChangedVehicle.VehicleType)
                    && !String.IsNullOrEmpty(View.ChangedVehicle.VehicleStatus)
                    && !String.IsNullOrEmpty(View.ChangedVehicle.VehicleGas)
                );
        }

        private void PrepareChangedVehicleForSaving()
        {
            View.ChangedVehicle.VehicleBrand = _bVehicleBrandValidated
                ? View.ChangedVehicleBrand
                : View.SelectedVehicleBrand;
            View.ChangedVehicle.VehicleNumPlate = _bVehicleNumPlateValidated
                ? View.ChangedVehicleNumPlate
                : View.SelectedVehicleNumPlate;
            View.ChangedVehicle.VehicleType = _bVehicleTypeValidated
                ? View.ChangedVehicleTypeValue
                : View.SelectedVehicleTypeValue;
            View.ChangedVehicle.VehicleStatus = _bVehicleStatusValidated
                ? View.ChangedVehicleStatusValue
                : View.SelectedVehicleStatusValue;
            View.ChangedVehicle.VehicleGas = _bVehicleGasValidated
                ? View.ChangedVehicleGasValue
                : View.SelectedVehicleGasValue;
        }

        //private void HandleServiceException(Exception e)
        //{
        //    if (e is ServiceHttpRequestException<string>)
        //    {
        //        ServiceHttpRequestException<string> ex = (ServiceHttpRequestException<string>) e;
        //        View.OnVehicleSaveMsgError =
        //            $"Server Error: HTTP status code: {ex.HttpStatusCode}\n, Message: {ex.Content}";
        //    }
        //    else if (e is ServiceHttpRequestException<VehicleServerResponse>)
        //    {
        //        ServiceHttpRequestException<VehicleServerResponse> ex =
        //            (ServiceHttpRequestException<VehicleServerResponse>) e;
        //        switch (ex.Content?.Status)
        //        {
        //            case VehicleActionStatus.ErrorVehicleAlreadyExists:
        //                View.OnVehicleSaveMsgError = "Vehicle already Exist.\nPlease double check your inputs.";
        //                break;
        //            case VehicleActionStatus.ErrorVehicleDoesNotExist:
        //                View.OnVehicleSaveMsgError = "Vehicle does not Exist";
        //                break;
        //            case VehicleActionStatus.ErrorVehicleNotMadePersistent:
        //                View.OnVehicleSaveMsgError = "Error trying to save Vehicle.\nInternal Server Error.";
        //                break;
        //            case VehicleActionStatus.ErrorInvalidVehicleModel:
        //                View.OnVehicleSaveMsgError = "Invalid Vehicle Data.\nPlease double check your inputs.";
        //                break;
        //            case VehicleActionStatus.ErrorInvalidVehicleId:
        //                View.OnVehicleSaveMsgError = "Invalid Vehicle Data.\nPlease double check the Id.";
        //                break;
        //            case VehicleActionStatus.UnknownError:
        //                View.OnVehicleSaveMsgError = "Internal Server Error.";
        //                break;
        //            case VehicleActionStatus.ErrorVehicleHasActiveMembers:
        //                View.OnVehicleDeleteMsgError = "This Vehicle has active members. Please remove them first.";
        //                break;
        //        }
        //    }
        //    else if (e is ServiceParseException)
        //    {
        //        ServiceParseException ex = (ServiceParseException) e;
        //        View.OnVehicleSaveMsgError = "Internal Server Error. " +
        //                                     $"Content: {ex.Content}." +
        //                                     $"Internal Message: {ex.Message}";
        //    }
        //    else
        //    {
        //        View.OnVehicleSaveMsgError = "UnKnown Error: " + e.Message;
        //    }
        //}

        private bool CheckVehicleForValidation()
        {
            return true;
        }

        #endregion
        
        #region Validation --->

        public void VehicleBrandValueWasChanged()
        {
            if (View.SelectedVehicleBrand != View.TxtVehicleBrand)
            {
                View.ChangedVehicleBrand = View.TxtVehicleBrand;
                View.BtnVehicleSaveEnabled = true;
                _bVehicleBrandValidated = true;
            }
            else
            {
                View.BtnVehicleSaveEnabled = false;
                _bVehicleBrandValidated = false;
            }
        }

        public void VehicleNumPlateValueWasChanged()
        {
            if (View.SelectedVehicleNumPlate != View.TxtVehicleNumPlate)
            {
                View.ChangedVehicleNumPlate = View.TxtVehicleNumPlate;
                View.BtnVehicleSaveEnabled = true;
                _bVehicleNumPlateValidated = true;
            }
            else
            {
                View.BtnVehicleSaveEnabled = false;
                _bVehicleNumPlateValidated = false;
            }
        }

        public void VehicleTypeValueWasChanged()
        {
            if (View.SelectedVehicleTypeValue != View.CmbVehicleTypeValue)
            {
                View.ChangedVehicleTypeValue = View.CmbVehicleTypeValue;
                View.BtnVehicleSaveEnabled = true;
                _bVehicleTypeValidated = true;
            }
            else
            {
                View.BtnVehicleSaveEnabled = false;
                _bVehicleTypeValidated = false;
            }
        }

        public void VehicleStatusValueWasChanged()
        {
            if (View.SelectedVehicleStatusValue != View.CmbVehicleStatusValue)
            {
                View.ChangedVehicleStatusValue = View.CmbVehicleStatusValue;
                View.BtnVehicleSaveEnabled = true;
                _bVehicleStatusValidated = true;
            }
            else
            {
                View.BtnVehicleSaveEnabled = false;
                _bVehicleStatusValidated = false;
            }
        }

        public void VehicleGasValueWasChanged()
        {
            if (View.SelectedVehicleGasValue != View.CmbVehicleGasValue)
            {
                View.ChangedVehicleGasValue = View.CmbVehicleGasValue;
                View.BtnVehicleSaveEnabled = true;
                _bVehicleGasValidated = true;
            }
            else
            {
                View.BtnVehicleSaveEnabled = false;
                _bVehicleGasValidated = false;
            }
        }

        #endregion


    }
}
