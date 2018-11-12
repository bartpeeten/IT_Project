using Foundation;
using KBVB.AR.iOS.Services;
using KBVB.AR.Services;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ShareService))]
namespace KBVB.AR.iOS.Services
{
    public class ShareService : IShareService
    {
        public async void Share(string subject, string message, ImageSource imageSource)
        {
            var handler = new ImageLoaderSourceHandler();
            var uiImage = await handler.LoadImageAsync(imageSource);
            var img = NSObject.FromObject(uiImage);
            var msg = NSObject.FromObject(message);
            var activityItems = new[] { msg, img };
            var activityController = new UIActivityViewController(activityItems, null);
            var topController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            while (topController.PresentedViewController != null)
            {
                topController = topController.PresentedViewController;
            }

            topController.PresentViewController(activityController, true, () => { });
        }
    }
}
