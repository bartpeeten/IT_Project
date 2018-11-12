using System.Diagnostics;
using KBVB.AR.ViewModels;
using Xamarin.Forms;

namespace KBVB.AR.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
        }
    }
}
