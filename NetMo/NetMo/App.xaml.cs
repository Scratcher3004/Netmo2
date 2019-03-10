using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NetMo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Util.LocalDataManager.WriteSettings(NetmoSettings.Instance);
            //var settings = Util.LocalDataManager.ReadSettings();
            //Util.LocalDataManager.WriteSettings(NetmoSettings.Instance);
            //var settings2 = Util.LocalDataManager.ReadSettings();

            MainPage = new NavigationPage(new Pages.HomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
