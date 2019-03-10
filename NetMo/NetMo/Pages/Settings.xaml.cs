using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}

        private void BtnSaveSettings_Clicked(object sender, EventArgs e)
        {
            NetmoSettings.SetSettings(EntClientId.Text, EntClientSecret.Text, EntUserName.Text, EntPassword.Text, EntDeviceId.Text);
        }
    }
}