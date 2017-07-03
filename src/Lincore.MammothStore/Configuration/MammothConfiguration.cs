﻿namespace Lincore.Mammoth.Configuration
{
    using System;
    using System.Configuration;
    using Merchello.Core.Logging;

    /// <summary>
    /// Provides quick access to the Mammoth configuration section.
    /// </summary>
    public sealed class MammothConfiguration
    {
        /// <summary>
        /// Gets the application name.
        /// </summary>
        public const string ApplicationName = "Mammoth";

        /// <summary>
        /// Gets the configuration name.
        /// </summary>
        public static string ConfigurationName
        {
            get { return ApplicationName.ToLower(); }
        }

        /// <summary>
        /// The lazy loaded configuration section
        /// </summary>
        private static readonly Lazy<MammothConfiguration> Lazy = new Lazy<MammothConfiguration>(() => new MammothConfiguration());

        /// <summary>
        /// The root directory.
        /// </summary>
        private string _rootDir = string.Empty;

        /// <summary>
        /// Gets the current instance
        /// </summary>
        public static MammothConfiguration Current
        {
            get { return Lazy.Value; }
        }


        /// <summary>
        /// Gets the <see cref="MammothSection"/> Configuration Element
        /// </summary>
        public MammothSection Section
        {
            get { return (MammothSection)ConfigurationManager.GetSection(ConfigurationName); }
        }

        /// <summary>
        /// Get the Store document type alias
        /// </summary>
        public string ContentTypeAliasStore
        {
            get { return Section.Settings["ContentTypeAliasStore"].Value; }
        }

        /// <summary>
        /// Get the Basket document type alias
        /// </summary>
        public string ContentTypeAliasBasket
        {
            get { return Section.Settings["ContentTypeAliasBasket"].Value; }
        }

        /// <summary>
        /// Get the Catalog document type alias
        /// </summary>
        public string ContentTypeAliasCatalog
        {
            get { return Section.Settings["ContentTypeAliasCatalog"].Value; }
        }

        /// <summary>
        /// Get the Checkout document type alias
        /// </summary>
        public string ContentTypeAliasCheckout
        {
            get { return Section.Settings["ContentTypeAliasCheckout"].Value; }
        }

        /// <summary>
        /// Get the Receipt document type alias
        /// </summary>
        public string ContentTypeAliasReceipt
        {
            get { return Section.Settings["ContentTypeAliasReceipt"].Value; }
        }

        /// <summary>
        /// Get the Account document type alias
        /// </summary>
        public string ContentTypeAliasAccount
        {
            get { return Section.Settings["ContentTypeAliasAccount"].Value; }
        }

        /// <summary>
        /// Gets the content type alias change password.
        /// </summary>
        public string ContentTypeAliasChangePassword
        {
            get { return Section.Settings["ContentTypeAliasChangePassword"].Value; }
        }

        /// <summary>
        /// The get setting.
        /// </summary>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> value of the setting.
        /// </returns>
        public string GetSetting(string alias)
        {
            try
            {
                return Section.Settings[alias].Value;
            }
            catch (Exception ex)
            {
                MultiLogHelper.Info<MammothConfiguration>(ex.Message);
                return string.Empty;
            }
        }

    }
}
