using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMo.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace NetMo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModulePage : ContentPage
	{
        public ObservableCollection<Util.Module> ModulesCollection;
        public ModulePage (NetMo.Util.Device device)
		{
			InitializeComponent ();
            ModulesCollection = new ObservableCollection<Util.Module>();
            foreach (var module in device.Modules)
            {
                ModulesCollection.Add(module);
            }
            LvModules.ItemsSource = ModulesCollection;
        }
	}
}