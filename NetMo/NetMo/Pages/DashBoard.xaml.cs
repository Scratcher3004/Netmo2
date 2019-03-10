using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMo.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NetMo.Util;
using System.Collections.ObjectModel;

namespace NetMo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashBoard : ContentPage
	{
        private static bool First = true;
        public Connector connector;
        public NetAtmoResponse netAtmoData;
        public ObservableCollection<Util.Device> Devices;

        public DashBoard ()
		{
			InitializeComponent ();
            connector = new Connector(NetmoSettings.Instance.ClientID, NetmoSettings.Instance.ClientSecret, NetmoSettings.Instance.Username, 
                                      NetmoSettings.Instance.Password, NetmoSettings.Instance.DeviceID);

        Devices = new ObservableCollection<Util.Device>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (First)
            {
                var result = await ReadWeatherData();
       
                foreach (var dev in netAtmoData.Body.Devices)
                {
                    Devices.Add(dev);
                }
                lvDevices.ItemsSource = Devices;
            }
            First = false;
        }

        private void LvDevices_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Util.Device selectedDevice)
            {
                Navigation.PushAsync(new ModulePage(selectedDevice));
            }
            ((ListView)sender).SelectedItem = null;
        }


        private async Task<bool> ReadWeatherData()
        {
            await connector.ReadTokenAsync();
            if (connector.CurrentToken == null)
            {
                throw new Exception("Token nicht vorhanden!");
            }

            var wetterdaten = await connector.GetNetatmoWeatherDataAsync();

            if (wetterdaten.Status.ToLower() == "ok")
            {
                this.netAtmoData = wetterdaten;
                return true;
            }
            return false;
        }

    }
}