using System.Configuration;

namespace RANDOM
{
    public class GenerateSettings : ConfigurationSection
    {
        public const int Length = 10;
        public const int MinLength = 4;
        public const string Symbols = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";

        [ConfigurationProperty("registerCode")]
        public RegisterCode RegisterCode
        {
            get { return ((RegisterCode)(base["registerCode"])); }
        }

        [ConfigurationProperty("password")]
        public Password Password
        {
            get { return ((Password)(base["password"])); }
        }
    }

    public class RegisterCode : ConfigurationElement
    {
        [ConfigurationProperty("codeLength", DefaultValue = GenerateSettings.Length, IsRequired = true)]
        public int CodeLength
        {
            get { return ((int)(base["codeLength"])); }
            set { base["codeLength"] = value; }
        }

        [ConfigurationProperty("symbols", DefaultValue = GenerateSettings.Symbols, IsRequired = true)]
        public string Symbols
        {
            get { return ((string)(base["symbols"])); }
            set { base["symbols"] = value; }
        }
    }

    public class Password : ConfigurationElement
    {
        [ConfigurationProperty("length", DefaultValue = GenerateSettings.Length, IsRequired = true)]
        public int Length
        {
            get { return ((int)(base["length"])); }
            set { base["length"] = value; }
        }

        [ConfigurationProperty("symbols", DefaultValue = GenerateSettings.Symbols, IsRequired = true)]
        public string Symbols
        {
            get { return ((string)(base["symbols"])); }
            set { base["symbols"] = value; }
        }
    }
}
