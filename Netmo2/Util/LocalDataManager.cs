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
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            return localSettings;
        }

        public static void WriteSettings(NetmoSettings settings)
        {
            
        }

        public static void OverwriteNetmoData(NetAtmoResponse data)
        {
            
        }
    }
}