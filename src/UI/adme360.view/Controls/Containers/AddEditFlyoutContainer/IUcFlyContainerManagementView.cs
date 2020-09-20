using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using adme360.view;
using adme360.models.DTOs.Containers;
using adme360.models.DTOs.Maps;

namespace adme360.view.Controls.Containers.AddEditFlyoutContainer
{
    public interface IUcFlyContainerManagementView : IView
    {
        bool IsAddMode { get; set; }

        bool TxtContainerLoadEnabled { get; set; }
        int TxtContainerLoadValue { get; set; }
        int SelectedContainerLoad { get; set; }
        bool SelectedIndexLoadOfContainerIsDefault { set; }
        int ChangedContainerLoad { get; set; }


        bool TxtContainerCapacityEnabled { get; set; }
        int TxtContainerCapacityValue { get; set; }
        int SelectedContainerCapacity { get; set; }
        bool SelectedIndexCapacityOfContainerIsDefault { set; }
        int ChangedContainerCapacity { get; set; }


        bool TxtContainerDescriptionEnabled { get; set; }
        string TxtContainerDescriptionValue { get; set; }
        string SelectedContainerDescription { get; set; }
        string ChangedContainerDescription { get; set; }

        bool TxtContainerNameEnabled { get; set; }
        string TxtContainerNameValue { get; set; }
        string SelectedContainerName { get; set; }
        string ChangedContainerName { get; set; }


        bool TxtContainerAddressEnabled { get; set; }
        double PointLatValue { get; set; }
        double PointLonValue { get; set; }
        string TxtContainerAddressValue { get; set; }
        string SelectedContainerAddress { get; set; }
        string ChangedContainerAddress { get; set; }

        bool PctContainerImageEnabled { get; set; }
        bool PctContainerImageClear { set; }
        Image PctContainerImageValue { get; set; }
        bool OnLoadAsyncImage { set; }

        string PctContainerImagePath { get; set; }
        string PctContainerImageServerPath { get; set; }
        string PctContainerImagePathName { get; set; }
        string SelectedContainerImage { get; set; }
        string ChangedContainerImage { get; set; }

        bool BarContainerLevelEnabled { get; set; }
        int BarContainerLevelValue { get; set; }
        int SelectedContainerLevel { get; set; }
        int ChangedContainerLevel { get; set; }

        bool MapContainerEnabled { get; set; }
        Geometry MapContainerValue { get; set; }
        Geometry SelectedMapContainer { get; set; }
        Geometry ChangedMapContainer { get; set; }
        bool OnCheckMapAddNewPoint { set; }
        bool OnMapEditPoint { set; }

        bool TgglContainerPointEnabled { get; set; }
        bool TgglContainerPointValue { get; set; }
        bool SelectedPointToggleContainer { get; set; }
        bool ChangedPointToggleContainer { get; set; }

        bool ChckContainerMandatoryEnabled { get; set; }
        bool ChckContainerMandatoryValue { get; set; }
        bool SelectedContainerMandatory { get; set; }
        bool ChangedContainerMandatory { get; set; }

        bool DtContainerMandatoryDateTimeEnabled { get; set; }
        DateTime DtContainerMandatoryDateTimeValue { get; set; }
        DateTime SelectedContainerMandatoryDateTime { get; set; }
        DateTime ChangedContainerMandatoryDateTime { get; set; }

        bool CmbContainerMandatoryOptionEnabled { get; set; }
        int ContainerMandatoryOption { get; set; }
        bool SelectedIndexMandatoryOptionOfContainerIsDefault { set; }
        bool SelectedIndexMandatoryOptionOfContainerIsFirstIndex { set; }
        bool SelectedIndexMandatoryOptionOfContainerIsCustom { set; }
        string CmbContainerMandatoryOptionValue { get; set; }
        string SelectedContainerMandatoryOptionValue { get; set; }
        string ChangedContainerMandatoryOptionValue { get; set; }

        bool CmbContainerFillLevelEnabled { get; set; }
        int ContainerFillLevel { get; set; }
        bool SelectedIndexFillLevelOfContainerIsDefault { set; }
        bool SelectedIndexFillLevelOfContainerIsFirstIndex { set; }
        bool SelectedIndexFillLevelOfContainerIsCustom { set; }
        string CmbContainerFillLevelValue { get; set; }
        string SelectedContainerFillLevelValue { get; set; }
        string ChangedContainerFillLevelValue { get; set; }


        bool CmbContainerMaterialEnabled { get; set; }
        int ContainerMaterial { get; set; }
        bool SelectedIndexMaterialOfContainerIsDefault { set; }
        bool SelectedIndexMaterialOfContainerIsFirstIndex { set; }
        bool SelectedIndexMaterialOfContainerIsCustom { set; }
        string CmbContainerMaterialValue { get; set; }
        string SelectedContainerMaterialValue { get; set; }
        string ChangedContainerMaterialValue { get; set; }

        bool CmbContainerTypeEnabled { get; set; }
        int ContainerType { get; set; }
        bool SelectedIndexTypeOfContainerIsDefault { set; }
        bool SelectedIndexTypeOfContainerIsFirstIndex { set; }
        bool SelectedIndexTypeOfContainerIsCustom { set; }
        string CmbContainerTypeValue { get; set; }
        string SelectedContainerTypeValue { get; set; }
        string ChangedContainerTypeValue { get; set; }


        bool CmbContainerStatusEnabled { get; set; }
        int ContainerStatus { get; set; }
        bool SelectedIndexStatusOfContainerIsDefault { set; }
        bool SelectedIndexStatusOfContainerIsFirstIndex { set; }
        bool SelectedIndexStatusOfContainerIsCustom { set; }
        string CmbContainerStatusValue { get; set; }
        string SelectedContainerStatusValue { get; set; }
        string ChangedContainerStatusValue { get; set; }

        bool BtnContainerRedoEnabled { get; set; }
        bool BtnContainerUndoEnabled { get; set; }
        bool BtnContainerSaveEnabled { get; set; }
        bool BtnContainerCancelEnabled { get; set; }

        bool OnDemandLoadFlyoutContainerManagement { set; }
        bool OnDemandSelectContainerPhoto { set; }
        bool MapClearFromPoints { set; }

        ContainerUiModel SelectedContainer { get; set; }
        ContainerUiModel ModifiedContainer { get; set; }
        ContainerUiModel CreatedContainer { get; set; }
        ContainerUiModel ChangedContainer { get; set; }
        Guid SelectedContainerId { get; set; }
        bool OnSuccessContainerCreation { set; }
        bool ActionAfterVerifyForTheContainerCreation { get; set; }
        bool VerifyForTheContainerModification { get; set; }
        bool ActionAfterVerifyForTheContainerModification { get; set; }
        string OnContainerSaveMsgError { set; }
        bool OnSuccessContainerModification { get; set; }
    }
}
