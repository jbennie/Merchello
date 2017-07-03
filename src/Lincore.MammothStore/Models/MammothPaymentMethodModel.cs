namespace Lincore.Mammoth.Models
{
    using Merchello.Web.Store.Models;

    /// <summary>
    /// The fast track payment selection method model.
    /// </summary>
    public class MammothPaymentMethodModel : StorePaymentMethodModel, ISuccessRedirectUrl
    {
        /// <summary>
        /// Gets or sets the success redirect url.
        /// </summary>
        public string SuccessRedirectUrl { get; set; }
    }
}