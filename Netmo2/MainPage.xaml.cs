using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Netmo2.Util;
using System.Threading.Tasks;
using Netmo2.Notifaction;

namespace Netmo2
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public NetmoSettings settings = new NetmoSettings()
        {
            // TODO: Remove and add Login Interface
            ClientID = "5c18ff3c6b0affcc188bbe4a",
            ClientSecret = "SjHyLVQnhaougeMNW9ahihewPGjbEiCl2zS",
            Password = "KuRsE2018!",
            Username = "peter.steinkamp@googlemail.com",
            DeviceID = "70:ee:50:36:f0:2a"
        };

        private Connector connector;
        private NetAtmoResponse resp;
        private ContentChanger changer;

        public static MainPage page;

        public MainPage()
        {
            this.InitializeComponent();

            page = this;
            connector = new Connector(settings.ClientID, settings.ClientSecret, settings.Username, settings.Password, settings.DeviceID);
            resp = connector.GetNetatmoWeatherData();
            changer = new ContentChanger(this);

            // TODO: Add display and remove Placeholders for Temperature and switches
            storedtemp.Text = "TestText Temperature = " + resp.Body.Devices[0].DashboardData.Temperature;
        }

        public NetAtmoResponse GetCurrent()
        {
            return resp;
        }

        public void UpdateData()
        {
            resp = connector.GetNetatmoWeatherData();

            // TODO: Add display and remove Placeholders for Temperature and switches
            storedtemp.Text = "TestText Temperature = " + resp.Body.Devices[0].DashboardData.Temperature;
        }
    }

    public class NetmoSettings
    {
        public string ClientID = "";
        public string ClientSecret = "";
        public string Password = "";
        public string Username = "";
        public string DeviceID = "";
    }
}
