using dl.wm.presenter.Base;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Containers.AddEditFlyoutContainer;
using System;
using dl.wm.models.DTOs.Containers;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.Utilities;

namespace dl.wm.presenter.ViewModel.Containers
{
    public class UcFlyContainerManagementPresenter : BasePresenter<IUcFlyContainerManagementView, IContainersService>
    {

        private bool _bContainerMaterialValidated = false;
        private bool _bContainerLoadValidated = false;
        private bool _bContainerCapacityValidated = false;
        private bool _bContainerDescriptionValidated = false;
        private bool _bContainerNameValidated = false;
        private bool _bContainerLevelValidated = false;
        private bool _bContainerStatusValidated = false;
        private bool _bUserContainerMandatoryOptionValidated = false;
        private bool _bContainerFillLevelValidated = false;
        private bool _bContainerTypeValidated = false;
        private bool _bContainerMandatoryDateValidated = false;
        private bool _bContainerMandatoryValidated = false;

        public UcFlyContainerManagementPresenter(IUcFlyContainerManagementView view)
            : this(view, new ContainersService())
        {
        }

        public UcFlyContainerManagementPresenter(IUcFlyContainerManagementView view, IContainersService service)
            : base(view, service)
        {
        }

        public void FlyoutContainerManagementWasLoaded()
        {
            View.OnDemandLoadFlyoutContainerManagement = true;
            PrepareUiCtrlsAfterLoadFlyoutContainerManagement();
            if (View.SelectedContainerId == Guid.Empty)
            {
                PrepareUiCtrlsValuesAfterAddContainerWasSelected();
            }
            else
            {
                PopulateUiCtrlsValuesAfterEditContainerWasSelected();
            }
        }

        private void PopulateUiCtrlsValuesAfterEditContainerWasSelected()
        {

        }

        public void ActionAfterVerifyForTheContainerCreation()
        {
            if (View.ActionAfterVerifyForTheContainerCreation)
            {
                PrepareUiCtrlsValuesAfterAddContainerWasSelected();
                PrepareUiCtrlsAfterLoadFlyoutContainerManagement();
            }
        }

        private void PrepareUiCtrlsValuesAfterAddContainerWasSelected()
        {
            View.SelectedContainerId = Guid.Empty;

            View.SelectedContainerName = string.Empty;
            View.SelectedContainerDescription = string.Empty;
            View.SelectedIndexLoadOfContainerIsDefault = true;
            View.SelectedIndexCapacityOfContainerIsDefault = true;
            View.SelectedContainerLevel = 12;
            View.SelectedIndexFillLevelOfContainerIsDefault = true;

            View.SelectedIndexTypeOfContainerIsDefault = true;
            View.SelectedContainerAddress = string.Empty;
            View.MapClearFromPoints = true;
            View.SelectedIndexStatusOfContainerIsDefault = true;
            View.SelectedIndexMaterialOfContainerIsDefault = true;

            View.SelectedContainerMandatory = false;
            View.SelectedContainerMandatoryDateTime = DateTime.Now;
            View.SelectedIndexMandatoryOptionOfContainerIsDefault = true;
            View.SelectedContainerImage = string.Empty;

            View.TxtContainerNameValue = string.Empty;
            View.TxtContainerDescriptionValue = string.Empty;
            View.BarContainerLevelValue = 12;
            View.TgglContainerPointValue = false;
            View.TxtContainerAddressValue = string.Empty;
            View.ChckContainerMandatoryValue = false;
            View.DtContainerMandatoryDateTimeValue = DateTime.Now;

            View.PctContainerImageClear = true;
            View.PctContainerImagePath = string.Empty;
            View.PctContainerImagePathName = string.Empty;
            View.PctContainerImagePathName = string.Empty;
            View.PctContainerImageServerPath = string.Empty;
        }

        private void PrepareUiCtrlsAfterLoadFlyoutContainerManagement()
        {
            View.BtnContainerSaveEnabled = false;
            View.BtnContainerCancelEnabled = true;

            View.TxtContainerNameEnabled = true;
            View.TxtContainerDescriptionEnabled = true;
            View.TxtContainerLoadEnabled = true;
            View.TxtContainerCapacityEnabled = true;
            View.BarContainerLevelEnabled = true;
            View.CmbContainerFillLevelEnabled = true;

            View.CmbContainerTypeEnabled = true;
            View.TxtContainerAddressEnabled = false;
            View.TgglContainerPointEnabled = true;
            View.MapContainerEnabled = true;
            View.CmbContainerStatusEnabled = true;
            View.CmbContainerMaterialEnabled = true;
            View.ChckContainerMandatoryEnabled = true;
            View.DtContainerMandatoryDateTimeEnabled = false;
            View.CmbContainerMandatoryOptionEnabled = false;
            View.PctContainerImageEnabled = true;
        }

        public void MapWasClicked()
        {
            if (View.TgglContainerPointValue)
            {
                View.OnCheckMapAddNewPoint = true;
            }
        }

        public void ContainerPhotoWasDoubleClicked()
        {
            View.OnDemandSelectContainerPhoto = true;
        }

        public async void SaveContainerBtnWasClicked()
        {
            View.ChangedContainer = new ContainerUiModel();
            PrepareChangedContainerForSaving();

            if (!CheckIfContainerCanBeSaved())
            {
                View.OnContainerSaveMsgError = "Διόρθωση. " +
                                               "Συμπληρώστε όλα τα απαραίτητα πεδία";
                return;
            }

            try
            {
                //Create
                if (View.SelectedContainerId == Guid.Empty)
                {
                    View.CreatedContainer = await Service.CreateContainerAsync(View.ChangedContainer, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

                    if (View.CreatedContainer != null)
                        View.OnSuccessContainerCreation = true;
                }
                //Modify
                else
                {
                    if (!CheckContainerForValidation())
                        return;
                    View.VerifyForTheContainerModification = true;
                    if (View.ActionAfterVerifyForTheContainerModification)
                    {
                        View.ChangedContainer.Id = View.SelectedContainerId;
                        View.ModifiedContainer = await Service.UpdateEntityAsync(View.ChangedContainer,
                            ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                        View.OnSuccessContainerModification = View.ModifiedContainer != null;
                    }
                }
            }
            catch (Exception e)
            {
                HandleServiceException(e);
            }
        }

        private void HandleServiceException(Exception e)
        {
            if (e is ServiceHttpRequestException<string>)
            {
                ServiceHttpRequestException<string> ex = (ServiceHttpRequestException<string>) e;

                switch (ex.Content)
                {
                    case "ERROR_CONTAINER_ALREADY_EXISTS":
                        View.OnContainerSaveMsgError = "Ο Κάδος υπάρχει ήδη.";
                        break;
                    case "ERROR_CONTAINER_NOT_MADE_PERSISTENT":
                        View.OnContainerSaveMsgError = "Σφάλμα κατά την αποθήκευση του Κάδου.";
                        break;
                    case "ERROR_CONTAINER_INVALID_MODEL":
                        View.OnContainerSaveMsgError =
                            "Μη έγκειρα στοιχεία εισαγωγής Κάδου.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "UNKNOWN_ERROR":
                        View.OnContainerSaveMsgError = "Σφάλμα απροσδιόριστο.";
                        break;
                    default:
                        View.OnContainerSaveMsgError =
                            $"Σφάλμα διακομιστή: {ex.HttpStatusCode}\n, Επιπλέον στοιχεία: {ex.Content}";
                        break;
                }
            }
            else
            {
                View.OnContainerSaveMsgError = "΄Αγνωστο Σφάλμα: " + e.Message;
            }
        }

        private bool CheckContainerForValidation()
        {
            return true;
        }

        private bool CheckIfContainerCanBeSaved()
        {
            return (
                       !String.IsNullOrEmpty(View.ChangedContainer.ContainerName) &&
                       !String.IsNullOrEmpty(View.ChangedContainer.ContainerAddress) &&
                       View.ChangedContainer.ContainerLevel > 0) &&
                   View.ChangedContainer.ContainerLocationLat > 0 &&
                   View.ChangedContainer.ContainerLocationLong > 0;
        }

        private void PrepareChangedContainerForSaving()
        {
            View.ChangedContainer.ContainerName = _bContainerNameValidated
                ? View.ChangedContainerName
                : View.TxtContainerNameValue;

            View.ChangedContainer.ContainerDescription = _bContainerDescriptionValidated
                ? View.ChangedContainerDescription
                : View.TxtContainerDescriptionValue;

            View.ChangedContainer.ContainerCapacity = _bContainerCapacityValidated
                ? View.ChangedContainerCapacity
                : View.TxtContainerCapacityValue;

            View.ChangedContainer.ContainerLoad = _bContainerLoadValidated
                ? View.ChangedContainerLoad
                : View.TxtContainerLoadValue;

            View.ChangedContainer.ContainerAddress = View.TxtContainerAddressValue;
            View.ChangedContainer.ContainerLocationLat = View.PointLatValue;
            View.ChangedContainer.ContainerLocationLong = View.PointLonValue;
            View.ChangedContainer.ContainerImagePath = View.PctContainerImageServerPath;
            View.ChangedContainer.ContainerImageName = View.PctContainerImagePathName;
            View.ChangedContainer.ContainerLevel = _bContainerLevelValidated
                ? View.ChangedContainerLevel
                : View.BarContainerLevelValue;
            View.ChangedContainer.ContainerFillLevel = _bContainerFillLevelValidated
                ? View.ChangedContainerFillLevelValue
                : View.CmbContainerFillLevelValue;
            View.ChangedContainer.ContainerType = _bContainerTypeValidated
                ? View.ChangedContainerTypeValue
                : View.CmbContainerTypeValue;
            View.ChangedContainer.ContainerStatus = _bContainerStatusValidated
                ? View.ChangedContainerStatusValue
                : View.CmbContainerStatusValue;

            View.ChangedContainer.ContainerMaterial = _bContainerMaterialValidated
                ? View.ChangedContainerMaterialValue
                : View.CmbContainerMaterialValue;

            View.ChangedContainer.ContainerMandatoryPickupActive = _bContainerMandatoryValidated
                ? View.ChangedContainerMandatory
                : View.ChckContainerMandatoryValue;
            View.ChangedContainer.ContainerMandatoryPickupDate = _bContainerMandatoryDateValidated
                ? View.ChangedContainerMandatoryDateTime
                : View.DtContainerMandatoryDateTimeValue;

            View.ChangedContainer.ContainerFixed = true;
            View.ChangedContainer.ContainerWasteType = View.ChangedContainer.ContainerType;
        }

        public void MapPointToggleWasChanged()
        {

        }

        public async void ImageWasSelected()
        {
            ImageContainerDto imageUploadResponse = await Service.UploadImage(View.PctContainerImagePath, View.PctContainerImagePathName);

            if (imageUploadResponse.IsStoredSuccessfully)
            {
                View.PctContainerImageServerPath = imageUploadResponse.Path;
            }
        }

        public void MaterialValueChanged()
        {
            if (View.SelectedContainerMaterialValue != View.CmbContainerMaterialValue)
            {
                View.ChangedContainerMaterialValue = View.CmbContainerMaterialValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerMaterialValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerMaterialValidated = false;
            }
        }

        public void LoadValueChanged()
        {
            if (View.SelectedContainerLoad != View.TxtContainerLoadValue)
            {
                View.ChangedContainerLoad = View.TxtContainerLoadValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerLoadValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerLoadValidated = false;
            }
        }

        public void DescriptionValueChanged()
        {
            if (View.SelectedContainerDescription != View.TxtContainerDescriptionValue)
            {
                View.ChangedContainerDescription = View.TxtContainerDescriptionValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerDescriptionValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerDescriptionValidated = false;
            }
        }

        public void CapacityValueChanged()
        {
            if (View.SelectedContainerCapacity != View.TxtContainerCapacityValue)
            {
                View.ChangedContainerCapacity = View.TxtContainerCapacityValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerCapacityValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerCapacityValidated = false;
            }
        }

        public void MandatoryDateTimeWasChanged()
        {
            if (View.SelectedContainerMandatoryDateTime != View.DtContainerMandatoryDateTimeValue)
            {
                View.ChangedContainerMandatoryDateTime = View.DtContainerMandatoryDateTimeValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerMandatoryDateValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerMandatoryDateValidated = false;
            }
        }

        public void TypeValueChanged()
        {
            if (View.SelectedContainerTypeValue != View.CmbContainerTypeValue)
            {
                View.ChangedContainerTypeValue = View.CmbContainerTypeValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerTypeValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerTypeValidated = false;
            }
        }

        public void FillLevelValueChanged()
        {
            if (View.SelectedContainerFillLevelValue != View.CmbContainerFillLevelValue)
            {
                View.ChangedContainerFillLevelValue = View.CmbContainerFillLevelValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerFillLevelValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bUserContainerMandatoryOptionValidated = false;
            }
        }

        public void MandatoryPickupValueChanged()
        {
            if (!View.ChckContainerMandatoryValue)
            {
                View.DtContainerMandatoryDateTimeEnabled = false;
                View.CmbContainerMandatoryOptionEnabled = false;
            }
            else
            {
                View.DtContainerMandatoryDateTimeEnabled = true;
                View.CmbContainerMandatoryOptionEnabled = true;
            }

            if (View.SelectedContainerMandatory != View.ChckContainerMandatoryValue)
            {
                View.ChangedContainerMandatory = View.ChckContainerMandatoryValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerMandatoryValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerMandatoryValidated = false;
            }
        }

        public void MandatoryTypePickupValueChanged()
        {
            if (View.SelectedContainerMandatoryOptionValue != View.CmbContainerMandatoryOptionValue)
            {
                View.ChangedContainerMandatoryOptionValue = View.CmbContainerMandatoryOptionValue;
                View.BtnContainerSaveEnabled = true;
                _bUserContainerMandatoryOptionValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bUserContainerMandatoryOptionValidated = false;
            }
        }

        public void StatusValueChanged()
        {
            if (View.SelectedContainerStatusValue != View.CmbContainerStatusValue)
            {
                View.ChangedContainerStatusValue = View.CmbContainerStatusValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerStatusValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerStatusValidated = false;
            }
        }

        public void LevelValueChanged()
        {
            if (View.SelectedContainerLevel != View.BarContainerLevelValue)
            {
                View.ChangedContainerLevel = View.BarContainerLevelValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerLevelValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerLevelValidated = false;
            }

        }

        public void ContainerNameWasChanged()
        {
            if (View.SelectedContainerName != View.TxtContainerNameValue)
            {
                View.ChangedContainerName = View.TxtContainerNameValue;
                View.BtnContainerSaveEnabled = true;
                _bContainerNameValidated = true;
            }
            else
            {
                View.BtnContainerSaveEnabled = false;
                _bContainerNameValidated = false;
            }
        }

        public async void PopulateContainerDataForModification()
        {
            View.SelectedContainer = await Service.GetEntityByIdAsync(View.SelectedContainerId, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
            PrepareUiCtrlsAfterContainerSelection();
        }

        private void PrepareUiCtrlsAfterContainerSelection()
        {
            View.TxtContainerNameValue = View.SelectedContainer?.ContainerName;
            View.TxtContainerAddressValue = View.SelectedContainer?.ContainerAddress;
            if (View.SelectedContainer?.ContainerLevel != null)
                View.BarContainerLevelValue = (int) View.SelectedContainer?.ContainerLevel;
            View.CmbContainerFillLevelValue = View.SelectedContainer?.ContainerFillLevel;
            View.CmbContainerTypeValue = View.SelectedContainer?.ContainerTypeValue;
            View.CmbContainerStatusValue = View.SelectedContainer?.ContainerStatusValue;
            if (View.SelectedContainer?.ContainerLocationLat != null)
                View.PointLatValue = (double) View.SelectedContainer?.ContainerLocationLat;
            if (View.SelectedContainer?.ContainerLocationLong != null)
                View.PointLonValue = (double) View.SelectedContainer?.ContainerLocationLong;
            View.OnMapEditPoint = true;
            if (View.SelectedContainer?.ContainerMandatoryPickupActive != null)
                View.ChckContainerMandatoryValue = (bool) View.SelectedContainer?.ContainerMandatoryPickupActive;
            if (View.SelectedContainer?.ContainerMandatoryPickupDate != null)
            {
                View.DtContainerMandatoryDateTimeValue =
                    (DateTime) View.SelectedContainer?.ContainerMandatoryPickupDate;
                View.DtContainerMandatoryDateTimeValue = View.SelectedContainer.ContainerMandatoryPickupDate;
            }
            View.CmbContainerMandatoryOptionValue = View.SelectedContainer?.ContainerMandatoryPickupOption;
            View.PctContainerImagePath = View.SelectedContainer?.ContainerImageName;
            View.OnLoadAsyncImage = true;
        }


    }
}
