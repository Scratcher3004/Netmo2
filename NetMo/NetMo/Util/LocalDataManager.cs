using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMo;
using NetMo.Pages;
using Xamarin.Forms;

namespace NetMo.Util
{
    public static class LocalDataManager
    {

        private const string NETMOSETTINGS = "NetmoTestSettings";

        //public static StorageFolder GetDataPath()
        //{
        //    StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        //    return localFolder;
        //}

        //public static ApplicationDataContainer GetSettings()
        //{
        //    ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;
        //    return roamingSettings;
        //}

        public static void WriteSettings(NetmoSettings settings)
        {
            Xamarin.Forms.Application.Current.Properties[NETMOSETTINGS] = settings;
        }

        public static NetmoSettings ReadSettings()
        {
            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(NETMOSETTINGS))
            {
                var x = Xamarin.Forms.Application.Current.Properties[NETMOSETTINGS];

                return NetmoSettings.Instance;
            }
            return null;
        }

        //public static NetmoSettings GetNetmoSettings()
        //{

        //    throw new NotImplementedException();
        //    //ApplicationDataContainer data = GetSettings();
        //    NetmoSettings settings = new NetmoSettings();
        //    //{
        //    //    ClientID = (string)data.Values["client_id"],
        //    //    ClientSecret = (string)data.Values["client_secret"],
        //    //    Password = (string)data.Values["password"],
        //    //    Username = (string)data.Values["username"],
        //    //    DeviceID = (string)data.Values["devId"]
        //    //};

        //    return settings;
        //}

        public static void OverwriteNetmoData(NetAtmoResponse data)
        {
            
        }
    }
}