using Foundation;
using UIKit;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using Countr.Core;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Countr.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
    {
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            UINavigationBar.Appearance.BarTintColor = UIColor.Orange;
            UINavigationBar.Appearance.TintColor = UIColor.DarkGray;
            var attrs = new NSDictionary(UIStringAttributeKey.ForegroundColor, UIColor.DarkGray);

            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes(attrs);

            var result = base.FinishedLaunching(application, launchOptions);

            AppCenter.Start("ab124130-3e0f-491c-9ca1-b6b182465f89",
                   typeof(Analytics), typeof(Crashes));

            // here is where your custom code should be placed

            return result;
        }
    }
}
