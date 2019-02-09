using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Microsoft.Toolkit.Uwp.Notifications;
using Netmo2.Util;
using Windows.UI.Notifications;

namespace Netmo2.Notifaction
{
    /// <summary>
    /// Changes the Content every half minute
    /// </summary>
    public class ContentChanger
    {
        private DispatcherTimer timer;
        private MainPage resources;
        private int current = 0;
        private int curr2 = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public ContentChanger(MainPage page)
        {
            resources = page;

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(600)
            };
            timer.Tick += Do;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Start()
        {
            timer.Start();
        }

        /// <summary>
        /// Creates a Page Updater that updates several times
        /// </summary>
        /// <param name="page"></param>
        /// <param name="interval">The interval in seconds of Update rate.</param>
        public ContentChanger(MainPage page, int interval)
        {
            resources = page;

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(interval * 20)
            };
            timer.Tick += Do;
            timer.Start();
        }

        private void Do(object sender, object e)
        {
            string content = "";
            if (curr2 != 0 && curr2 % 20 == 0)
            {
                MainPage.page.UpdateData();
            }
            Device device = MainPage.page.GetCurrent().Body.Devices[0];
            DeviceDashboardData data = device.DashboardData;

            switch (current)
            {
                case 0:
                    content = "Pressure in " + device.ModuleName + ": " + data.Pressure + " Bar";
                    break;

                case 1:
                    content = "Temerature in " + device.ModuleName + ": " + data.Temperature + "°C";
                    break;

                case 2:
                    content = "CO2 in " + device.ModuleName + ": " + data.Co2 + "";
                    break;

                case 3:
                    content = "Humidity in " + device.ModuleName + ": " + data.Humidity + "%";
                    break;

                case 4:
                    content = "Noise in " + device.ModuleName + ": " + data.Noise + "";
                    break;

                default:
                    break;
            }

            var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text04);
            var tileAttributes = tileXml.GetElementsByTagName("text");
            tileAttributes[0].AppendChild(tileXml.CreateTextNode(content));
            var tileNotification = new TileNotification(tileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);

            current++;
            curr2++;

            if (current > 4)
            {
                current = 0;
            }
        }
    }
}
