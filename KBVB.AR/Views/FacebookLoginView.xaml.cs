using GalaSoft.MvvmLight.Messaging;
using KBVB.AR.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KBVB.AR.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FacebookLoginView : ContentPage
	{
		public FacebookLoginView ()
		{
			InitializeComponent ();

            var msg = new CurrentPageMessage() { CurrentPage = this };
            Messenger.Default.Send<CurrentPageMessage>(msg);
        }
	}
}