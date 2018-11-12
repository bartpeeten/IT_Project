using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KBVB.AR.Droid.Services;
using KBVB.AR.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:Dependency(typeof(ShareService))]
namespace KBVB.AR.Droid.Services
{
    public class ShareService : Activity, IShareService
    {
        public async void Share(string subject, string message, ImageSource imageSource)
        {
            var intent = new Intent(Intent.ActionSend);
            //intent.PutExtra(Intent.ExtraSubject, subject);
            intent.PutExtra(Intent.ExtraText, message);
            intent.SetType("image/png");

            var handler = new ImageLoaderSourceHandler();
            var bitmap = await handler.LoadImageAsync(imageSource, this);

            var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures +
                Java.IO.File.Separator + "player.png");

            using (var os = new System.IO.FileStream(path.AbsolutePath, System.IO.FileMode.Create))
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 100, os);
            }

            intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(path));
            MainApplication.CurrentContext.StartActivity(Intent.CreateChooser(intent, "Share Image"));
        }
    }
}