using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using KBVB.AR.Messages;
using KBVB.AR.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KBVB.AR.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent ();
		}
    }
}