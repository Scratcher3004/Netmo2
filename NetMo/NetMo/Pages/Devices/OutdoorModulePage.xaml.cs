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
	public partial class OutdoorModulePage : ContentPage
	{
        private Module module;

        public OutdoorModulePage(Module indoorModule)
        {
            InitializeComponent();
            module = indoorModule;

            moduleName.Text = indoorModule.ModuleName;
            lastMessure.Text = "Last Measure: " + (TimestampToDateTime(indoorModule.LastMessage)).Minute.ToString() + " Minutes ago";

            temperatureField.Text = indoorModule.DashboardData.Temperature + " °C";
            humidityField.Text = indoorModule.DashboardData.Humidity + " %";

            tempMin.Text = indoorModule.DashboardData.MinTemp.ToString() + " °C";
            DateTime dtMinTemp = TimestampToDateTime((long)indoorModule.DashboardData.DateMinTemp);
            tempMinDate.Text = dtMinTemp.Month + "." + dtMinTemp.Day + "." + dtMinTemp.Year + "  " + dtMinTemp.Hour + ":" + dtMinTemp.Minute;

            tempMax.Text = indoorModule.DashboardData.MaxTemp.ToString() + " °C";
            DateTime dtMaxTemp = TimestampToDateTime((long)indoorModule.DashboardData.DateMaxTemp);
            tempMaxDate.Text = dtMaxTemp.Month + "." + dtMaxTemp.Day + "." + dtMaxTemp.Year + "  " + dtMaxTemp.Hour + ":" + dtMaxTemp.Minute;

            temperatureTrend.Text = Helpers.GetTrendEng(indoorModule.DashboardData.TempTrend);
        }
    }
}