namespace Lincore.Mammoth.Configuration
{
    using System.Configuration;
    using Merchello.Core.Configuration.Outline;

    /// <summary>
    /// Defines the Mammoth main configuration section
    /// </summary>
    public class MammothSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the settings collection
        /// </summary>
        [ConfigurationProperty("settings", IsRequired = true), ConfigurationCollection(typeof(SettingsCollection), AddItemName = "setting")]
        public SettingsCollection Settings
        {
            get { return (SettingsCollection)this["settings"]; }
        }
    }
}
