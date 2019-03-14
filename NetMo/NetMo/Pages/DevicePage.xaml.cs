using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMo.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using NetMo.Pages.Devices;
using NetMo.Util.Translation;

using static NetMo.Util.TimeHelpers;

namespace NetMo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DevicePage : ContentPage
	{
        public ObservableCollection<Module> ModulesCollection;
        public DevicePage (Util.Device device)
		{
			InitializeComponent ();
            ModulesCollection = new ObservableCollection<Module>();
            foreach (var module in device.Modules)
            {
                string mType = module.Type;
                switch (module.Type)
                {
                    case "NAModuleMain":
                        mType = "Main Module (Station/Device)";
                        break;
                    case "NAModule1":
                        mType = "Outdoor Module";
                        module.TexPath = "OutdoorPlaceholder.png";
                        break;
                    case "NAModule2":
                        mType = "Wind Gauge - Coming soon";
                        module.TexPath = "WindPlaceholder.png";
                        break;
                    case "NAModule3":
                        mType = "Rain Gauge - Coming soon";
                        module.TexPath = "RainPlaceholder.png";
                        break;
                    case "NAModule4":
                        mType = "Indoor Module";
                        module.TexPath = "IndoorPlaceholder.png";
                        break;
                    default:
                        break;
                }
                module.TranslatedType = mType;
                ModulesCollection.Add(module);
            }
            LvModules.ItemsSource = ModulesCollection;

            temperatureField.Text = device.DashboardData.Temperature.ToString() + " °C";
            temperatureTrend.Text = Helpers.GetTrendEng(device.DashboardData.TempTrend);

            tempMin.Text = device.DashboardData.MinTemp.ToString() + " °C";
            DateTime dtMinTemp = TimestampToDateTime(device.DashboardData.DateMinTemp);
            tempMinDate.Text = dtMinTemp.Month.ToString() + "." + dtMinTemp.Day.ToString() /*+ "."*/;

            pressureField.Text = device.DashboardData.Pressure.ToString() + " mBar";
            pressureTrend.Text = Helpers.GetTrendEng(device.DashboardData.PressureTrend);

            co2Field.Text = device.DashboardData.Co2.ToString() + " PPM";
            humidityField.Text = device.DashboardData.Humidity.ToString() + " %";

            stationName.Text = device.StationName;
            moduleName.Text = device.ModuleName + " (Internal Module)";

            if (device.Modules.Length > 0)
                externalModulesLabel.Text = "External Module" + ((device.Modules.Length > 1) ? "s" : "");
            else
                externalModulesLabel.Text = "";
        }

        private void LvModules_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Module selectedDevice)
            {
                switch (selectedDevice.Type)
                {
                    case "NAModule4":
                        Navigation.PushAsync(new IndoorModule(selectedDevice));
                        break;
                    default:
                        break;
                }
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}