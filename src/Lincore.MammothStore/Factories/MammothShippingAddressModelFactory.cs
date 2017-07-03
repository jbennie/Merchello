namespace Lincore.Mammoth.Factories
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Merchello.Core;
    using Merchello.Core.Gateways.Shipping;
    using Lincore.Mammoth.Models;
    using Merchello.Web.Factories;

    using Umbraco.Core;

    /// <summary>
    /// The factory responsible for building <see cref="MammothCheckoutAddressModel"/>s.
    /// </summary>
    public class MammothShippingAddressModelFactory : MammothCheckoutAddressModelFactoryBase<MammothCheckoutAddressModel>
    {
        /// <summary>
        /// The <see cref="IShippingContext"/>.
        /// </summary>
        private readonly IShippingContext _shippingContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="MammothShippingAddressModelFactory"/> class.
        /// </summary>
        public MammothShippingAddressModelFactory()
            : this(MerchelloContext.Current.Gateways.Shipping)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MammothShippingAddressModelFactory"/> class.
        /// </summary>
        /// <param name="shippingContext">
        /// The <see cref="IShippingContext"/>.
        /// </param>
        public MammothShippingAddressModelFactory(IShippingContext shippingContext)
        {
            Mandate.ParameterNotNull(shippingContext, "shippingContext");
            _shippingContext = shippingContext;
        }

        /// <summary>
        /// Gets a list of available countries for the shipping address.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{SelectListItem}"/>.
        /// </returns>
        protected override IEnumerable<SelectListItem> GetCountrySelectListItems()
        {
            var countries = _shippingContext.GetAllowedShipmentDestinationCountries();
            return GetSelectListItems(countries);
        }
    }
}