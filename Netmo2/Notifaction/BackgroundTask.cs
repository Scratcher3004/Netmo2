using JsonDeserialize;
using Netmo2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace Netmo2.Notifaction
{
    public sealed class BackgroundTask : IBackgroundTask
    {
        private NetmoSettings settings;
        private NetAtmoResponse resp;
        private Connector connect;

        private DateTime expiration;

        private AnnouncementCollection DeviceAnnouncements = new DefaultDeviceAnnouncementResource().ConvertTo();
        private AnnouncementCollection ModuleAnnouncements = new DefaultModuleAnnouncementResource().ConvertTo();

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            if (expiration.ToFileTimeUtc() <= DateTime.Now.ToFileTimeUtc())
            {
                resp = await connect.GetNetatmoWeatherDataAsync();
                expiration = DateTime.Now.AddMinutes(5);
            }

            foreach (var item in DeviceAnnouncements.Announcements)
            {
                if (item.IsTriggered(resp.Body.Devices[0]))
                {
                    SerializeableJsonObject newObject = Serialization.Serialize(resp.Body.Devices[0], item.Id, out string endOfPath);
                    NotificationSender.SendWarnNotification(endOfPath, item.Dir, newObject.GetValueByJsonKey(endOfPath).ToString(), resp.Body.Devices[0].ModuleName);
                }
            }

            if (resp.Body.Devices[0].Modules.Length > 0)
            {
                foreach (var module in resp.Body.Devices[0].Modules)
                {
                    foreach (var item in ModuleAnnouncements.Announcements)
                    {
                        if (item.IsTriggered(module))
                        {
                            SerializeableJsonObject newObject = Serialization.Serialize(module, item.Id, out string endOfPath);
                            NotificationSender.SendWarnNotification(endOfPath, item.Dir, newObject.GetValueByJsonKey(endOfPath).ToString(), module.ModuleName);
                        }
                    }
                }
            }
        }

        public void UpdateSettings(NetmoSettings _setting)
        {
            settings = _setting;
            connect = new Connector(settings.ClientID, settings.ClientSecret, settings.Username, settings.Password, settings.DeviceID);
            expiration = DateTime.Now;
        }

        public BackgroundTask(NetmoSettings _setting)
        {
            settings = _setting;
            connect = new Connector(settings.ClientID, settings.ClientSecret, settings.Username, settings.Password, settings.DeviceID);
            expiration = DateTime.Now;
        }

        public BackgroundTask()
        {
            settings = new NetmoSettings()
            {
                // TODO: Remove and add Login Interface
                ClientID = "5c18ff3c6b0affcc188bbe4a",
                ClientSecret = "SjHyLVQnhaougeMNW9ahihewPGjbEiCl2zS",
                Password = "KuRsE2018!",
                Username = "peter.steinkamp@googlemail.com",
                DeviceID = "70:ee:50:36:f0:2a"
            };
            connect = new Connector(settings.ClientID, settings.ClientSecret, settings.Username, settings.Password, settings.DeviceID);
            expiration = DateTime.Now;
        }
    }
}
