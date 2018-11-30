using Foundation;
using UIKit;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using Countr.Core;

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

            // here is where your custom code should be placed

            return result;
        }
    }
}
