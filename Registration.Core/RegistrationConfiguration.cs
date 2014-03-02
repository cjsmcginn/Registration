using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core
{
    /// <summary>
    /// RegistrationConfiguration provides a Configuration Section that can be used in .config files. This configuration deals
    /// mainly with the way accounts are handled, password lengths, cookie expirations, etc... it is patterened around the 
    /// ASP membership provider.
    /// </summary>
    public class RegistrationConfiguration : ConfigurationSection
    {

        [ConfigurationProperty("authenticationCookieName", DefaultValue = "REGISTRATION.AUTH", IsRequired = false)]
        public string AuthenticationCookieName
        {
            get { return (string)this["authenticationCookieName"]; }
            set { this["authenticationCookieName"] = value; }
        }
        [ConfigurationProperty("createPersistantCookie", DefaultValue = "true", IsRequired = false)]
        public bool CreatePersistantCookie
        {
            get { return (bool)this["createPersistantCookie"]; }
            set { this["createPersistantCookie"] = value; }
        }
        [ConfigurationProperty("expirationMinutes", DefaultValue = "0", IsRequired = false)]
        public int ExpirationMinutes
        {
            get { return (int)this["expirationMinutes"]; }
            set { this["expirationMinutes"] = value; }
        }
        [ConfigurationProperty("minimumPasswordLength", DefaultValue = "6", IsRequired = false)]
        public int MinimumPasswordLength
        {
            get { return (int)this["minimumPasswordLength"]; }
            set { this["minimumPasswordLength"] = value; }
        }
        [ConfigurationProperty("minimumUsernameLength", DefaultValue = "6", IsRequired = false)]
        public int MinimumUsernameLength
        {
            get { return (int)this["minimumUsernameLength"]; }
            set { this["minimumUsernameLength"] = value; }
        }
        //Max

        [ConfigurationProperty("maximumPasswordLength", DefaultValue = "12", IsRequired = false)]
        public int MaximumPasswordLength
        {
            get { return (int)this["maximumPasswordLength"]; }
            set { this["maximumPasswordLength"] = value; }
        }
        [ConfigurationProperty("maximumUsernameLength", DefaultValue = "12", IsRequired = false)]
        public int MaximumUsernameLength
        {
            get { return (int)this["maximumUsernameLength"]; }
            set { this["maximumUsernameLength"] = value; }
        }

        [ConfigurationProperty("encryptPassword", DefaultValue = "False", IsRequired = false)]
        public bool EncryptPassword
        {
            get { return (bool)this["encryptPassword"]; }
            set { this["encryptPassword"] = value; }
        }

        [ConfigurationProperty("encryptionKey", DefaultValue = "", IsRequired = false)]
        public string EncryptionKey
        {
            get { return (string)this["encryptionKey"]; }
            set { this["encryptionKey"] = value; }
        }

        [ConfigurationProperty("maximumRetryCount", DefaultValue = "10", IsRequired = false)]
        public int MaximumRetryCount
        {
            get { return (int)this["maximumRetryCount"]; }
            set { this["maximumRetryCount"] = value; }
        }
    }
}
