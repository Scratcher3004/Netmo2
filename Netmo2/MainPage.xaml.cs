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

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace Netmo2
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // TODO: Remove and add Login Interface
        private string ClientID = "5c18ff3c6b0affcc188bbe4a";
        private string ClientSecret = "SjHyLVQnhaougeMNW9ahihewPGjbEiCl2zS";
        private string Password = "KuRsE2018!";
        private string Username = "peter.steinkamp@googlemail.com";
        private string DeviceID = "70:ee:50:36:f0:2a";

        private Connector connector;
        private NetAtmoResponse resp;

        public MainPage()
        {
            this.InitializeComponent();

            connector = new Connector(ClientID, ClientSecret, Username, Password, DeviceID);
            resp = connector.GetNetatmoWeatherData();

            // TODO: Add display and remove Placeholder for Temperature
            storedtemp.Text = "TestText Temperature = " + resp.Body.Devices[0].DashboardData.Temperature;
        }
    }
}
