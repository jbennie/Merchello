namespace Lincore.Mammoth.Factories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Merchello.Core.Models;
    using Lincore.Mammoth.Models;
    using Merchello.Web.Factories;
    using Merchello.Web.Store.Models;

    /// <summary>
    /// A base class for building Mammoth checkout address models.
    /// </summary>
    /// <typeparam name="TAddress">
    /// The type of <see cref="StoreAddressModel"/>
    /// </typeparam>
    public abstract class MammothCheckoutAddressModelFactoryBase<TAddress> : CheckoutAddressModelFactory<TAddress>
        where TAddress : class, IMammothCheckoutAddressModel, new()
    {
        /// <summary>
        /// The on create.
        /// </summary>
        /// <param name="model">
        /// The <see cref="TAddress"/>.
        /// </param>
        /// <param name="adr">
        /// The <see cref="IAddress"/>.
        /// </param>
        /// <returns>
        /// The modified <see cref="TAddress"/>.
        /// </returns>
        protected override TAddress OnCreate(TAddress model, IAddress adr)
        {
            model.Countries = GetCountrySelectListItems();
            return base.OnCreate(model, adr);
        }

        protected override TAddress OnCreate(TAddress model, ICustomer customer, ICustomerAddress adr)
        {
            model.Email = customer.Email;
            model.Countries = GetCountrySelectListItems();
            return base.OnCreate(model, customer, adr);
        }

        /// <summary>
        /// Gets a list of available countries for the respective address.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{SelectListItem}"/>.
        /// </returns>
        protected abstract IEnumerable<SelectListItem> GetCountrySelectListItems();

        /// <summary>
        /// Maps a collection of <see cref="ICountry"/> to a list of <see cref="SelectListItem"/>.
        /// </summary>
        /// <param name="countries">
        /// The countries.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{SelectListItem}"/>.
        /// </returns>
        protected IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<ICountry> countries)
        {
            return countries.OrderBy(x => x.Name).Select(x => new SelectListItem { Value = x.CountryCode, Text = x.Name });
        }
    }
}