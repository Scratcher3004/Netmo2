using NetMo.Util;
using NetMo.Util.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static NetMo.Util.TimeHelpers;

namespace NetMo.Pages.Devices
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndoorModule : ContentPage
    {
        private Module module;

        public IndoorModule(Module indoorModule)
        {
            InitializeComponent();
            module = indoorModule;
            
            moduleName.Text = indoorModule.ModuleName;
            lastMessure.Text = "Last Measure: " + (TimestampToDateTime(indoorModule.LastMessage)).Minute.ToString() + " Minutes ago";

            temperatureField.Text = indoorModule.DashboardData.Temperature + " °C";
            co2Field.Text = indoorModule.DashboardData.Co2 + " PPM";
            humidityField.Text = indoorModule.DashboardData.Humidity + " %";

            temperatureTrend.Text = Helpers.GetTrendEng(indoorModule.DashboardData.TempTrend);
        }
    }
}