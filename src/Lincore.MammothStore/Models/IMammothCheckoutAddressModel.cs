namespace Lincore.Mammoth.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Merchello.Web.Models.Ui;

    /// <summary>
    /// A base class for Mammoth <see cref="ICheckoutAddressModel"/>.
    /// </summary>
    public interface IMammothCheckoutAddressModel : ICheckoutAddressModel, ISuccessRedirectUrl
    {
        /// <summary>
        /// Gets or sets the list of countries for the view drop down list.
        /// </summary>
        IEnumerable<SelectListItem> Countries { get; set; }
    }
}