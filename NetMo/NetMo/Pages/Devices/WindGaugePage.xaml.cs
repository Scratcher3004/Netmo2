using NetMo.Util;
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
	public partial class WindGaugePage : ContentPage
	{
        private Module module;

        public WindGaugePage(Module windGauge)
        {
            InitializeComponent();
            module = windGauge;

            moduleName.Text = windGauge.ModuleName;
            lastMessure.Text = "Last Measure: " + (TimestampToDateTime(windGauge.LastMessage)).Minute.ToString() + " Minutes ago";

            windStrength.Text = windGauge.DashboardData.WindStrength.ToString() + " kph";
            windAngle.Text = windGauge.DashboardData.WindAngle.ToString() + " °";

            gustStrength.Text = windGauge.DashboardData.GustStrength.ToString() + " kph";
            gustAngle.Text = windGauge.DashboardData.GustAngle.ToString() + " °";


            windStrengthHist.Text = windGauge.DashboardData.WindHistoric.WindStrength.ToString() + " kph";
            windAngleHist.Text = windGauge.DashboardData.WindHistoric.WindAngle.ToString() + " °";
        }
    }
}