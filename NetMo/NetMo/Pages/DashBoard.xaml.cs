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
            connector = new Connector(UserSettings.ClientId, UserSettings.ClientSecret, UserSettings.UserName, UserSettings.Password, UserSettings.DeviceId);

            Devices = new ObservableCollection<Util.Device>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (First)
            {
                try
                {
                    var result = await ReadWeatherData();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Fehler!", ex.Message.ToString(), "okay");
                    return;
                }

       
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
                Navigation.PushAsync(new DevicePage(selectedDevice));
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