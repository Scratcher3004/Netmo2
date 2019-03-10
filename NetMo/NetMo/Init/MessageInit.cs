using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.ApplicationModel.Activation;
//using Windows.UI.Notifications;
//using Netmo2.Notifaction;
//using Windows.ApplicationModel.Background;

namespace NetMo.Init
{
    //public class MessageInit
    //{
    //    public static AnnouncementCollection announcements = new DefaultDeviceAnnouncementResource().ConvertTo();
    //    const string taskName = "NetmoMessageBackgroundTask";
    //    public static MessageInit Current { get; private set; } = new MessageInit();

    //    public MessageInit()
    //    {
    //        int x = 1 + 1;
    //    }

    //    //public async static void Init()
    //    //{
    //    //    MessageInit rent = new MessageInit();
    //    //    Current = rent;
    //    //    App.app.OnBackgroundActivatedEvent += Current.OnBackgroundActivated;

    //    //    // If background task is already registered, do nothing
    //    //    if (BackgroundTaskRegistration.AllTasks.Any(i => i.Value.Name.Equals(taskName)))
    //    //        return;

    //    //    await BackgroundExecutionManager.RequestAccessAsync();

    //    //    // Create the background task
    //    //    BackgroundTaskBuilder builder = new BackgroundTaskBuilder()
    //    //    {
    //    //        Name = taskName
    //    //    };

    //    //    // Assign the toast action trigger
    //    //    builder.SetTrigger(new ToastNotificationActionTrigger());

    //    //    // And register the task
    //    //    BackgroundTaskRegistration registration = builder.Register();
    //    //}

    //    //public async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
    //    //{
    //    //    var deferral = args.TaskInstance.GetDeferral();

    //    //    switch (args.TaskInstance.Task.Name)
    //    //    {
    //    //        case "ToastBackgroundTask":
    //    //            if (MainPage.page.GetCurrent() == null)
    //    //                break;

    //    //            foreach (var item in announcements.Announcements)
    //    //            {
    //    //                if (item.IsTriggered(MainPage.page.GetCurrent().Body.Devices[0]))
    //    //                {
    //    //                    NotificationSender.SendWarnNotification(item.Id, item.Dir, MainPage.page.GetCurrent().Body.Devices[0].DashboardData.GetValueByJsonKey(item.Id).ToString(), MainPage.page.GetCurrent().Body.Devices[0].ModuleName);
    //    //                }
    //    //            }
    //    //            break;
    //    //    }

    //    //    deferral.Complete();
    //    //}
    //}
}
