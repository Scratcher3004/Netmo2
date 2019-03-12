using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NetMo.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NetMo.Notifaction;
using NetMo.Columns;
namespace NetMo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public static HomePage pg;

        public HomePage ()
        {
            pg = this;
            InitializeComponent();

            //var settings = Util.LocalDataManager.ReadSettings();

            //if (settings == null)
            //{
            //    DisplayAlert("Info", "Settings not found!", "okay");
            //}
            //else {
            //    NetmoSettings.SetSettings(settings.ClientID, settings.ClientSecret, settings.Username, settings.Password, settings.DeviceID);
            //}

        }

    }
}