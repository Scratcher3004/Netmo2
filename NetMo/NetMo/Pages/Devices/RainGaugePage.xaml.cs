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
	public partial class RainGaugePage : ContentPage
	{
        private Module module;

        public RainGaugePage(Module indoorModule)
        {
            InitializeComponent();
            module = indoorModule;

            moduleName.Text = indoorModule.ModuleName;
            lastMessure.Text = "Last Measure: " + (TimestampToDateTime(indoorModule.LastMessage)).Minute.ToString() + " Minutes ago";

            rainField.Text = indoorModule.DashboardData.Rain + " mm";
            sumH.Text = indoorModule.DashboardData.SumRainH + " mm";
            sumD.Text = indoorModule.DashboardData.SumRainD + " mm";
        }
    }
}