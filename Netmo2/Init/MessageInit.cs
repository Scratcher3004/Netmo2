using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Notifications;
using Netmo2.Notifaction;
using Windows.ApplicationModel.Background;
using JsonDeserialize;
using Netmo2.Columns;

namespace Netmo2.Init
{
    public class MessageInit
    {
        const string taskName = "NetmoMessageBackgroundTasks";
        public static MessageInit Current { get; private set; } = new MessageInit();

        public MessageInit()
        {
            
        }

        public async static void Init()
        {
            MessageInit rent = new MessageInit();
            Current = rent;
            //App.app.OnBackgroundActivatedEvent += Current.OnBackgroundActivated;

            // If background task is already registered, do nothing
            if (BackgroundTaskRegistration.AllTasks.Any(i => i.Value.Name.Equals(taskName)))
                return;

            await BackgroundExecutionManager.RequestAccessAsync();

            // Create the background task
            BackgroundTaskBuilder builder = new BackgroundTaskBuilder()
            {
                Name = taskName,
                TaskEntryPoint = "Netmo2.Notifaction.BackgroundTask",
                TaskGroup = new BackgroundTaskRegistrationGroup("Netmo2Messages")
            };

            // Assign the toast action trigger
            builder.SetTrigger(new TimeTrigger(15, false));

            // And register the task
            BackgroundTaskRegistration registration = builder.Register();
        }

        /*public async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            var deferral = args.TaskInstance.GetDeferral();

            switch (args.TaskInstance.Task.Name)
            {
                case "ToastBackgroundTask":
                    if (MainPage.page.GetCurrent() == null)
                        break;

                    foreach (var item in ContentChanger.DeviceAnnouncements.Announcements)
                    {
                        if (item.IsTriggered(MainPage.page.GetCurrent().Body.Devices[0]))
                        {
                            NotificationSender.SendWarnNotification(item.Id, item.Dir, MainPage.page.GetCurrent().Body.Devices[0].DashboardData.GetValueByJsonKey(item.Id).ToString(), MainPage.page.GetCurrent().Body.Devices[0].ModuleName);
                        }
                    }
                    break;

                case taskName:
                    if (MainPage.page.GetCurrent() == null)
                        break;

                    foreach (var item in ContentChanger.DeviceAnnouncements.Announcements)
                    {
                        if (item.IsTriggered(MainPage.page.GetCurrent().Body.Devices[0]))
                        {
                            SerializeableJsonObject newObject = Serialization.Serialize(MainPage.page.GetCurrent().Body.Devices[0], item.Id, out string endOfPath);
                            NotificationSender.SendWarnNotification(endOfPath, item.Dir, newObject.GetValueByJsonKey(endOfPath).ToString(), MainPage.page.GetCurrent().Body.Devices[0].ModuleName);
                        }
                    }

                    if (MainPage.page.GetCurrent().Body.Devices[0].Modules.Length > 0)
                    {
                        foreach (var module in MainPage.page.GetCurrent().Body.Devices[0].Modules)
                        {
                            foreach (var item in ContentChanger.ModuleAnnouncements.Announcements)
                            {
                                if (item.IsTriggered(module))
                                {
                                    SerializeableJsonObject newObject = Serialization.Serialize(module, item.Id, out string endOfPath);
                                    NotificationSender.SendWarnNotification(endOfPath, item.Dir, newObject.GetValueByJsonKey(endOfPath).ToString(), module.ModuleName);
                                }
                            }
                        }
                    }
                    break;
            }

            deferral.Complete();
        }*/
    }
}
