using System;
using adme360.view;

namespace adme360.view.Controls.Customers
{
    public interface ICustomerManagementView : IView
    {
        //Customer - Buttons
        bool BtnCustomerSaveEnabled { get; set; }
        //Customer - Customers
        bool TxtCustomerFirstNameEnabled { get; set; }
        bool TxtCustomerLastNameEnabled { get; set; }
        bool TxtCustomerUserNameEnabled { get; set; }
        bool TxtCustomerEmailEnabled { get; set; }
        bool MmCustomerNotesEnabled { get; set; }
        bool TxtCustomerPhoneEnabled { get; set; }
        bool CmbEdtCustomerExtPhoneEnabled { get; set; }
        bool ChBxCustomerActiveEnabled { get; set; }
        bool ChBxCustomerDeletedEnabled { get; set; }
        bool TxtFountainAddressOneEnabled { get; set; }
        bool TxtFountainAddressTwoEnabled { get; set; }
        bool TxtFountainAddressCityEnabled { get; set; }
        bool TxtFountainAddressRegionEnabled { get; set; }
        bool TxtFountainAddressPostcodeEnabled { get; set; }
        //Customer Advance Controls
        bool ImgCustomerGenderEnabled { get; set; }
        bool LueCustomerCountryEnabled { get; set; }
        //CustomerCountry
        Guid SelectedCustomerCountryId { get; set; }
        Guid PreviousSelectedCustomerCountryId { get; set; }
        Guid ChangedCustomerCountryId { get; set; }
        //CountryUiModel CustomerCountry { get; set; }
        bool SelectedIndexCountryOfCustomerIsDefault { set; }
        bool SelectedIndexCountryOfCustomerIsFirstIndex { set; }
        bool SelectedIndexCountryOfCustomerIsCustom { set; }
        //CustomerGender
        int SelectedGenderCustomer { get; set; }
        int ChangedGenderCustomer{ get; set; }
        int GenderCustomer{ get; set; }
        string SelectedGenderCustomerValue { get; set; }
        string ChangedGenderCustomerValue { get; set; }
        bool SelectedIndexCustomerOfGenderIsDefault { set; }
        //Customers - Values
        string TxtCustomerFirstName { get; set; }
        string TxtCustomerLastName { get; set; }
        string TxtCustomerUserName { get; set; }
        string TxtCustomerEmail { get; set; }
        string TxtCustomerNotes { get; set; }
        string TxtCustomerPhone { get; set; }
        string TxtCustomerExtPhone { get; set; }

        string TxtFountainAddressOne { get; set; }
        string TxtFountainAddressTwo { get; set; }
        string TxtFountainAddressCity { get; set; }
        string TxtFountainAddressRegion { get; set; }
        string TxtFountainAddressPostcode { get; set; }
        bool ChcBxCustomerActive { get; set; }
        bool ChcBxCustomerDeleted { get; set; }
        string ImgCombCustomerGender { get; set; }
        
        //Customer - Selected
        bool CustomerWasSelected { get; set; }
        Guid PreviousSelectedCustomerId { get; set; }
        Guid SelectedCustomerId { get; set; }
        string SelectedCustomerFirstName { get; set; }
        string SelectedCustomerLastName { get; set; }
        string SelectedCustomerUserName { get; set; }
        string SelectedCustomerEmail { get; set; }
        Guid SelectedCustomerTenantId { get; set; }
        //CustomerUiModel SelectedCustomer { get; set; }
        //CustomerUiModel FocusedSelectedCustomer { get; set; }
        //Customer - Changed
        bool CustomerWasChanged { get; set; }
        Guid ChangedCustomerId { get; set; }
        string ChangedCustomerFirstName { get; set; }
        string ChangedCustomerLastName { get; set; }
        //CustomerUiModel ChangedCustomer { get; set; }
        //Others
        bool UcCustomerWasLoadedOnDemand { get; set; }
        string OnCustomerSaveMsgError { get; set; }
        bool VerifyForTheCustomerModification { get; set; }
        bool ActionAfterVerifyForTheCustomerModification { get; set; }
        //CustomerServerResponse ModifiedCustomer { get; set; }
        //CustomerServerResponse ModifiedCustomer { get; set; }
        bool OnSuccessCustomerModification { get; set; }
    }
}
