namespace Lincore.Mammoth.Controllers
{
    using System.Web.Mvc;

    using Lincore.Mammoth.Models;
    using Merchello.Web.Controllers;
    using Merchello.Web.Models.Ui;

    using Umbraco.Core;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// A controller responsible quoting shipment rate quotes.
    /// </summary>
    [PluginController("Mammoth")]
    public class CheckoutShipRateQuoteController : CheckoutShipRateQuoteControllerBase<MammothShipRateQuoteModel>
    {
        /// <summary>
        /// The handle ship rate quote save success.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        protected override ActionResult HandleShipRateQuoteSaveSuccess(MammothShipRateQuoteModel model)
        {
            return !model.SuccessRedirectUrl.IsNullOrWhiteSpace() ? 
                this.Redirect(model.SuccessRedirectUrl) 
                : base.HandleShipRateQuoteSaveSuccess(model);
        }
    }
}
