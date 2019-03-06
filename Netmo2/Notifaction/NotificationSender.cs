using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
using Microsoft.QueryStringDotNET; // QueryString.NET

namespace Netmo2.Notifaction
{
    public class NotificationSender
    {
        public static void SendTestNotification()
        {
            ToastNotificationHistory hist = ToastNotificationManager.History;
            hist.Clear();

            // In a real app, these would be initialized with actual data
            string title = "Netmo gruesst!";
            string content = "Danke, dass sie sich für Netmo entschieden haben, der einfachste Netatmo-Ueberwachung!";
            //string image = "https://picsum.photos/360/202?image=883";
            string logo = /*"ms-appdata:///local/Andrew.jpg"*/ "https://picsum.photos/360/202?image=883";

            // Construct the visuals of the toast
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = title
                        },

                        new AdaptiveText()
                        {
                            Text = content
                        }
                    },

                    AppLogoOverride = new ToastGenericAppLogo()
                    {
                        Source = logo,
                        HintCrop = ToastGenericAppLogoCrop.Circle
                    }
                }
            };

            // Now we can construct the final toast content
            ToastContent toastContent = new ToastContent()
            {
                Visual = visual
            };

            // And create the toast notification
            var toast = new ToastNotification(toastContent.GetXml())
            {
                ExpirationTime = DateTime.Now.AddMinutes(1)
            };

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public static void SendWarnNotification(string name, Direction dir, string value, string deviceName)
        {
            ToastNotificationHistory hist = ToastNotificationManager.History;

            foreach (var item in hist.GetHistory())
            {
                if (item.Tag == name + "_" + deviceName)
                {
                    return;
                }
            }

            // In a real app, these would be initialized with actual data
            string title = "Achtung!";
            string content = name + " ist in der Einheit " + deviceName + " mit " + value + " " + (dir == Direction.Up ? "hoch" : "niedrig") + "!";
            //string image = "https://picsum.photos/360/202?image=883";
            string logo = /*"ms-appdata:///local/Andrew.jpg"*/ "Assets/Images/warning.png";

            // Construct the visuals of the toast
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = title
                        },

                        new AdaptiveText()
                        {
                            Text = content
                        }
                    },

                    AppLogoOverride = new ToastGenericAppLogo()
                    {
                        Source = logo,
                        HintCrop = ToastGenericAppLogoCrop.Circle
                    }
                }
            };

            // Now we can construct the final toast content
            ToastContent toastContent = new ToastContent()
            {
                Visual = visual
            };

            // And create the toast notification
            var toast = new ToastNotification(toastContent.GetXml())
            {
                ExpirationTime = DateTime.Now.AddMinutes(30),
                Tag = name + "_" + deviceName,
                Group = "Alerts"
            };

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
