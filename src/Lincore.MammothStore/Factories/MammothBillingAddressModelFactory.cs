namespace Lincore.Mammoth.Factories
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Merchello.Core;
    using Merchello.Core.Models;
    using Merchello.Core.Services;
    using Lincore.Mammoth.Models;

    using Umbraco.Core;

    /// <summary>
    /// Overrides the default factory settings to use first name and last name to the <see cref="IAddress"/> Name field.
    /// </summary>
    public class MammothBillingAddressModelFactory : MammothCheckoutAddressModelFactoryBase<MammothBillingAddressModel>
    {
        /// <summary>
        /// The <see cref="IStoreSettingService"/>.
        /// </summary>
        private readonly IStoreSettingService _storeSettingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MammothBillingAddressModelFactory"/> class.
        /// </summary>
        public MammothBillingAddressModelFactory()
            : this(MerchelloContext.Current.Services.StoreSettingService)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MammothBillingAddressModelFactory"/> class.
        /// </summary>
        /// <param name="storeSettingService">
        /// The store setting service.
        /// </param>
        public MammothBillingAddressModelFactory(IStoreSettingService storeSettingService)
        {
            Mandate.ParameterNotNull(storeSettingService, "storeSettingService");
            _storeSettingService = storeSettingService;
        }

        /// <summary>
        /// Gets a list of available countries for the billing address.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{SelectListItem}"/>.
        /// </returns>
        protected override IEnumerable<SelectListItem> GetCountrySelectListItems()
        {
            var countries = _storeSettingService.GetAllCountries();
            return GetSelectListItems(countries);
        }

        /// <summary>
        /// Overrides the creation of the <see cref="MammothBillingAddressModel"/>.
        /// </summary>
        /// <param name="model">
        /// The <see cref="MammothBillingAddressModel"/>.
        /// </param>
        /// <param name="adr">
        /// The <see cref="IAddress"/>.
        /// </param>
        /// <returns>
        /// The modified <see cref="MammothBillingAddressModel"/>.
        /// </returns>
        protected override MammothBillingAddressModel OnCreate(MammothBillingAddressModel model, IAddress adr)
        {
            model.UseForShipping = true;
            return base.OnCreate(model, adr);
        }

        /// <summary>
        /// Overrides the creation of <see cref="ICustomerAddress"/>.
        /// </summary>
        /// <param name="model">
        /// The <see cref="ICustomerAddress"/>.
        /// </param>
        /// <param name="adr">
        /// The <see cref="MammothBillingAddressModel"/>.
        /// </param>
        /// <param name="customer">
        /// The <see cref="ICustomer"/>.
        /// </param>
        /// <param name="label">
        /// The customer address label (e.g. Billing Address).
        /// </param>
        /// <param name="addressType">
        /// The <see cref="AddressType"/>.
        /// </param>
        /// <returns>
        /// The modified <see cref="ICustomerAddress"/>.
        /// </returns>
        protected override ICustomerAddress OnCreate(ICustomerAddress model, MammothBillingAddressModel adr, ICustomer customer, string label, AddressType addressType)
        {
            // Set the address to the default address
            model.IsDefault = true;

            return base.OnCreate(model, adr, customer, label, addressType);
        }
    }
}