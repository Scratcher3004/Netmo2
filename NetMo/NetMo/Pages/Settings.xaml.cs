using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMo.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetMo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage
	{
		public Settings ()
		{
			InitializeComponent ();
            EntUserName.Text = UserSettings.UserName;
            EntPassword.Text = UserSettings.Password;
            EntDeviceId.Text = UserSettings.DeviceId;
            EntClientSecret.Text = UserSettings.ClientSecret;
            EntClientId.Text = UserSettings.ClientId;
		}

        private void BtnSaveSettings_Clicked(object sender, EventArgs e)
        {
            //NetmoSettings.SetSettings(EntClientId.Text, EntClientSecret.Text, EntUserName.Text, EntPassword.Text, EntDeviceId.Text);
            UserSettings.UserName = EntUserName.Text;
            UserSettings.Password = EntPassword.Text;
            UserSettings.ClientId = EntClientId.Text;
            UserSettings.ClientSecret = EntClientSecret.Text;
            UserSettings.DeviceId = EntDeviceId.Text;
            DisplayAlert("Info", "Setting saved", "ok");
        }
    }
}