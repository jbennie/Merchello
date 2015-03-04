﻿namespace Merchello.Bazaar.Models
{
    using System;

    /// <summary>
    /// The payment method UI info.
    /// </summary>
    public class PaymentMethodUiInfo
    {
        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the payment method key.
        /// </summary>
        public Guid PaymentMethodKey { get; set; }
    }
}