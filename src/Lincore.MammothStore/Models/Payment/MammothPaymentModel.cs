namespace Lincore.Mammoth.Models.Payment
{
    using Merchello.Web.Store.Models;

    /// <summary>
    /// The cash payment model for the Mammoth store.
    /// </summary>
    public class MammothPaymentModel : StorePaymentModel, ISuccessRedirectUrl
    {
        /// <summary>
        /// Gets or sets the success redirect url.
        /// </summary>
        public string SuccessRedirectUrl { get; set; }
    }
}