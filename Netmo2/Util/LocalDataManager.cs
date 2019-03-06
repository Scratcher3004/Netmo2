using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Netmo2;

namespace Netmo2.Util
{
    public class LocalDataManager
    {
        public static StorageFolder GetDataPath()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            return localFolder;
        }

        public static ApplicationDataContainer GetSettings()
        {
            ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;
            return roamingSettings;
        }

        public static void WriteSettings(NetmoSettings settings)
        {
            ApplicationDataContainer data = GetSettings();
            foreach (var item in settings.GetSettings())
            {
                data.Values[item.Key] = item.Value;
            }
        }

        public static NetmoSettings GetNetmoSettings()
        {
            ApplicationDataContainer data = GetSettings();
            NetmoSettings settings = new NetmoSettings
            {
                ClientID = (string)data.Values["client_id"],
                ClientSecret = (string)data.Values["client_secret"],
                Password = (string)data.Values["password"],
                Username = (string)data.Values["username"],
                DeviceID = (string)data.Values["devId"]
            };

            return settings;
        }

        public static void OverwriteNetmoData(NetAtmoResponse data)
        {
            
        }
    }
}