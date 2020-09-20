using Microsoft.Win32;

namespace dl.wm.presenter.Utilities
{
    public sealed class ClientSettingsSingleton
    {
        private static ClientSettingsSingleton Instance { get; } = new ClientSettingsSingleton();
        private static readonly string _defaultIPAddress = "localhost";
        private static readonly string _defaultToken = "";
        private static readonly string _defaultRefreshToken = "";

        public static ClientSettingsSingleton InstanceSettings()
        {
            return Instance;
        }

        private ClientSettingsSingleton()
        {
        }

        private string RegistryKeyPathClient => "SOFTWARE\\\\digitalabs\\\\Clients\\\\dlwm";

        private string IpAddressConfigRegistryKey => "IP";
        private string TokenConfigRegistryKey => "TKN";
        private string RefreshTokenConfigRegistryKey => "RTKN";

        public string IpAddressConfigValue
        {
            get
            {
                string val = RegistryEditCls.GetStringValue(Registry.LocalMachine, RegistryKeyPathClient, IpAddressConfigRegistryKey);
                if (!string.IsNullOrEmpty(val))
                    return CryptoCls.Decrypt(val);
                return _defaultIPAddress;
            }
            set => RegistryEditCls.SetStringValue(Registry.LocalMachine, RegistryKeyPathClient, IpAddressConfigRegistryKey, CryptoCls.Encrypt(value));
        }

        public string TokenConfigValue
        {
            get
            {
                string val = RegistryEditCls.GetStringValue(Registry.LocalMachine, RegistryKeyPathClient, TokenConfigRegistryKey);
                if (!string.IsNullOrEmpty(val))
                    return CryptoCls.Decrypt(val);
                return _defaultToken;
            }
            set => RegistryEditCls.SetStringValue(Registry.LocalMachine, RegistryKeyPathClient, TokenConfigRegistryKey, CryptoCls.Encrypt(value));
        }
        public string RefreshTokenConfigValue
        {
            get
            {
                string val = RegistryEditCls.GetStringValue(Registry.LocalMachine, RegistryKeyPathClient, RefreshTokenConfigRegistryKey);
                if (!string.IsNullOrEmpty(val))
                    return CryptoCls.Decrypt(val);
                return _defaultRefreshToken;
            }
            set => RegistryEditCls.SetStringValue(Registry.LocalMachine, RegistryKeyPathClient, RefreshTokenConfigRegistryKey, CryptoCls.Encrypt(value));
        }
    }
}
