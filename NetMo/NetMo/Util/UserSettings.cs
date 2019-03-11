


// Helpers/Settings.cs  
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace NetMo.Util
{
    /// <summary>  
    /// This is the Settings static class that can be used in your Core solution or in any  
    /// of your client applications. All settings are laid out the same exact way with getters  
    /// and setters.   
    /// </summary>  
    public static class UserSettings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }

        public static string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }

        public static string DeviceId
        {
            get => AppSettings.GetValueOrDefault(nameof(DeviceId), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(DeviceId), value);
        }

        public static string ClientId
        {
            get => AppSettings.GetValueOrDefault(nameof(ClientId), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ClientId), value);
        }

        public static string ClientSecret
        {
            get => AppSettings.GetValueOrDefault(nameof(ClientSecret), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ClientSecret), value);
        }

        public static void ClearAllData()
        {
            AppSettings.Clear();
        }

    }
}
