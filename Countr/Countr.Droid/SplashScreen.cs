using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Countr.Droid
{
    [Activity(
        Label = "Countr"
        , MainLauncher = true
        , Icon = "@mipmap/ic_launcher"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen(): base(Resource.Layout.SplashScreen)
        {
        }

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);

            AppCenter.Start("c9e5e13a-df58-4376-94ee-bca4719a6885",
                   typeof(Analytics), typeof(Crashes));
        }
    }
}
